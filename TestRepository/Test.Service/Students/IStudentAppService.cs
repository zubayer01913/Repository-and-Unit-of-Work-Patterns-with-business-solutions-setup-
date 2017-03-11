using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Model;

namespace Test.Service.Students
{
    public interface IStudentAppService
    {
         List<Student> GetAll();
         Student Get(int id);
    }
}
