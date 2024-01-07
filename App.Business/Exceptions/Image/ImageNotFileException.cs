using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Exceptions.Image
{
    public class ImageNotFileException : Exception
    {
        public ImageNotFileException():base("Image Formatinda Deyil")
        {
        }

        public ImageNotFileException(string? message) : base(message)
        {
        }
    }
}
