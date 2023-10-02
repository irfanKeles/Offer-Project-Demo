using FluentValidation;
using OfferProject.Models.Conctrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferProject.ValidationRules
{
    public class OfferAdminValidator: AbstractValidator<Offer>
    {
        public OfferAdminValidator()
        {
            RuleFor(x => x.City_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.Countries_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.Mode_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.MovementType_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.Currency_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.Unit1_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.Unit2_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.Incoterm_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.PackageType_ID).NotEmpty().WithMessage("Please Choose");
            RuleFor(x => x.User_ID).NotEmpty().WithMessage("Please Choose");
        }
    }
}