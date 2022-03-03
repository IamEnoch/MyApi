using System;
using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class Quote
    {
        //perform data validation using data annotation(adding extra meaning to the data by adding attribute tags)
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Desription { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
