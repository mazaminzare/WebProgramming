﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Security
{
    public static class PasswordHelper
    {
        public static string EncodePasswordMD5(string pass) 
        {
            Byte[] originalBytes;
            Byte[] encodeBytes;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodeBytes = md5.ComputeHash(originalBytes);   
            return BitConverter.ToString(encodeBytes);
        }
        

    }
}
