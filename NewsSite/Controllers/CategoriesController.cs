using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsSite.Context;
using NewsSite.Models.Categories;
using NewsSite.Models.Categories.CategoryServices;

namespace NewsSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService  _categoryService;
        private ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            try
            {
                var categories = _categoryService.GetCategoris();

                if (categories == null)
                {
                    _logger.LogInformation("No Category");
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError("exception:", ex);
                return BadRequest();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null)
                {
                    _logger.LogInformation("Category not found");
                    return BadRequest("Category not found");
                }
                return category;
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

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto categorydto)
        {
            if (id != categorydto.Id)
            {
                _logger.LogInformation(" Not  valid Id ");
                return BadRequest();
            }

            try
            {
                await _categoryService.UpdateCategory(categorydto, id);

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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryDto categorydto)
        {
            try
            {
                await _categoryService.AddCategory(categorydto);
                return CreatedAtAction("GetCategory", new { id = categorydto.Id }, categorydto);
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

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
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
