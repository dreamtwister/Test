using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplicarion.Models
{
    public class TaskDTO
    {
        public Guid ID { get; set; }

        public String Name { get; set; }

        /// <summary>
        /// Выполнено
        /// </summary>
        public Boolean IsDone { get; set; }

        public DateTime DeadLine { get; set; }

        /// <summary>
        /// Выполнить сегодня
        /// </summary>
        public Boolean IsToday 
        {
            get { return DeadLine.Date == DateTime.Today; }
        }

        /// <summary>
        /// Просрочено
        /// </summary>
        public Boolean IsOutdate
        {
            get { return DeadLine.Date < DateTime.Today; }
        }
    }
}