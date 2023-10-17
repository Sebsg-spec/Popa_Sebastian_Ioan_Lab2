using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Popa_Sebastian_Ioan_Lab2.Models;

namespace Popa_Sebastian_Ioan_Lab2.Data
{
    public class Popa_Sebastian_Ioan_Lab2Context : DbContext
    {
        public Popa_Sebastian_Ioan_Lab2Context (DbContextOptions<Popa_Sebastian_Ioan_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Popa_Sebastian_Ioan_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Popa_Sebastian_Ioan_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Popa_Sebastian_Ioan_Lab2.Models.Author>? Author { get; set; }
    }
}
