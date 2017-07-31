using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Utilities
{
    /// <summary>
    /// String utils class 
    /// </summary>
    public static class StringUtils
    {
        private static Char[] invalidChar = Path.GetInvalidFileNameChars();

        /// <summary>
        /// Given a file name, it return a safe file name that contains, for each invalid
        /// path char, a replace char.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="replaceChar"></param>
        /// <returns></returns>
        public static string ToSafeFileName(this string fileName, char replaceChar = '_')
        {
            var sb = new StringBuilder();
            foreach (var c in fileName)
            {
                if (invalidChar.Contains(c))
                    sb.Append(replaceChar);
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get the extension of a string, but if the string contains invalid chars, it 
        /// will always return correctly the extension.
        /// This is needed because webdav allows for char like "|" that are valid in the
        /// webdav path, but are not valid in windows like names.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static String GetFileExtensionSafe(this string fileName)
        {
            return Path.GetExtension(fileName.ToSafeFileName());
        }
    }
}
