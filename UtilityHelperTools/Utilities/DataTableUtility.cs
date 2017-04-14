using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using UtilityHelperTools.Utilities.Interfaces;

namespace UtilityHelperTools.Utilities {

    /// <summary>
    /// Utilitário de dados
    /// </summary>
    public class DataTableUtility : IDataTableUtility {

        /// <summary>
        /// Utilitário de conversão
        /// </summary>
        /// <typeparam name="T">tipo</typeparam>
        /// <param name="data">dados</param>
        /// <returns></returns>
        public DataTable AsDataTable<T>(IEnumerable<T> data) {
            //Propriedade
            var properties = TypeDescriptor.GetProperties(typeof(T));
            //Tabela
            var table = new DataTable();

            //Acessa a cada item da coleção
            foreach (PropertyDescriptor prop in properties) table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            //Acessa a cada item da coleção
            foreach (T item in data) {
                //Objeto de linha
                DataRow row = table.NewRow();
                //Acessa a cada item da coleção
                foreach (PropertyDescriptor prop in properties) row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                //Adiciona a nova linha
                table.Rows.Add(row);
            }

            //Retorno
            return table;
        }
    }
}