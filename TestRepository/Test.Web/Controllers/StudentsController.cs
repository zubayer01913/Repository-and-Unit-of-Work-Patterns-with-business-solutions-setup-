using System.Threading.Tasks;
using System.Web.Mvc;
using Test.Core.Model;
using Test.EntityFramework;
using Test.Service.Students;

namespace Test.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _unitOfWork. GetAll();
           // Student model = new Student();
            return View(model);
        }
    }
}