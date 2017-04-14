using System.Collections.Generic;
using System.Data;

namespace UtilityHelperTools.Utilities.Interfaces {

    /// <summary>
    /// Interface de dados
    /// </summary>
    public interface IDataTableUtility {

        /// <summary>
        /// Utilitário de conversão
        /// </summary>
        /// <typeparam name="T">tipo</typeparam>
        /// <param name="data">dados</param>
        /// <returns></returns>
        DataTable AsDataTable<T>(IEnumerable<T> data);
    }
}