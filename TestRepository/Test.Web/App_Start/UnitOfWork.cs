using System;
using Test.Core.Model;
using Test.EntityFramework.DbContext;
using Test.Web.App_Start;

namespace Test.EntityFramework
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        //Private members corresponding to each concrete repository
        private Repository<Student> studentRepository;

        //Accessors for each private repository, creates repository if null
        public IRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new Repository<Student>(dbContext);
                }
                return studentRepository;
            }

        }


        //Method to save all changes to repositories
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        //IDisposible implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        //readonly ApplicationDbContext _context;

        //public UnitOfWork(ApplicationDbContext context)
        //{
        //    _context = context;
        //    GetType().GetProperties()
        //        .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(IRepository<>))
        //        .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(IStudentAppService))
        //        .ToList()
        //        .ForEach(dbset =>
        //        {
        //            Type EntityType = dbset.PropertyType.GenericTypeArguments[0];
        //            Type GenericRepoType = typeof(Repository<>).MakeGenericType(EntityType);
        //            ConstructorInfo ctor = GenericRepoType.GetConstructor(new[] { typeof(ApplicationDbContext) });
        //            object GenericRepoInstance = ctor.Invoke(new object[] { _context });
        //            dbset.SetValue(this, GenericRepoInstance);
        //        });
        //}

        //public async Task SaveChanges()
        //{
        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            transaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //        }
        //    }
        //}
    }
}
