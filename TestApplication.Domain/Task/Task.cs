using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Domain
{
    /// <summary>
    /// БО для списка задач
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Наименование задачи
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Статус исполнения
        /// </summary>
        public Boolean IsDone { get; set; }

        /// <summary>
        /// Желаемая дата исполнения
        /// </summary>
        public DateTime DeadLine { get; set; }
    }
}
