using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Core
{
    internal static class HMACSHA256Generator
    {
        #region Properties
        public static RandomNumberGenerator RandomNumberGenerator { get; } = RandomNumberGenerator.Create();
        #endregion

        #region Methods
        public static byte[] GetKey()
        {
            var keyBytes = new byte[16];
            RandomNumberGenerator.GetBytes(keyBytes);
            return keyBytes;
        }

        public static byte GetByte()
        {
            var bytes = new byte[1];
            RandomNumberGenerator.GetBytes(bytes);
            return bytes.First();
        }

        public static byte[] GetHMAC(byte[] key, byte[] buffer) => new HMACSHA256(key).ComputeHash(buffer);
        #endregion
    }
}
