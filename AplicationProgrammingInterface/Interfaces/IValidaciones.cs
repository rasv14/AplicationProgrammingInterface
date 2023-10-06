using Domain.Models;

namespace AplicationProgrammingInterface.Interfaces
{
    public interface IValidaciones<T>
    {

        bool ValidarRegistro(T datos);
    }
}



