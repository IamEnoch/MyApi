using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> _quotes = new List<Quote>()
        {
            new Quote(){Id = 0, Title = "Titel 1", Author = "John Doe", Desription = "Description 1"},
            new Quote(){Id = 1, Title = "Title 2", Author = "Author 2", Desription = "Desciption 2"}
        };

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Quote quote)
        {
            _quotes[id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _quotes.RemoveAt(id);
        }
    }
}
