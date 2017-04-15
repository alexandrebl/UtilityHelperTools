namespace UtilityHelperTools.Libraries {

    /// <summary>
    /// Injeção de dependência
    /// </summary>
    public static class DependencyInjectionLibrary<T> where T : new() {

        /// <summary>
        /// Instância
        /// </summary>
        private static T _instance;

        /// <summary>
        /// Objeto de sincronismo
        /// </summary>
        private static readonly object SyncObj = new object();

        /// <summary>
        /// Método para obter a instância
        /// </summary>
        /// <returns></returns>
        public static T GetContainerInstance() {
            //Verifica se o objeto já existe
            if (_instance != null) return _instance;
            //Efetua o lock do objeto
            lock (SyncObj) {
                //Verifica se o objeto já existe
                if (_instance == null) {
                    //Inicializa a variáel
                    return _instance = new T();
                }
            }

            //Retorno
            return _instance;
        }
    }
}