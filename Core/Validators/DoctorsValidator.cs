using Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class DoctorsValidator : AbstractValidator<CreateDoctorDto>
    {
        public DoctorsValidator()
        {
            RuleFor(x => x.Name)
                   .NotEmpty()
                   .MinimumLength(2)
                   .Matches("[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");
            //RuleFor(x => x.Discount)
            //    .InclusiveBetween(0, 100);
            //RuleFor(x => x.Price).GreaterThanOrEqualTo(10);
            //RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            //RuleFor(x => x.Description)
            //    .MaximumLength(1000);
            //RuleFor(x => x.ImageUrl)
            //.Must(LinkMustBeAUri).WithMessage("Image url address must be valid.");
        }
    }
}
