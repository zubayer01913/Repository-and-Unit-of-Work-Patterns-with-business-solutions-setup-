using AutoMapper;
using Test.Core.Model;
using Test.Web.ViewModels;

namespace Test.Web.App_Start
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentViewModel>();
                
                /*etc...*/
            });

            return config;
        }
    }

}