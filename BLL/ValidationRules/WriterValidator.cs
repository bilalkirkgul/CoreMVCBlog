using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(a => a.WriterName).NotEmpty().WithMessage("İsim Soyisim boş geçilemez");
            RuleFor(a => a.WriterMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
            RuleFor(a => a.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(a => a.WriterName).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz").MaximumLength(20).WithMessage("En fazla 20 karakter girebilirsiniz");
        }

    }
}
