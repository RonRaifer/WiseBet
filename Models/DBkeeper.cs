using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WiseBet.Models
{
    public class DBkeeper
    {
        public List<LottoNumbers> lottoNumbers { get; set; }
        public List<int> numAppearance2 { get; set; }
        public int[] numCommon { get; set; }
        public int[] numAppearance { get; set; }
        public int strongNumber { get; set; }
        public int[] strongArray { get; set; }
        public int lotteryNumber { get; set; }

        public double CheckChanceToWin(List<int> frenqArray)
        {
            double retValue = 1;
            foreach (var num in frenqArray)
            {
                retValue *= num / lotteryNumber;
            }
            return retValue;
        }
    }
}