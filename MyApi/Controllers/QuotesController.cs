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

        //Get all quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotesDbContext.Quotes;
        }

        //Get: a particular quote
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            return quote;
        }

        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Quote quote)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Desription = quote.Desription;
            _quotesDbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Quotes.Remove(entity);
            _quotesDbContext.SaveChanges();
        }
    }
}
