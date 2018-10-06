using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Story
    {
        [Key]
        public int SentenceCount { get; set; }
        public int ChapterNum { get; set; }
        public string Lines { get; set; }
    }
}
