using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Exceptions.Blog
{
    public class BlogNotFoundException : Exception
    {
        public BlogNotFoundException() : base("Bele Bir Blog Tapilmadi")
        {
        }

        public BlogNotFoundException(string? message) : base(message)
        {
        }
    }
}
