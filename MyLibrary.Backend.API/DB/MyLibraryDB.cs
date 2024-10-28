using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Backend.API.Entities;

namespace MyLibrary.Backend.API.DB
{
    public class MyLibraryDB : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public MyLibraryDB(DbContextOptions options)
        : base(options)
        {

        }

    }


}