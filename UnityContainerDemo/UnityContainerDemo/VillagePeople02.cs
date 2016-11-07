using Microsoft.Practices.Unity;
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
    public class VillagePeople02 : IPeople
    {
        [Dependency]
        public IWaterTool _pw { get; set; }

        public void DrinkWater()
        {
            Console.WriteLine(_pw.returnWater());
        }
    }
}
