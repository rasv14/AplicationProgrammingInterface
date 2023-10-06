using AplicationProgrammingInterface.Interfaces;
using FluentValidation;

namespace AplicationProgrammingInterface.Clases
{
    public class CuentaValidator : AbstractValidator<ObjCuenta>
    {

        public CuentaValidator()
        {
            RuleFor(cuenta => cuenta.Numero).NotEmpty().WithMessage("La cuenta es obligatorio");
            RuleFor(cuenta => cuenta.Numero.ToString()).MaximumLength(6).WithMessage("La cuenta debe tener como maximo 6 caracteres");
            RuleFor(cuenta => cuenta.Tipo).NotEmpty().WithMessage("El tipo es obligatorio");
            RuleFor(cuenta => cuenta.Tipo).MaximumLength(15).WithMessage("El tipo debe tener como maximo 10 caracteres");
            RuleFor(cuenta => cuenta.Estado).NotEmpty().WithMessage("El estado es obligatorio");      
            RuleFor(cuenta => cuenta.IdCliente).NotEmpty().WithMessage("El Id del Cliente es obligatorio");
           


        }


    }
}
