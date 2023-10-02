using FluentValidation;
using OfferProject.Models.Conctrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferProject.ValidationRules
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Please do not leave blank");
            RuleFor(x => x.name).MinimumLength(3).WithMessage("name cannot be shorter than 3 characters.");
            RuleFor(x => x.name).MaximumLength(100).WithMessage("name cannot be longer than 100 characters.");
            RuleFor(x => x.surname).NotEmpty().WithMessage("Please do not leave blank");
            RuleFor(x => x.surname).MinimumLength(3).WithMessage("surname cannot be shorter than 3 characters.");
            RuleFor(x => x.surname).MaximumLength(100).WithMessage("surname cannot be longer than 100 characters.");
            RuleFor(x => x.mail).MaximumLength(70).WithMessage("Mail cannot be longer than 70 characters.");
            RuleFor(x => x.mail).NotEmpty().WithMessage("Please do not leave blank");
            RuleFor(x => x.mail).EmailAddress().WithMessage("mail '@' must be in format");
            RuleFor(x => x.password).NotEmpty().WithMessage("Please do not leave blank");
            RuleFor(x => x.password).MinimumLength(4).WithMessage("password cannot be shorter than 3 characters.");
            RuleFor(x => x.password).MaximumLength(20).WithMessage("password cannot be longer than 20 characters.");
        }
    }
}