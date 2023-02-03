using CapstoneProject_DTOLayer.DTOs.TravelAgencyDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class TraveAgencyValidator : AbstractValidator<TravelAgencyDTO>
    {
        public TraveAgencyValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
        }
    }
}
