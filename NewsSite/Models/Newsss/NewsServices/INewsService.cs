using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.Newsss.NewsServices
{
  public  interface INewsService
    {
        IAsyncEnumerable<News> GetAllNews();
        Task<News> GetNewsById(int id);
        //Task<News> GetByCategory(string categoryName);
        //Task<News> GetByDateTime(DateTime date);
        Task AddNews(NewsDto newsdto);
        Task UpdateNews(NewsDto newsdto, int id);
        Task DeleteNews(int id);
    }
}
