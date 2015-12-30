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

        private int PageSize = 2;

        public TaskModel(ITasksRepository repository)
        {
            _repository = repository;
        }

        public TasksPagingDTO GetList(int page = 1)
        {
            var _res = new TasksPagingDTO
            {
                Tasks = _repository.Tasks.OrderByDescending(i => i.IsDone)
                    .ThenBy(i => i.DeadLine)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize).Select(TaskToDTO).ToList(),
                CurrentPage = page,
                PageSize = PageSize,
                PageCount = _repository.Tasks.Count()
            };

            return _res;
        }

        public TaskDTO GetByID(Guid? id)
        {
            if (id == null)
                return new TaskDTO()
                {
                    Name = String.Empty,
                    DeadLine = DateTime.Now.AddDays(1)
                };
            var __task = _repository.Tasks.FirstOrDefault(i => i.ID == id);
            if (__task != null)
            {
                return TaskToDTO(__task);
            }
            return new TaskDTO()
            {
                Name = String.Empty,
                DeadLine = DateTime.Now.AddDays(1)
            };
        }

        public void Save(TaskDTO task)
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
                    ID = task.ID != Guid.Empty ? task.ID : Guid.NewGuid(),
                    Name = task.Name,
                    IsDone = task.IsDone,
                    DeadLine = task.DeadLine
                };
                _repository.SaveTask(__task);
            }
        }

        public bool Delete(Guid id)
        {
            if (id == Guid.Empty) return false;
            var __task = _repository.Tasks.FirstOrDefault(i => i.ID == id);
            if (__task != null) _repository.DeleteTask(__task);
            return true;
        }

        Func<Task, TaskDTO> TaskToDTO = x => new TaskDTO()
        {
            ID = x.ID,
            Name = x.Name,
            IsDone = x.IsDone,
            DeadLine = x.DeadLine
        };
    }
}