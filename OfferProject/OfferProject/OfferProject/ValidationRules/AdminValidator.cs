using FluentValidation;
using OfferProject.Models.Conctrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferProject.ValidationRules
{
    public class AdminValidator: AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.userName).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.userName).MaximumLength(5).WithMessage("Cannot be longer than 5 characters");
            RuleFor(x => x.userName).MinimumLength(1).WithMessage("Cannot be shorter than 1 characters");

            RuleFor(x => x.password).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.password).MaximumLength(10).WithMessage("Cannot be longer than 10 characters");
            RuleFor(x => x.password).MinimumLength(1).WithMessage("Cannot be shorter than 1 characters");
        }
    }
}