using CommAppAPI.Application.DTOs.Person;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Validations.Person
{
    public class PersonCreateDtoValidator : AbstractValidator<PersonCreateDto>
    {
        public PersonCreateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş olamaz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş olamaz.");
            RuleFor(x => x.CompanyId).GreaterThan(0);
        }
    }
}
