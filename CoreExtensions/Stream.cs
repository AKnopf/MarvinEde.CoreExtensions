using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IOStream = System.IO.Stream;

namespace MarvinEde.CoreExtensions
{
    /// <summary>
    /// Holds extensions for <see cref="IOStream"/>
    /// </summary>
    public static class Stream
    {
        /// <summary>
        /// Reads the whole stream into a byte array.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadBytes(this IOStream stream)
        {
            byte[] buffer = new byte[stream.Length];
            using (var memoryStream = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, read);
                }
                return memoryStream.ToArray();
            }
        }
    }
}
