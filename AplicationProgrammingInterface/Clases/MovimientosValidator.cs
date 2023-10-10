using AplicationProgrammingInterface.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using AplicationProgrammingInterface.Helpers;

namespace AplicationProgrammingInterface.Clases
{
    public class MovimientosValidator : AbstractValidator<ObjMovimientos>, IValidaciones<ObjMovimientos>
    {
        private readonly IUnitOfWork _unitOfWork;


        public MovimientosValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MovimientosValidator()
        {
            RuleFor(movimientos => movimientos.NumeroCuenta).NotEmpty().WithMessage("La cuenta es obligatorio");
            RuleFor(movimientos => movimientos.Tipo).NotEmpty().WithMessage("El tipo es obligatorio");
            RuleFor(movimientos => movimientos.Tipo).MaximumLength(15).WithMessage("El tipo debe tener como maximo 15 caracteres");
            RuleFor(movimientos => movimientos.Valor).NotEmpty().WithMessage("El valor es obligatorio");
            RuleFor(movimientos => movimientos.Valor).InclusiveBetween(1,9999999999).WithMessage("El Valor debe ser mayor a 0");

        }

        public bool ValidarRegistro(ObjMovimientos datos)
        {

           
                var cuenta = _unitOfWork.Cuenta.GetCuentabyNro(datos.NumeroCuenta);

                if (cuenta == null) { throw new ApplicationException("La cuenta no existe."); }


            if (datos.Tipo == EnumTipoCuentas.Retiro.GetDescription())
            {

                if (cuenta.Saldo < datos.Valor)
                {

                    throw new ApplicationException("El movimiento excede el saldo.");


                }




            }


                return true;
           

        }
    }
}
