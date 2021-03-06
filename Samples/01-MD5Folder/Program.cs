﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace ActorsLifeForMe.MD5Folder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready to start.");
            Console.ReadLine();

            ProcessFolder(@"c:\iPlayer\DDDNorth");

            Console.WriteLine("Completed.");
            Console.ReadLine();
        }

        private static void ProcessFolder(string folder)
        {
            var files = System.IO.Directory.GetFiles(folder);
            foreach (var filepath in files)
            {
                Console.WriteLine("Begin {0} ", Path.GetFileName(filepath).Substring(0, 30));
                Console.WriteLine("End {0} : {1}", Path.GetFileName(filepath).Substring(0, 30), MD5FromFile(filepath));
                Console.WriteLine();
            }
        }

        private static string MD5FromFile(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }
    }
}
