using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicarion.Models;
using TestApplication.Domain.Abstract;
using TestApplication.Test.Concrete;

namespace TestApplicarion.Tests
{
    [TestClass]
    public class DataTest
    {
        private TaskModel _model;
        public DataTest()
        {
            var container = new UnityContainer();
            container.RegisterType<ITasksRepository, EFTaskFakeRepository>();
            _model = container.Resolve<TaskModel>();
        }
    }
}
