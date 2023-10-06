
using AplicationProgrammingInterface.Interfaces;
using Domain.Models;
using FluentValidation;


namespace AplicationProgrammingInterface.Clases
{
    public class ClienteValidator : AbstractValidator<ObjCliente>
    {

        public ClienteValidator()
        {
            RuleFor(persona => persona.Nombres).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(persona => persona.Nombres).MaximumLength(50).WithMessage("El nombre debe tener como maximo 50 caracteres");
            RuleFor(persona => persona.Direccion).NotEmpty().WithMessage("La direccion es obligatoria");
            RuleFor(persona => persona.Direccion).MaximumLength(50).WithMessage("La direccion debe tener como maximo 100 caracteres");
            RuleFor(persona => persona.Telefono).NotEmpty().WithMessage("El telefono es obligatorio");
            RuleFor(persona => persona.Telefono).MaximumLength(15).WithMessage("El telefono debe tener como maximo 15 caracteres");
            RuleFor(persona => persona.Contrasena).NotEmpty().WithMessage("La contraseña es obligatorio");
            RuleFor(persona => persona.Contrasena).MaximumLength(15).WithMessage("La contraseña debe tener como maximo 20 caracteres");
            RuleFor(persona => persona.Estado).NotEmpty().WithMessage("El estado es obligatorio");
          

        }

     
    }
}
