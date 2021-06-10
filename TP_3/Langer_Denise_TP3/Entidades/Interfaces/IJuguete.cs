namespace Entidades.Interfaces
{
    public interface IJuguete<T> where T : Juguete
    {
        bool ValidarProduccion(T jugete, int cantidad);
        void AgregarList(T juguete);
    }
}
