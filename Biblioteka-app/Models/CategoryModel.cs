using Biblioteka_app.Interfaces;
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
   
    public class CategoryModel : IEntityBase
    {  
        [Key]
        public int Id { get; set; }
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Pole categoria jest wymagane")]
        [MaxLength(50)]
        public string Catname { get; set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Pole Status jest wymagane")]
        [MaxLength(3)]
         public string Status { get; set; }
        //relationship
        [Required]
        public List<BookModel> Books { get; set; }
    }
        
    
}
