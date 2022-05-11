﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularProject.Data;
using AngularProject.Models;
using AngularAPI.Services;
using AngularAPI.Models;
using System.Text.Json;
using AngularAPI.Dtos;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _repo;

        public CategoriesController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories([FromQuery] CategorySearchModel searchModel)
        {
           var categories = await _repo.GetAllCategorysAsync(searchModel);

            //PaginationMetaData paginationMetaData =
            //    new PaginationMetaData(categories.Count, searchModel.PageIndex,
            //    searchModel.PageSize);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));

            return categories.ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }


            try
            {
                await _repo.UpdateCategoryAsync(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
           
            await _repo.AddCategoryAsync(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _repo.DeleteCategoryAsync(category);

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _repo.IsCategoryExixtsAsync(id);
        }
    }
}