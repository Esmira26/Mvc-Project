using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication20.Models.Validator
{
    public class SignValidator : AbstractValidator<User>
    {
        public SignValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x=>x.UserPhone).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x=>x.UserEmail).NotEmpty().WithMessage("Boş ola bilməz");
            RuleFor(x=>x.UserPassword).NotEmpty().WithMessage("Boş ola bilməz");
        }
    }
}
