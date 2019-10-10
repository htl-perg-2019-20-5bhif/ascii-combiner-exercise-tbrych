using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AsciiArtCombiner
{
    public class AsciiArtReader
    {
        public string[] ReadFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"TestData\"+fileName);
                return lines;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening/reading file " + fileName);
                return null;
            }
        }

        public List<List<char>> CreateCharArray(string[] file)
        {
            List<List<char>> list = new List<List<char>>();

            foreach(var curLine in file)
            {
                char[] curCharLine = curLine.ToCharArray();
                List<char> chars = new List<char>(curCharLine);
                list.Add(chars);
            }

            return list;
        }
        
        public bool CheckSizes(List<List<List<char>>> files)
        {

            int length = 0, height = 0;
            bool first = true;
            foreach(var curFile in files)
            {
                bool valid = false;
                int curLenght = 0, curHeight = 0;
                (valid, curLenght, curHeight) = CheckSingleFileSizes(curFile);
                if (!valid)
                {
                    return false;
                }
                if (first)
                {
                    length = curLenght;
                    height = curHeight;
                }
                else
                {
                    if (length != curLenght || height != curHeight)
                    {
                        return false;
                    }
                }

                first = false;
            }
            return true;
        }

        private (bool, int, int) CheckSingleFileSizes(List<List<char>> curFile)
        {
            int height = 0;
            int length = 0;

            bool first = true;
            foreach(var curLine in curFile)
            {
                if (first)
                {
                    length = curLine.Count;
                }
                else
                {
                    if (length != curLine.Count)
                    {
                        return (false, -1, -1);
                    }
                }

                height++;
                first = false;
            }
            return (true, length, height);
        }
    }
}
