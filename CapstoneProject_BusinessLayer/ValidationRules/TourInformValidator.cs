using CapstoneProject_EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class TourInformValidator : AbstractValidator<TourInform>
    {
        public TourInformValidator()
        {
            //Rulefore: kural tanımlamaya yarar.
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz!");
            RuleFor(x => x.Title).NotEmpty().MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz!");  

        }
    }
}
