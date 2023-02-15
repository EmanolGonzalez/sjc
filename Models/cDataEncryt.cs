using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace sjc
{
    public class cDataEncryt
    {
        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
        public string traerToken()
        {
            return GenerateToken();
        }


        private string GetSha256(String str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}",stream[i]);
            return sb.ToString();
        }

        public string traerSHA256(string str)
        {
            return GetSha256(str);
        }
    }
}