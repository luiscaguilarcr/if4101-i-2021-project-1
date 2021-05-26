using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly IF4101_SPA_APIContext _context;

        public NewsController()
        {
            _context = new IF4101_SPA_APIContext();
        }

        // GET: api/News/Get
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews() //revisar con la del profe falta el include
        {
            return await _context.News.ToListAsync();
        }

        // GET api/News/5
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<News>> GetNew(int id)
        {
            var view = await _context.News.FindAsync(id);

            if (view == null)
            {
                return NotFound();
            }

            return view;
        }

        // POST api/News
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNew", new { id = news.Id }, news);
        }

        // PUT api/<ViewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ViewsController>/5

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return news;
        }
    }
}
