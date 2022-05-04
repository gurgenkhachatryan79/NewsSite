using NewsSite.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.Newsss
{
    interface INews
    {
        int Id { get; set; }
        string Title { get; set; }
        DateTime Date { get; set; }
        string Body { get; set; }
        List<Category> Categories { get; set; }

    }
}
