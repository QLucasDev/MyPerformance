using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interface;
using System.Security.Cryptography;
using System.Text;

namespace API.Services
{
    public class HashProvider : IHash
    {
        private HashAlgorithm _algoritmo;

        public HashProvider(HashAlgorithm algoritmo)
        {
            _algoritmo = algoritmo;
        }

        public string Encrypt(string Password)
        {
            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(Password));

            var hashPassword = BitConverter.ToString(encryptedPassword).Replace("-", "");
            
            return hashPassword;
        }
        
        public bool Compare(string Password, string EncryptedPassword)
        {
            var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(Password));

            var hashPassword = BitConverter.ToString(encryptedPassword).Replace("-", "");

            return hashPassword == EncryptedPassword;
        }

    }
}