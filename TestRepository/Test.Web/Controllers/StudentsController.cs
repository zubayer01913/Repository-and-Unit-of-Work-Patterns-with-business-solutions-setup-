using AutoMapper;
using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Test.Core.Model;
using Test.EntityFramework;
using Test.Service.Students;
using Test.Web.ViewModels;

namespace Test.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentAppService _studentAppService;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public StudentsController(UnitOfWork unitOfWork, IStudentAppService studentAppService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _studentAppService = studentAppService;
        }    
           
        [HttpGet]
        public ActionResult Index()
        {
            
            var dd = new Student();
            _mapper.Map<Student, StudentViewModel>(dd);
           // int ddd = Convert.ToInt32("dddddd");
            // same work only uniofwork and repositroy
            var model = _unitOfWork.Students.FindAll();

            //same work only service and repository
            // var model = _studentAppService.GetAll();          
            return View(model);
        }
    }
}