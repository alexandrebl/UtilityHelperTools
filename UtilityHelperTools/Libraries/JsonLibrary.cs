using Newtonsoft.Json.Linq;
using System;

namespace UtilityHelperTools.Libraries {

    /// <summary>
    /// Biblioteca de validação
    /// </summary>
    public static class JsonLibrary {

        /// <summary>
        /// Verify if is a valid json
        /// </summary>
        /// <param name="json">json data</param>
        /// <returns>success flag</returns>
        public static bool IsValidJson(string json) {
            try {
                //Parse data
                JObject.Parse(json);
                //Return
                return true;
            } catch (Exception) {
                //Return
                return false;
            }
        }
    }
}