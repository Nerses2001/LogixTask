/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class KeyGenerator
    {
        public static string GenerateRandomKey(int keyLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var key = new char[keyLength];
            for (int i = 0; i < keyLength; i++)
            {
                key[i] = chars[random.Next(chars.Length)];
            }
            return new string(key);
        }
    }
}
*/