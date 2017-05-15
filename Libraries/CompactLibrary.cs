using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace UtilityHelperTools.Libraries {

    /// <summary>
    /// Compact library
    /// </summary>
    public static class CompactLibrary {

        /// <summary>
        /// Compress data
        /// </summary>
        /// <param name="data">data to compress</param>
        /// <returns></returns>
        public static string Zip(string data) {
            //Compress
            var compressed = Compress(data);

            //Return
            return ByteArrayToString(compressed);
        }

        /// <summary>
        /// Decompress
        /// </summary>
        /// <param name="compressed">compressed data</param>
        /// <returns>result</returns>
        public static string UnZip(string compressed) {
            //Convertion
            var data = StringToByteArray(compressed);

            //Return
            return Decompress(data);
        }
        #region Métodos de compressão

        /// <summary>
        /// Compress
        /// </summary>
        /// <param name="stringToCompress">data to compress</param>
        /// <returns></returns>
        private static byte[] Compress(string stringToCompress) {
            //convertion
            var byteArray = Encoding.UTF8.GetBytes(stringToCompress);

            //Memory stream
            var memoryStream = new MemoryStream();

            //Compressing
            using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress)) {
                //Write compressed data
                gzipStream.Write(byteArray, 0, byteArray.Length);
            }

            //Return
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Decompress data
        /// </summary>
        /// <param name="stringToDecompress">data to decompress</param>
        /// <returns></returns>
        private static string Decompress(byte[] stringToDecompress) {
            //Data
            byte[] decompressedString;

            //Decomprss
            using (var gZipStream = new GZipStream(new MemoryStream(stringToDecompress), CompressionMode.Decompress)) {
                //Size
                const int size = 4096;

                //Data vector
                var byteArray = new byte[size];

                //Memory data
                using (var memory = new MemoryStream()) {
                    int count;

                    do {
                        //Read array
                        count = gZipStream.Read(byteArray, 0, size);

                        if (count > 0) {
                            //Write data
                            memory.Write(byteArray, 0, count);
                        }
                    }
                    while (count > 0);

                    decompressedString = memory.ToArray();
                }
            }
            //Return
            return Encoding.UTF8.GetString(decompressedString);
        }

        #endregion Métodos de compressão

        #region Conversão de Hexadecimal

        /// <summary>
        /// Convertion byte to array
        /// </summary>
        /// <param name="data">data do convert</param>
        /// <returns>result</returns>
        private static string ByteArrayToString(byte[] data) {
            //Verify if null
            if (data == null) throw new ArgumentNullException(nameof(data));

            var hex = new StringBuilder(data.Length * 2);
            foreach (var b in data)
                hex.AppendFormat("{0:x2}", b);

            //Return
            return hex.ToString();
        }

        /// <summary>
        /// Convert string to data array
        /// </summary>
        /// <param name="hex">message in hexa</param>
        /// <returns>result</returns>
        private static byte[] StringToByteArray(string hex) {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];

            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            //Return
            return bytes;
        }

        #endregion Conversão de Hexadecimal
    }
}