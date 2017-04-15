using System;
using System.IO;
using UtilityHelperTools.Utilities.Interfaces;

namespace UtilityHelperTools.Utilities {

    /// <summary>
    /// Gereciador de arquivos
    /// </summary>
    public class FileManagerUtility : IFileManagerUtility {

        /// <summary>
        /// Diretório do arquivo
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="path">diretório de arquivos</param>
        public FileManagerUtility(string path) {
            //Define diretório
            _path = path;
        }

        /// <summary>
        /// Carrega arquivos
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        /// <returns></returns>
        public string LoadFileText(string fileName) {
            //Caminho completo
            var fullPath = $"{_path}/{fileName}";

            //Verifica se o arquivo existe
            if (!File.Exists(fullPath)) throw new Exception($"File not found: {fullPath}");

            //Ler os dados do arquivo
            var content = File.ReadAllText(fullPath);

            //Retorna dados do arquivo
            return content;
        }
    }
}