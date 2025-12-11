using CommAppAPI.Application.DTOs.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Validations.Contact
{
    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
        {
            RuleFor(x => x.PersonId).GreaterThan(0);
            RuleFor(x => x.Value).NotEmpty().WithMessage("İletişim bilgisi boş olamaz.");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Geçersiz Contact Type.");
        }
    }
}
