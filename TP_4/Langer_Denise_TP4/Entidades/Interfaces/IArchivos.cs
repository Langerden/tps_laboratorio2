namespace Entidades.Interfaces
{
    public interface IArchivos<T>
    {
        bool Guardar(T datos);

        bool Leer(out T datos);
    }
}
