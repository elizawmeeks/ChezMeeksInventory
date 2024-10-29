using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public class Context : DbContext
    {
        public string DbPath { get; } = default!;

        public Context()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "chezmeeks.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data Source={DbPath}");

        internal DbSet<Item> Items { get; private set; } = default!;
        internal DbSet<Space> Spaces { get; private set; } = default!;
        internal DbSet<Room> Rooms { get; private set; } = default!;
    }
}