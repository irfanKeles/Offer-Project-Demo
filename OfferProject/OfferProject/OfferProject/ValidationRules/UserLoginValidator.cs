using FluentValidation;
using OfferProject.Models.Conctrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferProject.ValidationRules
{
    public class UserLoginValidator: AbstractValidator<Users>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.mail).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.mail).MaximumLength(70).WithMessage("Cannot be longer than 70 characters");
            RuleFor(x => x.mail).EmailAddress().WithMessage("Mail 'mail@xx.yy'must be in format");

            RuleFor(x => x.password).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(x => x.password).MaximumLength(20).WithMessage("Cannot be longer than 70 characters");
            RuleFor(x => x.password).MinimumLength(4).WithMessage("Cannot be shorter than 4 characters");
        }
    }
}