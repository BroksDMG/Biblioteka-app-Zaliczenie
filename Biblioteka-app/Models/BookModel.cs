using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_app.Models
{
    
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        public string ProfilePictureURL { get; set; }
        [DisplayName("Tytuł")]
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [MaxLength(200)]
        public string BookName { get; set; }

        [DisplayName("strony")]
        [Required(ErrorMessage = "Pole strony jest wymagane")]
        public int Pages { get; set; }
        [DisplayName("edycja")]
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        public string Edition { get; set; }

        [DisplayName("Cena")]
        [Required(ErrorMessage = "Pole Cena jest wymagane")]
        public double Price { get; set; }

        //relationship

        public  int Cat_id { get; set; }
        [ForeignKey("Cat_id")]
        public CategoryModel CategoryModel { get; set; }


        public int A_id { get; set; }
        [ForeignKey("A_id")]
        public AuthorModel AuthorModel { get; set; }

        public int P_id { get; set; }
        [ForeignKey("P_id")]
        public PublisherModel PublisherModel { get; set; }
    }
}
