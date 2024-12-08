using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Backend.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyLibrary.Backend.API.DB
{
    public class MyLibraryDB : IdentityDbContext<LibraryUser>
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