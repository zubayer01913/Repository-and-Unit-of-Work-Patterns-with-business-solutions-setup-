using AutoMapper;
using System.Threading.Tasks;
using System.Web.Mvc;
using Test.Core.Model;
using Test.EntityFramework;
using Test.Service.Students;
using Test.Web.App_Start;
using Test.Web.ViewModels;

namespace Test.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentAppService _studentAppService;
        private readonly IMapper _mapper;
        public StudentsController(IUnitOfWork myInstance, IStudentAppService studentAppService, IMapper mapper)
        {
            _unitOfWork = myInstance;
            _mapper = mapper;
            _studentAppService = studentAppService;
        }       
        [HttpGet]
        public ActionResult Index()
        {
            var dd = new Student();
            _mapper.Map<Student, StudentViewModel>(dd);
            // same work only uniofwork and repositroy

            //var model = _unitOfWork.StudentRepository.FindAll();

            //same work only service and repository

            // var model = _studentAppService.GetAll();          
            return View();
        }
    }
}