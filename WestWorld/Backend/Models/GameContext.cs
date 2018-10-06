using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class GameContext : DbContext
    {
        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }
		
        public DbSet<backend.Models.Player> Players { get; set; }
        public DbSet<backend.Models.Record> Records { get; set; }
        public DbSet<backend.Models.Host> Hosts { get; set; }
        public DbSet<backend.Models.Chapter> Chapters { get; set; }
        public DbSet<backend.Models.Story> Stories { get; set; }
        public DbSet<backend.Models.Choice> Choices { get; set; }
	}
}
