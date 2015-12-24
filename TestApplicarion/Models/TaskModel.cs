﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public IList<TaskDTO> GetList()
        {
            var _res =  _repository.Tasks.Select(i => new TaskDTO
            {
                Name = i.Name,
                IsDone = i.IsDone
            }).ToList();

            return _res;
        }
    }
}