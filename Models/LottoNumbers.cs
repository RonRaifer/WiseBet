using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WiseBet.Models
{
    public class LottoNumbers
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int num5 { get; set; }
        public int num6 { get; set; }
        public int strongNumber { get; set; }

        public static int[] FindKBiggestNumbers(int[] testArray, int k)
        {
            int[] result = new int[k];
            int[] common = new int[k];
            for (int i = 0; i < testArray.Length; i++)
            {
                //if bigger than the smallest node
                if (testArray[i] <= result[0])
                {
                    continue;
                }
                else
                {
                    //if bigger than all?
                    if (testArray[i] > result[k - 1])
                    {
                        for (int l = 0; l < k - 1; l++)
                        {
                            result[l] = result[l + 1];
                        }
                        result[k - 1] = testArray[i];
                        common[k - 1] = i;
                    }
                    else
                    {
                        //binary search
                        int indexLeft = 0;
                        int indexRight = k - 1;

                        int currIndex = (indexRight + indexLeft) / 2; ;
                        //10 20 30 40 50 - > place 33 
                        while (indexRight - indexLeft > 1)
                        {

                            if (testArray[i] >= result[currIndex])
                            {
                                indexLeft = currIndex;
                            }
                            else
                            {
                                indexRight = currIndex;
                            }
                            currIndex = (indexRight + indexLeft) / 2;
                        }

                        for (int l = 0; l < currIndex; l++)
                        {
                            result[l] = result[l + 1];
                            common[l] = common[l + 1];
                        }
                        result[currIndex] = testArray[i];
                        common[currIndex] = i;
                    }
                }
            }

            return common;
        }

        public static int FindStrongNumber(int[] strongArr)
        {
            int strong = 0, min, max = 0;
            for (int i = 1; i < strongArr.Length; i++)
            {
                min = strongArr[i];
                if (max < min)
                {
                    max = min;
                    strong = i;
                }
            }
            return strong;
        }
    }
}