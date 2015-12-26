using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicarion.Infrastructure;
using TestApplicarion.Models;
using TestApplication.Domain.Abstract;
using TestApplication.Domain.Concrete;
using TestApplication.Test.Concrete;

namespace TestApplicarion.Tests
{
    [TestClass]
    public class PagingTest
    {

        [TestMethod]
        public void CheckLinesCount()
        {
            int pageCount = 11;//Для одной записи на странице!
            var res = PagingBuilder.Generate(1, pageCount, 5).Count();
            if (res > pageCount) Assert.Fail("Элементов больше чем нужно.");
            if (res < pageCount) Assert.Fail("Элементов меньше чем нужно.");
        }

        [TestMethod]
        public void CheckUsual()
        {
            int pageCount = 11;//Для одной записи на странице!
            var res = PagingBuilder.Generate(1, pageCount, 6);

            if (res.Count() != pageCount) Assert.Fail("Неверное число элементов.");
            Assert.IsTrue(res[5].IsCurrent, "Неверно определена текущая страница.");
            Assert.IsFalse(String.IsNullOrWhiteSpace(res[0].Name), "Не задано наименование сдвига влево");
            Assert.IsFalse(String.IsNullOrWhiteSpace(res[10].Name), "Не задано наименование сдвига вправо");
            Assert.IsFalse(res[2].IsLink, "Третий элемент отображения не может быть ссылкой");
            Assert.IsFalse(res[8].IsLink, "Третий с конца элемент отображения не может быть ссылкой");
        }

        [TestMethod]
        public void CheckIfFirst()
        {
            int pageCount = 5;//Для одной записи на странице!
            var res = PagingBuilder.Generate(1, pageCount, 1);
            
            if (res.Count() != 6) Assert.Fail("Неверное число элементов.");

            var page = res[0];
            Assert.IsTrue(page.IsCurrent, "Неверно определена текущая страница.");
            Assert.IsTrue(page.IsLink, "Первая страница должна быть ссылкой.");
        }

        [TestMethod]
        public void CheckIfLast()
        {
            int pageCount = 5;//Для одной записи на странице!
            var res = PagingBuilder.Generate(1, pageCount, 5);

            if (res.Count() != 6) Assert.Fail("Неверное число элементов.");

            var page = res[5];
            Assert.IsTrue(page.IsCurrent, "Неверно определена текущая страница.");
            Assert.IsTrue(page.IsLink, "Последняя страница страница должна быть ссылкой.");
        }

        [TestMethod]
        public void CheckNoDots()
        {
            int pageCount = 9;//Для одной записи на странице!
            var res = PagingBuilder.Generate(1, pageCount, 5);
            if (res.Count() != 11) Assert.Fail("Неверное число элементов.");

            Assert.IsTrue(res[2].IsLink, "Третий элемент отображения должен быть ссылкой");
            Assert.IsTrue(res[8].IsLink, "Третий с конца элемент отображения должен быть ссылкой");
        }
    }
}
