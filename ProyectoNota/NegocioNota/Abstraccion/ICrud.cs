namespace NegocioNota.Abstraccion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrud
    {
        #region Metodos de la Interfaz ICrud
        Task<bool> Guardar(object _objectoGuardar);
        Task<bool> Actualizar(object _objectoActualizar);
        Task<bool> Eliminar(string _guid);
        Task<object> Obtener(string _guid);
        Task<object> ObtenerLista(); 
        #endregion
    }
}
