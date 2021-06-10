using System.Collections.Generic;

namespace Entidades.Interfaces
{
    public interface ISerializador<T>
    {
        bool Guardar<T>(List<T> datos);
        List<T> Leer<T>();
    }
}
