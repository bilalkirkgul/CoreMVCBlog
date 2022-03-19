using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
   public class CategoryValidator: AbstractValidator<Category> 
    {
        public CategoryValidator()
        {
            RuleFor(a=>a.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez").MinimumLength(2).WithMessage("En az 2 Kakarater Girmelisiniz").MaximumLength(25).WithMessage("En fazla 25 karakter girmelisiiniz");
            RuleFor(a => a.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklama alanı Boş Geçilemez").MinimumLength(2).WithMessage("En az 2 Kakarater Girmelisiniz").MaximumLength(250).WithMessage("En fazla 250 karakter girmelisiiniz");


        }
    }
}
