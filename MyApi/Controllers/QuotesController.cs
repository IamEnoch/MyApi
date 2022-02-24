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
        public IActionResult Get()
        {
            return Ok(_quotesDbContext.Quotes);
        }

        //Get: a particular quote
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("Item not found");
            }
            else
            {
                return Ok(quote);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {

            var _quote = _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Quote quote)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            if (entity == null)
            {
                return NotFound("No record found against this id....");
            }
            else
            {
                entity.Title = quote.Title;
                entity.Author = quote.Author;
                entity.Desription = quote.Desription;
                _quotesDbContext.SaveChanges();
                return Ok("Record created successfully");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            if (entity == null)
            {
                return NotFound("Quote against that id is not found.....");
            }
            else
            {
                _quotesDbContext.Quotes.Remove(entity);
                _quotesDbContext.SaveChanges();
                return Ok("Quote created successfully");
            }
        }
    }
}
