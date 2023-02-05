using CapstoneProject_EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            //Rulefore: kural tanımlamaya yarar.
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz!");
            RuleFor(x => x.Title).NotEmpty().MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz!");
            RuleFor(x => x.ShortDescription).NotEmpty().WithMessage("Kısa açıklama boş olamaz!");
            RuleFor(x => x.LongDescription).NotEmpty().WithMessage("Uzun açıklama boş olamaz!");
            
                
        }
    }
}
