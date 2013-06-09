/* Serializer.cs
 *
 * Copyright © 2013 by Adam Hellberg, Sijmen Schoon and Preston Shumway.
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.IO;
using Newtonsoft.Json;

namespace TriDevs.TriEngine.Serializing
{
    /// <summary>
    /// Provides serialization methods.
    /// </summary>
    public static class Serializer
    {
        private static readonly Lazy<JsonSerializer> JsonSerializer = new Lazy<JsonSerializer>();

        /// <summary>
        /// Serialize an object to string.
        /// </summary>
        /// <typeparam name="T">Type of data.</typeparam>
        /// <param name="data">Data to serialize.</param>
        /// <returns>The serialized object in string format.</returns>
        public static string Serialize<T>(T data)
        {
            // Create a StringWriter to hold the serialized object
            var writer = new StringWriter();
            // Serialize the object into the writer
            JsonSerializer.Value.Serialize(writer, data);
            return writer.ToString(); // Return the data as string
        }

        /// <summary>
        /// Serializes an object to file.
        /// </summary>
        /// <typeparam name="T">Type of the data.</typeparam>
        /// <param name="data">Data to serialize.</param>
        /// <param name="file">File to serialize to.</param>
        /// <param name="formatting">The formatting to use for the JSON output.</param>
        public static void Serialize<T>(T data, string file, Formatting formatting = Formatting.Indented)
        {
            // Create the StreamWriter
            using (var writer = new StreamWriter(file, false))
            {
                // Create the json writer
                using (var jsonWriter = new JsonTextWriter(writer){Formatting = formatting})
                {
                    // Now serialize the object to the file...
                    JsonSerializer.Value.Serialize(jsonWriter, data);
                    // ... and close the json writer
                    jsonWriter.Close();
                }
                // Finally, close the file writer
                writer.Close();
            }
        }

        /// <summary>
        /// Deserialize a serialized object from file.
        /// </summary>
        /// <typeparam name="T">Type of the object being deserialized.</typeparam>
        /// <param name="file">File to read from.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(string file)
        {
            T data;
            // Create the StreamReader
            using (var reader = new StreamReader(file))
            {
                // And the json reader
                using (var jsonReader = new JsonTextReader(reader))
                {
                    // Now deserialize the file to the requested object...
                    data = JsonSerializer.Value.Deserialize<T>(jsonReader);
                    // ... and close the json reader.
                    jsonReader.Close();
                }
                // Finally, close the file reader
                reader.Close();
            }
            return data;
        }
    }
}
