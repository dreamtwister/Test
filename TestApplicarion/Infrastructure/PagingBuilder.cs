using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace TestApplicarion.Infrastructure
{
    public static class PagingBuilder
    {
        public static PagingInfo[] Generate(int pageSize, int pageCount, int currentPage)
        {
            var result = new List<PagingInfo>();
            return result.ToArray();
        }
    }
}