using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.ViewModels.BlogVms
{
    public class BlogCreateVm
    {
        public string BlogName { get; set; }
        public string BlogDescription { get; set;}
        public string? ImgUrl { get; set;}
        public IFormFile? ImageFile { get; set;}
    }
    public class BlogCreateVmValidation : AbstractValidator<BlogCreateVm>
    {
        public BlogCreateVmValidation()
        {
            RuleFor(x => x.BlogName)
                .NotEmpty()
                .WithMessage("BlogName Bos ola bilmez.")
                .MaximumLength(25)
                .WithMessage("BlogName-in uzunlugu Maximum 25 ola biler.");
            RuleFor(x => x.BlogDescription)
                .NotEmpty()
                .WithMessage("BlogDescription Bos ola bilmez.")
                .MaximumLength(25)
                .WithMessage("BlogDescription-in uzunlugu Maximum 150 ola biler.");
        }
    }
}
