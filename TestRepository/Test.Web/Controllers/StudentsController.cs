using System.Threading.Tasks;
using System.Web.Mvc;
using Test.Core.Model;
using Test.EntityFramework;
using Test.Service.Students;
using Test.Web.App_Start;

namespace Test.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentAppService _studentAppService;

        public StudentsController(IUnitOfWork myInstance, IStudentAppService studentAppService)
        {
            _unitOfWork = myInstance;
            _studentAppService = studentAppService;
        }       
        [HttpGet]
        public ActionResult Index()
        {
            // same work only uniofwork and repositroy

            //var model = _unitOfWork.StudentRepository.FindAll();

            //same work only service and repository

            // var model = _studentAppService.GetAll();          
            return View();
        }
    }
}