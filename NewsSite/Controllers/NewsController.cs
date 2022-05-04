using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsSite.Context;
using NewsSite.Models.Newsss;
using NewsSite.Models.Newsss.NewsServices;

namespace NewsSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        private ILogger<NewsController> _logger;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            try
            {
                var news = _newsService.GetAllNews();

                if (news == null)
                {
                    _logger.LogInformation("No News");
                    return NotFound();
                }
                return Ok(news);
            }
            catch (Exception ex)
            {
                _logger.LogError("exception:", ex);
                return BadRequest();
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            try
            {
                var news = await _newsService.GetNewsById(id);
                if (news == null)
                {
                    _logger.LogInformation("News not found");
                    return BadRequest("News not found");
                }
                return news;
            }
            catch (ArgumentOutOfRangeException argex)
            {
                _logger.LogError("argex:", argex);
                return BadRequest(argex);
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest(ex);
            }
        }

        // PUT: api/News/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, NewsDto newsdto)
        {
            if (id != newsdto.Id)
            {
                _logger.LogInformation(" Not  valid Id ");
                return BadRequest();
            }

            try
            {
                await _newsService.UpdateNews(newsdto, id);

            }
            catch (DbUpdateConcurrencyException dbex)
            {
                _logger.LogError(dbex, "");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest(ex);
            }


            return NoContent();
        }

        // POST: api/News
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(NewsDto newsdto)
        {
            try
            {
                await _newsService.AddNews(newsdto);
                return CreatedAtAction("GetCategory", new { id = newsdto.Id }, newsdto);
            }
            catch (ArgumentOutOfRangeException argex)
            {
                _logger.LogError("argex:", argex);
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("ex:", ex);
                return BadRequest();
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            try
            {
                await _newsService.DeleteNews(id);
            }
            catch (ArgumentOutOfRangeException argsex)
            {
                _logger.LogError("argsex:", argsex);
                return BadRequest();
            }
            return NoContent();
        }
    }
}
