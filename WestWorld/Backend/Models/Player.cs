using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Player
    {
        [Key]
        public string Name { get; set; }
        //public String Password { get; set; }          
    }
}
