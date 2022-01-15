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
    [Table("Author")]
    public class AuthorModel
    {
        [HiddenInput]
        [Key]
        public int AuthorId { get; set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage ="Pole Imię jest wymagane")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [MaxLength(50)]
        public string Surname { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "Pole Adres jest wymagane")]
        [MaxLength(200)]
        public string Address { get; set; }
        [DisplayName("Telefon")]
        [Phone]
        [Required(ErrorMessage = "Pole telefon jest wymagane")]
        public string phone { get; set; } 
    }
}
