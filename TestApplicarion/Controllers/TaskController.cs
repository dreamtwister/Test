using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TestApplicarion.Models;
using TestApplication.Domain.Abstract;
using TestApplication.Domain.Concrete;

namespace TestApplicarion.Controllers
{
    public class TaskController : Controller
    {
        private TaskModel _model;
        public TaskController()
        {
            var container = new UnityContainer();
            container.RegisterType<ITasksRepository, EFTaskRepository>()
                     .RegisterType<EFDbContext>(new InjectionConstructor());

            _model = container.Resolve<TaskModel>();
        }

        //
        // GET: /Task/
        public ActionResult Index()
        {
            return View(_model.GetList());
        }
	}
}