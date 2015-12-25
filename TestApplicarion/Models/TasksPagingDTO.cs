using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApplicarion.Infrastructure;

namespace TestApplicarion.Models
{
    public class TasksPagingDTO : IPagingDTO
    {
        public IList<TaskDTO> Tasks { get; set; }

        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }
}