using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Record
    {
        [Key]		
        public int RecordNum { get; set; }
        public String PlayerName { get; set; }
		public int ChapterNum { get; set; }

    }
}
