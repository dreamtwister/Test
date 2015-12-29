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

        [TestMethod]
        public void CheckAdd()
        {
            var __task = new TaskDTO()
            {
                ID = Guid.NewGuid(),
                DeadLine = DateTime.Now,
                IsDone = true,
                Name = "тестовая задача"
            };
            _model.Save(__task);
            var __savedTask = _model.GetByID(__task.ID);

            if (__savedTask == null) Assert.Fail("Задача не сохранилась");
            Assert.AreEqual(__task.ID, __savedTask.ID, "ID новой задачи создан неправильно");
            Assert.AreEqual(__task.DeadLine, __savedTask.DeadLine, "дата новой задачи создана неправильно");
            Assert.AreEqual(__task.Name, __savedTask.Name, "текст новой задачи создан неправильно");
            Assert.AreEqual(__task.IsDone, __savedTask.IsDone, "статус новой задачи создан неправильно");
        }

        [TestMethod]
        public void CheckEdit()
        {
            var __task = _model.GetList().Tasks.FirstOrDefault();
            __task.DeadLine = DateTime.Now;
            __task.IsDone = !__task.IsDone;
            __task.Name = "тестовая задача - редактирование";

            _model.Save(__task);
            var __savedTask = _model.GetByID(__task.ID);

            if (__savedTask == null) Assert.Fail("Задача не сохранилась");
            Assert.AreEqual(__task.DeadLine, __savedTask.DeadLine, "дата изменена неправильно");
            Assert.AreEqual(__task.Name, __savedTask.Name, "текст изменен неправильно");
            Assert.AreEqual(__task.IsDone, __savedTask.IsDone, "статус изменен неправильно");
        }

        [TestMethod]
        public void CheckDelete()
        {
            var __task = _model.GetList().Tasks.FirstOrDefault();
            _model.Delete(__task.ID);

            var __deletedTask = _model.GetByID(__task.ID);

            Assert.AreEqual(__deletedTask.ID, Guid.Empty, "Задача не удалена");
        }
    }
}
