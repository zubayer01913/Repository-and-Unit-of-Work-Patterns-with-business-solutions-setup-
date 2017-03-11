using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test.EntityFramework.DbContext;
using Test.Service.Students;

namespace Test.EntityFramework
{
    public class UnitOfWork
    {
        readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            GetType().GetProperties()
                .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(IRepository<>))
                .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(IStudentAppService))
                .ToList()
                .ForEach(dbset =>
                {
                    Type EntityType = dbset.PropertyType.GenericTypeArguments[0];
                    Type GenericRepoType = typeof(Repository<>).MakeGenericType(EntityType);
                    ConstructorInfo ctor = GenericRepoType.GetConstructor(new[] { typeof(ApplicationDbContext) });
                    object GenericRepoInstance = ctor.Invoke(new object[] { _context });
                    dbset.SetValue(this, GenericRepoInstance);
                });
        }

        public async Task SaveChanges()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
