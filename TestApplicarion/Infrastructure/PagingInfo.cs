using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplicarion.Infrastructure
{
    /// <summary>
    /// Элемент для отображения в пагинаторе
    /// По ним строится рендеринг
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Является ли элемент ссылкой для перехода
        /// </summary>
        public Boolean IsLink { get; set; }

        /// <summary>
        /// Текущая страница отображения
        /// </summary>
        public Boolean IsCurrent { get; set; }

        /// <summary>
        /// Куда переходить
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Текст для отображения
        /// </summary>
        public String Name { get; set; }
    }
}