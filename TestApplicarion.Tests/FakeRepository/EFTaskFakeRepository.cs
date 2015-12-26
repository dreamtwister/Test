using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Domain.Abstract;
using Task = TestApplication.Domain.Task;

namespace TestApplication.Test.Concrete
{
    public class EFTaskFakeRepository: ITasksRepository
    {
        private List<Task> _tasks;

        public EFTaskFakeRepository()
        {
            _tasks.AddRange(new[]
            {
                new Task
                {
                    ID = Guid.Parse("{A28D47F1-518E-477F-9F7D-8ECE60501644}"),
                    DeadLine = DateTime.Now.AddDays(1),
                    IsDone = true,
                    Name = "1"
                },
                new Task
                {
                    ID = Guid.Parse("{612AC1BE-0932-4D65-9E61-F6D6C2AD2248}"),
                    DeadLine = DateTime.Now.AddDays(-1),
                    IsDone = false,
                    Name = "2"
                },
                new Task
                {
                    ID = Guid.Parse("{7C61AA5E-EC14-437E-BEF5-E1D663745C94}"),
                    DeadLine = DateTime.Now.AddDays(-1),
                    IsDone = true,
                    Name = "3"
                },
                new Task
                {
                    ID = Guid.Parse("{263A5AC0-257D-4C42-9A6F-5884928E66EA}"),
                    DeadLine = DateTime.Now.AddDays(1),
                    IsDone = false,
                    Name = "4"
                },
                new Task
                {
                    ID = Guid.Parse("{D0925DD9-BA5E-41EA-A42A-CB797B44918F}"),
                    DeadLine = DateTime.Now.AddDays(10),
                    IsDone = false,
                    Name = "5"
                },
                new Task
                {
                    ID = Guid.Parse("{47CE4A0A-F9C8-4E1D-B88F-46ED7D376E16}"),
                    DeadLine = DateTime.Now.AddDays(10),
                    IsDone = false,
                    Name = "6"
                },
                new Task
                {
                    ID = Guid.Parse("{0837A3FC-B4E9-464D-8869-7C5F37D58834}"),
                    DeadLine = DateTime.Now.AddDays(11),
                    IsDone = false,
                    Name = "7"
                },
                new Task
                {
                    ID = Guid.Parse("{AAD9081B-A700-4D8C-B9AC-FA5644F55F0A}"),
                    DeadLine = DateTime.Now.AddDays(12),
                    IsDone = false,
                    Name = "8"
                },
                new Task
                {
                    ID = Guid.Parse("{F1D5F88D-5E02-4E96-AE26-8E7772225141}"),
                    DeadLine = DateTime.Now.AddDays(-5),
                    IsDone = false,
                    Name = "9"
                },
                new Task
                {
                    ID = Guid.Parse("{EE064A1E-44EA-4541-AA9D-541ACC214F0B}"),
                    DeadLine = DateTime.Now.AddDays(15),
                    IsDone = false,
                    Name = "10"
                },
                new Task
                {
                    ID = Guid.Parse("{B3831E37-64A2-4F3E-8011-850029AE0E41}"),
                    DeadLine = DateTime.Now.AddDays(17),
                    IsDone = false,
                    Name = "11"
                }
            });
        }

        public IQueryable<Task> Tasks 
        {
            get { return _tasks.AsQueryable(); }
        }

        public void SaveTask(Task task)
        {
            var __task = _tasks.FirstOrDefault(i => i.ID == task.ID);
            if (task != null)
            {
                _tasks.Remove(__task);
                _tasks.Add(task);
            }
            else
            {
                _tasks.Add(task);
            }
        }
    }
}
