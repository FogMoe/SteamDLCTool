using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_DLC_Tool
{
    internal class TheKey
    {
        //decode base64
        public static string DecodeBase64(string encoded)
        {
            byte[] data = Convert.FromBase64String(encoded);
            return Encoding.UTF8.GetString(data);
        }
        //encode base64
        public static string EncodeBase64(string decoded)
        {
            byte[] data = Encoding.UTF8.GetBytes(decoded);
            return Convert.ToBase64String(data);
        }
    }
}
