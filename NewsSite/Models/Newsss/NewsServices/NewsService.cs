using Microsoft.EntityFrameworkCore;
using NewsSite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.Newsss.NewsServices
{
    public class NewsService : INewsService
    {
        public NewsDbContext _context;
        public NewsService(NewsDbContext context)
        {
            _context = context;
        }
        public async Task AddNews(NewsDto newsdto)
        {
          News news=new News()
            {
                Id =newsdto.Id,
                Body=newsdto.Body,
                Title=newsdto.Title,
                Date=newsdto.Date,
                Categories=newsdto.Categories
               
            };
            _context.News.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNews(int id)
        {
            Validation.ValidationId(id);
            News news = await _context.News.FirstOrDefaultAsync(c => c.Id == id);
            if (news == null)
            {
                throw new NullReferenceException();
            }
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<News> GetAllNews()
        {
            var news= _context.News;
            if (news == null)
            {
                throw new NullReferenceException();
            }
            foreach (var item in news)
            {
                yield return item; 
            }
        }

        public Task<News> GetByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        //public async Task<News> GetByDateTime(DateTime date)
        //{
        //    News news = await _context.News.Include(c => c.Categories).Where(c => (c.Date == date)).AsNoTracking().AsAsyncEnumerable();
        //        if (news == null)
        //    {
        //        throw new NullReferenceException();
        //    }
        //    return news;
        //}

        //public async Task<News> GetByCategory(string categoryName)
        //{
        //    News news=await _context.News.Include(c=>c.Categories).Where(c=>categoryName);
        //}

        public async Task<News> GetNewsById(int id)
        {
            Validation.ValidationId(id);
           News news = await _context.News.FirstOrDefaultAsync(c => c.Id == id);
            if (news == null)
            {
                throw new NullReferenceException();
            }
            return news;
        }

        public async Task UpdateNews(NewsDto newsdto, int id)
        {
            News news = new News()
            {
                Id = newsdto.Id,
                Body = newsdto.Body,
                Title = newsdto.Title,
                Date = newsdto.Date,
                Categories = newsdto.Categories

            };
            if (news == null)
            {
                throw new NullReferenceException();
            }
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }
    }
}
