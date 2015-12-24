using System;
using System.Collections.Generic;
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

    }
}
