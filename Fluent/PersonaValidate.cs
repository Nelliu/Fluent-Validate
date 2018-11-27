using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Fluent
{
    class PersonaValidate : AbstractValidator<Persona>
    {
        public PersonaValidate()
        {
            RuleFor(persona => persona.Name).NotEmpty().Matches("([A-z])").WithMessage("Field empty or uses numbers");
          
            RuleFor(persona => persona.LastName).NotEmpty().Matches("([A-z])").NotEqual(persona => persona.Name).WithMessage("Names can't be same and can be characters only!");

            RuleFor(persona => persona.BirthDate).NotEmpty().WithMessage("Date couldn't be null!");
        }

       


    }
}
