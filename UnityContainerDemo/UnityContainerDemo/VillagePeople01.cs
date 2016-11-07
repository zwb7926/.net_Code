using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerDemo
{
    /// <summary>
    /// 村民
    /// </summary>
    public class VillagePeople01 : IPeople
    {
        IWaterTool _pw;
        public VillagePeople01(IWaterTool pw)
        {
            _pw = pw;
        }

        public void DrinkWater()
        {
            Console.WriteLine(_pw.returnWater());
        }
    }
}
