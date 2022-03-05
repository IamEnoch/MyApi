﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;
using MyApi.Data;

namespace MyApi.Controllers
{
    //controller handles incoming http requests and sends response back to the caller
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbContext _quotesDbContext;

        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }

        //Get all quotes
        [HttpGet]
        public IActionResult Get(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "desc":
                    quotes = _quotesDbContext.Quotes.OrderByDescending(p => p.CreatedAt);
                    break;
                case "asc":
                    quotes = _quotesDbContext.Quotes.OrderBy(p => p.CreatedAt);
                    break;
                default:
                    quotes = _quotesDbContext.Quotes;
                    break;
            }

            return Ok(quotes);
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

        //Decorated the test method with a HttpGet attribute and changed the route by adding the action token in order not to conflict with 
        //the get method
        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {

            _quotesDbContext.Quotes.Add(quote);
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
