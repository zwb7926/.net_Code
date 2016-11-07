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
    public class VillagePeople03 : IPeople
    {
        public IWaterTool tool;//我是对象引用
        public IWaterTool tool2;//我是参数
        public IWaterTool tool3;//我是返回值

        [InjectionMethod]
        public void DrinkWater()
        {
            if (tool == null)
            { }
        }

        [InjectionMethod]
        public void DrinkWater2(IWaterTool tool2)
        {
            this.tool2 = tool2;
        }

        [InjectionMethod]
        public IWaterTool DrinkWater3()
        {
            return tool3;
        }
    }
}
