using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Domain.Abstract;

namespace TestApplication.Domain.Concrete
{
    public class EFTaskRepository : ITasksRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Task> Tasks
        {
            get { return context.Tasks; }
        }

        public void SaveTask(Task task)
        {
            context.Tasks.AddOrUpdate(task);
            context.SaveChanges();
        }
    }
}
