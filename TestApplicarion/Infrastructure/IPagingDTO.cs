using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicarion.Infrastructure
{
    public interface IPagingDTO
    {
        /// <summary>
        /// Количество записей на странице
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Общее чилсо записей
        /// </summary>
        int PageCount { get; set; }

        /// <summary>
        /// Текущая страница
        /// </summary>
        int CurrentPage { get; set; }
    }
}
