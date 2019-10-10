using System;
using System.Collections.Generic;
using AsciiCombinerLogic;

namespace AsciiArtCombiner
{
    class Program
    {
        static private AsciiArtReader reader = new AsciiArtReader();

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Wrong number of arguments! You need to specify at least 2 files");
            }
            else
            {
                List<string[]> files = ReadFiles(args);
                if (files == null)
                {
                    return;
                }

                List<List<List<char>>> charFiles = new List<List<List<char>>>();
                foreach(var curFile in files)
                {
                    charFiles.Add(reader.CreateCharArray(curFile));
                }

                bool sizes = reader.CheckSizes(charFiles);
                
                if (sizes)
                {
                    MergePictures merge = new MergePictures();
                    List<List<char>> result = merge.Merge(charFiles);

                    foreach(var curLine in result)
                    {
                        foreach(var curChar in curLine)
                        {
                            Console.Write(curChar + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Error: Files do not have the same size!");
                }
                
            }

        }

        static List<string[]> ReadFiles(string[] args)
        {
            List<string[]> files = new List<string[]>();

            foreach (string s in args)
            {
                string[] curFile = reader.ReadFile(s);
                if (curFile == null)
                {
                    return null;
                }
                files.Add(curFile);
            }

            return files;
        }
    }
}
