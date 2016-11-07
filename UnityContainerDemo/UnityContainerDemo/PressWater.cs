using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerDemo
{
    /// <summary>
    /// 压水井
    /// </summary>
    public class PressWater : IWaterTool
    {
        public string returnWater()
        {
            return "地下水好甜啊！！！";
        }
    }
}
