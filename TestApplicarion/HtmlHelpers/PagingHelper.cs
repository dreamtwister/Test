using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TestApplicarion.Infrastructure;

namespace TestApplicarion.HtmlHelpers
{
    public static class PagingHelper
    {

        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            int pageSize,
            int pageCount,
            int currentPage,
            Func<int, string> pageUrl)
        {
            var result = new StringBuilder();

            var __elements = PagingBuilder.Generate(pageSize, pageCount, currentPage);

            foreach (var __element in __elements)
            {
                TagBuilder __tag;
                if (__element.IsLink)
                {
                    __tag = new TagBuilder("a");
                    __tag.MergeAttribute("href", pageUrl(__element.Page));
                    __tag.InnerHtml = String.IsNullOrWhiteSpace(__element.Name) ? __element.Page.ToString(): __element.Name;
                    if (__element.IsCurrent)
                        __tag.AddCssClass("selected");
                }
                else
                {
                    __tag = new TagBuilder("label") {InnerHtml = __element.Name};
                }
                result.Append(__tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }

    }
}