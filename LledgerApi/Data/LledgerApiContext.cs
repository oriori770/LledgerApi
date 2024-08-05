using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LledgerApi.Models;

namespace LledgerApi.Data
{
    public class LledgerApiContext : DbContext
    {
        public LledgerApiContext (DbContextOptions<LledgerApiContext> options)
            : base(options)
        {
        }

        public DbSet<LledgerApi.Models.User> User { get; set; } = default!;
        public DbSet<LledgerApi.Models.Ledger> Group { get; set; } = default!;
        public DbSet<LledgerApi.Models.LedgersMember> LedgersMember { get; set; } = default!;
    }
}
