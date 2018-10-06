using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Choice
    {
        [Key]
        public int OptSerial { get; set; }
        public int ChapterNum { get; set; }
        public string Option { get; set; }
        public int NextChapNum { get; set; }
        public string Msg { get; set; }
    }
}
