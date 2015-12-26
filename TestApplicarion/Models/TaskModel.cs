using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApplication.Domain;
using TestApplication.Domain.Abstract;
using WebGrease.Css.Extensions;

namespace TestApplicarion.Models
{
    public class TaskModel
    {
        private ITasksRepository _repository;

        public TaskModel(ITasksRepository repository)
        {
            _repository = repository;
        }

        public TasksPagingDTO GetList(int page = 1)
        {
            var _res = new TasksPagingDTO
            {
                //todo пока так, сначала выведем список, потом наведем тут порядок
                Tasks = _repository.Tasks.ToList().Select(i => TaskToDTO(i)).ToList()
            };
            return _res;
        }

        public TaskDTO GetByID(Guid? id)
        {
            var __task = _repository.Tasks.FirstOrDefault(i => i.ID == id);
            if (__task != null)
            {
                return TaskToDTO(__task);
            }
            return new TaskDTO();
        }

        public bool Save(TaskDTO task)
        {
            if (_repository.Tasks != null && _repository.Tasks.Select(i=>i.ID).Contains(task.ID))
            {
                var __task = _repository.Tasks.FirstOrDefault(i => i.ID == task.ID);
                __task.DeadLine = task.DeadLine;
                __task.IsDone = task.IsDone;
                __task.Name = task.Name;
                _repository.SaveTask(__task);
            }
            else
            {
                var __task = new Task
                {
                    ID = Guid.NewGuid(),
                    Name = task.Name,
                    IsDone = task.IsDone,
                    DeadLine = task.DeadLine
                };
                _repository.SaveTask(__task);
            }
            return true;
        }

        private TaskDTO TaskToDTO(Task task)
        {
            return new TaskDTO
            {
                ID = task.ID,
                Name = task.Name,
                IsDone = task.IsDone,
                DeadLine = task.DeadLine
            };
        }
    }
}