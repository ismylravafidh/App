using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Exceptions.Image
{
    public class ImageMaxLengthException : Exception
    {
        public ImageMaxLengthException():base("sekil 3mb-dan boyuk ola bilmez.")
        {
        }

        public ImageMaxLengthException(string? message) : base(message)
        {
        }
    }
}
