﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    public class Fluent_Author
    {
        [Key]
        public int Author_Id { get; set; }
        public string Location { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        [NotMapped]
        public string FullName {
            get
            {
                return $"{FirstName}{LastName}";
            }
        
        }
        //public List<Fluent_BookAuthorMap> BookAuthorMap { get; set;}
    }
}
