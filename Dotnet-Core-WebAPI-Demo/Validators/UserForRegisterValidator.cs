using Dotnet_Core_WebAPI_Demo.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Validators
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        ValidatorHelper validatorHelper = ValidatorHelper.GetInstance;
        public UserForRegisterValidator()
        {
            RuleFor(user => user.Username).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().NotNull().WithMessage("This is a required field.")
                .MinimumLength(3).WithMessage("User name must be greater than 3 characters")
                .Must(validatorHelper.BeAValidName).WithMessage("Username contains invalid characters");

            RuleFor(user => user.Email).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().NotNull().WithMessage("This is a required field!")
                .EmailAddress().WithMessage("Invalid email");

            RuleFor(user => user.Password).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().NotNull().WithMessage("This is a required field.")
                .MinimumLength(4).WithMessage("Password must be atleast 4 characters.")
                .MaximumLength(50).WithMessage("Password must be less than or equal to 50 characters.");
        }
    }
}