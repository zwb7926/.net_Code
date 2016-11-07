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
    public class VillagePeople04 : IPeople
    {
        IWaterTool _pw;
        public VillagePeople04(IWaterTool pw)
        {
            _pw = pw;
        }

        public void DrinkWater()
        {
            Console.WriteLine(_pw.returnWater());
        }
    }
}
