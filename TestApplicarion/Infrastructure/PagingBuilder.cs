using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace TestApplicarion.Infrastructure
{
    public static class PagingBuilder
    {
        public static PagingInfo[] Generate(int pageSize, int elementCount, int currentPage)
        {
            var result = new List<PagingInfo>();

            pageSize = pageSize < 1 ? 1 : pageSize;
            elementCount = elementCount < 1 ? 1 : elementCount;
            currentPage = currentPage < 1 ? 1 : currentPage;

            var pageCount = elementCount/pageSize;
            pageCount = elementCount%pageSize > 0 ? pageCount + 1 : pageCount;

            
            if (currentPage <= pageCount)
            {
                //Сначала добавим текущую страницу, она всегда есть, она всегда отображается цифрой
                result.Add(new PagingInfo()
                {
                    Name = String.Empty,
                    IsCurrent = true,
                    IsLink = true,
                    Page = currentPage
                });

                //Теперь докладываем по 2 элемента справа и слева, или 1/3, или 0/4...
                for (int i = 0; i < 4; i++)
                {
                    if (i%2 > 0)
                    {
                        //Добавляем спереди, если есть чего
                        if (result[0].Page > 1)
                            result.Insert(0, new PagingInfo()
                            {
                                Name = String.Empty,
                                IsCurrent = false,
                                IsLink = true,
                                Page = result[0].Page - 1
                            });
                        else
                        {
                            if (result.Last().Page < pageCount)
                                result.Add(new PagingInfo()
                                {
                                    Name = String.Empty,
                                    IsCurrent = false,
                                    IsLink = true,
                                    Page = result.Last().Page + 1
                                });
                        }
                    }
                    else
                    {
                        if (result.Last().Page < pageCount)
                            result.Add(new PagingInfo()
                            {
                                Name = String.Empty,
                                IsCurrent = false,
                                IsLink = true,
                                Page = result.Last().Page + 1
                            });
                        else
                            if (result[0].Page > 1)
                                result.Insert(0, new PagingInfo()
                                {
                                    Name = String.Empty,
                                    IsCurrent = false,
                                    IsLink = true,
                                    Page = result[0].Page - 1
                                });
                    }
                }
                //Формируем цифры или многоточия спереди и сзади
                //Сначала спереди
                if (result[0].Page > 3)
                {
                    result.Insert(0, new PagingInfo()
                    {
                        Name = "...",
                        IsCurrent = false,
                        IsLink = false,
                        Page = 0
                    });
                    result.Insert(0, new PagingInfo()
                    {
                        Name = String.Empty,
                        IsCurrent = false,
                        IsLink = true,
                        Page = 1
                    });
                }
                else
                {
                    while (result[0].Page > 1)
                    {
                        result.Insert(0, new PagingInfo()
                        {
                            Name = String.Empty,
                            IsCurrent = false,
                            IsLink = true,
                            Page = result[0].Page - 1
                        });
                    }
                }

                //А потом и сзади
                if (result.Last().Page < pageCount - 2)
                {
                    result.Add( new PagingInfo()
                    {
                        Name = "...",
                        IsCurrent = false,
                        IsLink = false,
                        Page = 0
                    });
                    result.Add( new PagingInfo()
                    {
                        Name = String.Empty,
                        IsCurrent = false,
                        IsLink = true,
                        Page = pageCount
                    });
                }
                else
                {
                    while (result.Last().Page < pageCount)
                    {
                        result.Add( new PagingInfo()
                        {
                            Name = String.Empty,
                            IsCurrent = false,
                            IsLink = true,
                            Page = result.Last().Page + 1
                        });
                    }
                }

                //Текущая страница - не первая
                if (currentPage != 1)
                {
                    result.Insert(0, new PagingInfo
                    {
                        Name = "<",
                        IsCurrent = false,
                        IsLink = true,
                        Page = currentPage - 1
                    });
                }

                //Текущая страница - не последняя
                if (currentPage != pageCount)
                {
                    result.Add( new PagingInfo
                    {
                        Name = ">",
                        IsCurrent = false,
                        IsLink = true,
                        Page = currentPage + 1
                    });
                }
            }
            return result.ToArray();
        }
    }
}