using System.Threading;

namespace UtilityHelperTools.Libraries {

    /// <summary>
    /// Aumenta o número de threads
    /// </summary>
    public static class ThreadPollLibrary {

        /// <summary>
        /// Defini o número máximo de threads
        /// </summary>
        public static void SetThreadLimit() {
            //Workthreads
            int workerThreads;
            //Completation work thread
            int completionPortThreads;

            //Obtem o valor máximo
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            //Grava o valor máximo
            ThreadPool.SetMaxThreads(workerThreads, completionPortThreads);
            //Grava o valor mínimo
            ThreadPool.SetMinThreads(workerThreads, completionPortThreads);
        }
    }
}