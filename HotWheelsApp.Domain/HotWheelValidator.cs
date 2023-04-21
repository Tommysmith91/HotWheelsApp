using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotWheelsApp.Domain
{
    public class HotWheelValidator : AbstractValidator<HotWheel>
    {
        public HotWheelValidator() 
        {
            RuleFor(hotwheel => hotwheel).NotNull().WithMessage("No Data Provided");
            RuleFor(hotwheel => hotwheel.ModelName).NotNull().NotEmpty().WithMessage("Invalid Model Name");
            RuleFor(hotwheel => hotwheel.ImageUrl).NotEmpty().Must(BeAValidUrl).WithMessage("Invalid Url");
        }

        private bool BeAValidUrl(string arg)
        {
            return Uri.TryCreate(arg, UriKind.Absolute, out _);
        }
    }
}
