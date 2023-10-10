namespace AplicationProgrammingInterface.Interfaces
{
    public interface IEntidadesService<T>
    {
        T Registrar(T datos);

        T Actualizar(T datos);
    }
}
