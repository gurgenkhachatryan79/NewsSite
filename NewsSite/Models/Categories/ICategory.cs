using NewsSite.Models.Newsss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.Categories
{
    interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<News> News { get; set; }
    }
}
