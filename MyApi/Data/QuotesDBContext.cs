using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
{
    //Perform CRUD operation on the dataBase
    //Set a connection string in order to work with the database
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options):base(options)
        {
            
        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
