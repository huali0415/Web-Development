using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Chapter
    {
		[Key]
        public int ChapterNum { get; set; }
		public string ChapterName { get; set; }
        public string HostName { get; set; }		
	}
}
