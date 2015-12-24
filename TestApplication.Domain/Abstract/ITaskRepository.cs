using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Domain.Abstract
{
    public interface ITasksRepository
    {
        IQueryable<Task> Tasks { get; }
    }
}
