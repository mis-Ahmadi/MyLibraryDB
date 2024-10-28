using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibrary.Backend.API.bin.Base;

namespace MyLibrary.Backend.API.Entities
{
    public class Member : Thing
    {
        public string? Fullname { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}