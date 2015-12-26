using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication.Domain.Abstract
{
    public interface ITasksRepository
    {
        IQueryable<Task> Tasks { get; }

        void SaveTask(Task task);
    }
}
