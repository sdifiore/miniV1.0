using Microsoft.EntityFrameworkCore;
using miniV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniV1.Persistence
{
    public class MiniDbContext : DbContext
    {
        public MiniDbContext(DbContextOptions<MiniDbContext> options) : base(options) { }
    }
}
