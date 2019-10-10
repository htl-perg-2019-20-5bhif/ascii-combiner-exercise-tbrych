using System;
using System.Collections.Generic;

namespace AsciiCombinerLogic
{
    public class MergePictures
    {
        public List<List<char>> Merge(List<List<List<char>>> files)
        {
            List<List<char>> result = files[0];

            for (int i = 1; i < files.Count; i++)
            {
                for (int j = 0; j < files[i].Count; j++)
                {
                    for (int k = 0; k < files[i][j].Count; k++)
                    {
                        if (!files[i][j][k].Equals(' '))
                        {
                            result[j][k] = files[i][j][k];
                        }
                    }
                }
            }
            return result;
        }
    }
}
