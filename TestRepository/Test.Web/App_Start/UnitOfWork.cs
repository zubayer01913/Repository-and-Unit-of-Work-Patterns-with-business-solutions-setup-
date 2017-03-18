using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Test.Core.Model;
using Test.EntityFramework.DbContext;
using Test.Web.App_Start;

namespace Test.EntityFramework
{
    //public class UnitOfWork : IUnitOfWork, IDisposable
    //{
    //    private ApplicationDbContext dbContext = new ApplicationDbContext();

    //    //Private members corresponding to each concrete repository
    //    private IRepository<Student> _studentRepository;
    //    public UnitOfWork(IRepository<Student> studentRepository)
    //    {
    //        _studentRepository = studentRepository;
    //    }

    //    //Accessors for each private repository, creates repository if null
    //    public IRepository<Student> StudentRepository
    //    {
    //        get
    //        {
    //            if (_studentRepository == null)
    //            {
    //                _studentRepository = new Repository<Student>(dbContext);
    //            }
    //            return _studentRepository;
    //        }

    //    }


    //    //Method to save all changes to repositories
    //    public void Commit()
    //    {
    //        dbContext.SaveChanges();
    //    }

    //    //IDisposible implementation
    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                dbContext.Dispose();
    //            }
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}




    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        public IRepository<Student> Students { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            //Since cannot configure unity to set these properties
            this.GetType().GetProperties()
                .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(IRepository<>))
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




   

