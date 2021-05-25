using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_SPA.Models.EntitiesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_SPA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsAPIController : ControllerBase
    {
        // GET: api/<NewsAPIController>
        [Route("[action]")]
        [HttpGet]
        public IEnumerable<News> Get()
        {
            IEnumerable<News> news = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44336/api/News/");//CAMBIAR URL
                    var responseTask = client.GetAsync("GetNews");
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<News>>();
                        readTask.Wait();
                        //lee los estudiantes provenientes de la API
                        news = readTask.Result;
                    }
                    else
                    {
                        news = Enumerable.Empty<News>();
                    }
                }
            }
            catch
            {

                ModelState.AddModelError(string.Empty, "Server error. Please contact an administrator");

            }

            return news;
        }

        // GET api/<NewsAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewsAPIController>
        [Route("[action]")]
        [HttpPost]
        public JsonResult Post([FromBody] News news)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44336/api/News/");
                    var postTask = client.PostAsJsonAsync("PostNews", news);
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

        // PUT api/<NewsAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
