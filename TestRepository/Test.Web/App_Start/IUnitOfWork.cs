using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Core.Model;
using Test.EntityFramework;

namespace Test.Web.App_Start
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepository;
    }
}