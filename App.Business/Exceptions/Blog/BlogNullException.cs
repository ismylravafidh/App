using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Exceptions.Blog
{
    public class BlogNullException : Exception
    {
        public BlogNullException():base("Blog Bos ola Bilmez")
        {
        }

        public BlogNullException(string? message) : base(message)
        {
        }
    }
}
