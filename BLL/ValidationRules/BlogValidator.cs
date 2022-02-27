using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
   public class BlogValidator: AbstractValidator<Blog> 
    {
        public BlogValidator()
        {
            RuleFor(a => a.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsinizi").MinimumLength(5).WithMessage("En az 5 karakter girmelisiniz").MaximumLength(25).WithMessage("en fazla 25 karakter girmelisiiniz");
            RuleFor(a => a.BlogContent).NotEmpty().WithMessage("Blog başlığını boş geçemezsinizi").WithMessage("En az 5 karakter girmelisiniz").MinimumLength(5).MaximumLength(250).WithMessage("en fazla 250 karakter girmelisiiniz"); ;
            RuleFor(a => a.BlogThumbnailImage).NotEmpty().WithMessage("Blog başlığını boş geçemezsinizi");
            RuleFor(a => a.BlogImage).NotEmpty().WithMessage("Blog başlığını boş geçemezsinizi");
            RuleFor(a => a.CategoryID).NotEmpty().WithMessage("Kategori seçimi zorunludur");
        }
    }
}
