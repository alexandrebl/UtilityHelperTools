namespace UtilityHelperTools.Utilities.Interfaces {

    /// <summary>
    /// Gereciador de arquivos
    /// </summary>
    public interface IFileManagerUtility {

        /// <summary>
        /// Carrega arquivos
        /// </summary>
        /// <param name="fileName">Nome do arquivo</param>
        /// <returns></returns>
        string LoadFileText(string fileName);
    }
}