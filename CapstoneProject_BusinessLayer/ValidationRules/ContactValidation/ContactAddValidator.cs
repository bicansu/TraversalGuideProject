using CapstoneProject_DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules.ContactAddValidator
{
    public class ContactAddValidator : AbstractValidator<ContactAddDto>
    {
        public ContactAddValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Mesaj boş geçilemez");
            RuleFor(x => x.NameSurname).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("Lütfen ez fazla 100 karakter giriniz.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen ez fazla 100 karakter giriniz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez.");
        
        }
    }
}
