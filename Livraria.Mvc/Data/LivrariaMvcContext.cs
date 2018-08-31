using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Mvc.Models
{
    public class LivrariaMvcContext : DbContext
    {
        public LivrariaMvcContext (DbContextOptions<LivrariaMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Livraria.Mvc.Models.EditoraViewModel> EditoraViewModel { get; set; }
    }
}
