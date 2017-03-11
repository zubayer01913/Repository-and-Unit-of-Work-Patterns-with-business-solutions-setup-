using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Core.Model;
using Test.EntityFramework;

namespace Test.Service.Students
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentAppService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public  List<Student> GetAll()
        {
            return _studentRepository.FindAll().ToList();
        }
        public  Student Get(int id)
        {
            return _studentRepository.FindAll().Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
