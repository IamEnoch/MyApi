using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System.Collections.Generic;
using MyApi.Data;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDBContext _quotesDbContext;

        public QuotesController(QuotesDBContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }


        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotesDbContext.Quotes;
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
