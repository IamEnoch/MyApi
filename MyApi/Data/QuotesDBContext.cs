using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Data
{
    //Perform CRUD operation on the dataBase
    //Set a connection string in order to work with the database
    public class QuotesDBContext : DbContext
    {
        public QuotesDBContext(DbContextOptions<QuotesDBContext> options):base(options)
        {
            
        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
