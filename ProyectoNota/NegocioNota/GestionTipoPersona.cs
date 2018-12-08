namespace NegocioNota
{
    using NegocioNota.Abstraccion;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GestionTipoPersona : ICrud
    {
        /// <summary>
        /// Este metodo realiza la actualizacion o modicación en la base de datos tabla (Por poner la tabla)
        /// </summary>
        /// <param name="_objectoActualizar"></param>
        /// <returns>retorna verdadero en caso de que la el registro se haya actualizado o modicado,
        /// retornara falso en caso de que el registro no se actualize o modifique</returns>
        public Task<bool> Actualizar(object _objectoActualizar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este metodo realiza la deshabilitación del registro en la base de datos tabla (Por poner la tabla)
        /// </summary>
        /// <param name="_guid"></param>
        /// <returns>Retorna verdadero en caso de que el registro se deshabilite correctamente o falso en caso de que no se deshabilite correctamente</returns>
        public Task<bool> Eliminar(string _guid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este metodo realiza el guardado del registro en la base datos tabla(Por poner la tabla)
        /// </summary>
        /// <param name="_objectoGuardar"></param>
        /// <returns>Retorna verdadero en caso de que la tabla se guarde correctamente o falso en caso de que la tabla no se haya guardado correctamente</returns>
        public Task<bool> Guardar(object _objectoGuardar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este metodo realiza la obtención de un registro en la base de datos tabla(Po ner la tabla)
        /// </summary>
        /// <returns>Retonar el objeto obtenido en este caso de tipo TipoPersonaDto</returns>
        public Task<object> Obtener(string _guid)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Este metodo realiza la obtención de un listado de registros en la base de datos tabla(Por poner la tabla)
        /// </summary>
        /// <returns>Retornar una lista de objetos en este caso una lista de TipoPersonaDto</returns>
        public Task<object> ObtenerLista()
        {
            throw new NotImplementedException();
        }
    }
}
