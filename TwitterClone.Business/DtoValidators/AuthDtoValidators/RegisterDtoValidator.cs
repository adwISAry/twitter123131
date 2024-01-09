using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;

namespace TwitterClone.Business.DtoValidators.AuthDtoValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Fullname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64);
            RuleFor(r => r.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(52);
            RuleFor(r => r.BirthDate)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.Now.AddYears(-18))
                    .WithMessage("Not old enough for this.")
                .GreaterThan(DateTime.Now.AddYears(-76))
                    .WithMessage("Not young enough for this.");
            RuleFor(r => r.Email)
                .NotEmpty()
                .NotNull()
                /*.Must(r => MailAddress.TryCreate(r, out _))*/
                .EmailAddress();
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$")
                    .WithMessage("Password must contain: digit, at least 1 lower case and 1 upper case letters, minimum length of 6.");
        }
    }
}
