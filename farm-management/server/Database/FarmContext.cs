using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace server.Database
{
    public class FarmContext : DbContext
    {
        public required DbSet<AnimalEntity> Animals { get; set; }

        public FarmContext(DbContextOptions<FarmContext> options) : base(options)
        {
        }
    }
}