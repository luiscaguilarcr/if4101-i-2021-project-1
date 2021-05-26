using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_SPA.Models.EntitiesAPI;

namespace Project_SPA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsAPIController : ControllerBase
    {
        private readonly IF4101_SPA_APIContext _context;

        public CommentsAPIController(IF4101_SPA_APIContext context)
        {
            _context = context;
        }

        // GET: api/CommentsAPI
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            IEnumerable<Comment> comment = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44336/api/Comments/");
                    var responseTask = client.GetAsync("GetComments");
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Comment>>();
                        readTask.Wait();

                        comment = readTask.Result;
                    }
                    else
                    {
                        comment = Enumerable.Empty<Comment>();
                    }
                }
            }
            catch
            {

                ModelState.AddModelError(string.Empty, "Server error. Please contact an administrator");

            }

            return comment;
        }

        // GET: api/CommentsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/CommentsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Comment comment)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:44336/api/Comments/" + id);

                    var putTask = client.PutAsJsonAsync("student", comment);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return new JsonResult(result);
                    }
                }
            }
            catch (DbUpdateConcurrencyException exception)
            {
                return new JsonResult(exception);
            }

        }


        [Route("[action]")]
        [HttpPost]
        public JsonResult Post([FromBody] Comment comment)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44336/api/Comments/");
                    var postTask = client.PostAsJsonAsync("PostComment", comment);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return new JsonResult(result);
                    }
                }

            }
            catch (DbUpdateException exception)
            {
                return new JsonResult(exception);
            }

        }

        // DELETE: api/ApiWithActions/5
        [Route("[action]")]
        [HttpDelete]
        public JsonResult Delete([FromBody] int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44336/api/Comments/");

                var deleteTask = client.DeleteAsync("DeleteComment/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return new JsonResult(result);
                }
                else
                {
                    return new JsonResult(result);

                }
            }
        }
        
    }
}
