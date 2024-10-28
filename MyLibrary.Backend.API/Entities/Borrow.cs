using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibrary.Backend.API.bin.Base;

namespace MyLibrary.Backend.API.Entities
{
    public class Borrow : Thing
    {
        public DateTime BorrowTime { get; set; }
        public DateTime? RrturnTime { get; set; }
        public Book? Book { get; set; }
        public int BookId { get; set; }
        public Member? Member { get; set; }
        public int MemberId { get; set; }
    }
}