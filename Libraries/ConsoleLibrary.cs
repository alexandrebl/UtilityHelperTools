using System;
using System.Diagnostics;

namespace UtilityHelperTools.Libraries {

    /// <summary>
    /// Impressão de dados no console
    /// </summary>
    public static class ConsoleLibrary {

        /// <summary>
        /// Define se está em modo debug
        /// </summary>
        private static bool _isDebugMode;

        /// <summary>
        /// Evento
        /// </summary>
        public static event Action<string> EnvenWatchHandle;

        /// <summary>
        /// Define a cor do console
        /// </summary>
        /// <param name="consoleColor">cor do console</param>
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

            //Vefica se está em momo debug
            if (!_isDebugMode) PrintMessage(message);

            //Chama o evento
            EnvenWatchHandle?.Invoke(message);
        }

        /// <summary>
        /// Escreve uma mensagem no console
        /// </summary>
        /// <param name="message">mensagem</param>
        private static void PrintMessage(string message) {
            //Imprime mensagem
            Console.WriteLine(message);
        }

        /// <summary>
        /// Define o modo debug
        /// </summary>
        /// <param name="isDebugMode">flag</param>
        private static void SetDebugMode(bool isDebugMode) {
            //Define flag
            _isDebugMode = isDebugMode;
        }
    }
}