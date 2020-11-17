using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.XPath;
using WiseBet.Models;

namespace WiseBet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<LottoNumbers> lottoNumbers = new List<LottoNumbers>();
            XmlDocument lottery = new XmlDocument();
            lottery.Load(Server.MapPath("~/Content/xml/lotto1.xml")); //Load xml
            int[] numCommon = new int[7]; 
            int[] tempCommon = new int[38];     //37 numbers in array
            int[] tempStrong = new int[8];  //for strong number
            int strongNumber = 0, lotteryNumber = 0;
            //Loop through the selected Nodes.
            foreach (XmlNode node in lottery.SelectNodes("/lottery-data/lottery"))
            {

                //Fetch the Node values and assign it to Model.
                LottoNumbers lot = new LottoNumbers();
                lot.num1 = int.Parse(node["num1"].InnerText);
                lot.num2 = int.Parse(node["num2"].InnerText);
                lot.num3 = int.Parse(node["num3"].InnerText);
                lot.num4 = int.Parse(node["num4"].InnerText);
                lot.num5 = int.Parse(node["num5"].InnerText);
                lot.num6 = int.Parse(node["num6"].InnerText);
                lot.strongNumber = int.Parse(node["strong"].InnerText);
                lottoNumbers.Add(lot);
                lotteryNumber++;
                tempCommon[lot.num1]++; tempCommon[lot.num2]++; 
                tempCommon[lot.num3]++; tempCommon[lot.num4]++; 
                tempCommon[lot.num5]++; tempCommon[lot.num6]++;
                tempStrong[lot.strongNumber]++;
            }
            DBkeeper dbKeeper = new DBkeeper();
            dbKeeper.lottoNumbers = lottoNumbers;
            dbKeeper.numAppearance = tempCommon;
            dbKeeper.numAppearance2 = tempCommon.OfType<int>().ToList(); ;
            numCommon = LottoNumbers.FindKBiggestNumbers(tempCommon, 6);    //find 6 common numbers (1 to 38)
            strongNumber = LottoNumbers.FindStrongNumber(tempStrong);       //find strong number (1 to 7)

            dbKeeper.numCommon = numCommon;         //keep common numbers
            dbKeeper.strongNumber = strongNumber;   //keep strong number
            dbKeeper.lotteryNumber = lotteryNumber; //keep number of lotteries
            dbKeeper.strongArray = tempStrong;      //keep strong numbers appearance
            return View(dbKeeper);
        }

        public ActionResult WinChances(List<int> numbers, int lotteriesNum)
        {
            int i;
            float res= 2324784, calc;  //res initializes to the probability of choosing 6 numbers out of 37
            for (i = 0; i < 6; i++) 
            {
                calc = numbers[i];
                calc /= lotteriesNum;
                res *= calc;
            }   
            calc = numbers[i]; //Strong number
            calc /= lotteriesNum;
            calc *= 7;          //choosing 1 out of 7 numbers (for strong)
            res *= calc;
            res = (float)System.Math.Round(res, 2); //get result with 2 numbers after floating point
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}