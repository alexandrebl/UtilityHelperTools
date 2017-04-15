using System;
using System.Diagnostics;

namespace UtilityHelperTools.Libraries {

    /// <summary>
    /// Impressão de dados no console
    /// </summary>
    public static class ConsoleLibrary {

        /// <summary>
        /// Evento
        /// </summary>
        public static event Action<string> EnvenWatchHandle;

        /// <summary>
        /// Define a cor do console
        /// </summary>
        /// <param name="consoleColor">cor do console</param>
        [Conditional("DEBUG")]
        public static void SetColor(ConsoleColor consoleColor) {
            //Define a cor
            Console.ForegroundColor = consoleColor;
        }

        /// <summary>
        /// Escreve uma mensagem no console
        /// </summary>
        /// <param name="message">mensagem</param>
        public static void Write(string message) {
            //Complementa os dados
            message = $"{DateTime.UtcNow:o}: {message}";

            //Chama o evento
            EnvenWatchHandle?.Invoke(message);
            //Mensagem
            PrintMessage(message);
        }

        /// <summary>
        /// Escreve uma mensagem no console
        /// </summary>
        /// <param name="message">mensagem</param>
        [Conditional("DEBUG")]
        private static void PrintMessage(string message) {
            //Imprime mensagem
            Console.WriteLine(message);
        }
    }
}