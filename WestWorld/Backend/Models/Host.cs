using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Host
    {
		[Key]
        public int ChapterNum { get; set; }
        public string HostName { get; set; }
        public string Image { get; set; }
        public Boolean IsHostAlive { get; set; }
	}
}
