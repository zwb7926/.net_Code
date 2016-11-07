using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;

namespace UnityContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            FuTest02();
            Console.ReadKey();
        }

        public static void FuTest01()
        {
            UnityContainer container = new UnityContainer();//创建容器
            container.RegisterType<IWaterTool, PressWater>();//注册依赖对象
            IPeople people = container.Resolve<VillagePeople01>();//返回调用者
            
            people.DrinkWater();//喝水
        }
        /// <summary>
        /// 通过配置文件配置
        /// </summary>
        public static void FuTest02()
        {
            UnityContainer container = new UnityContainer();//创建容器
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            configuration.Configure(container, "defaultContainer");//注册依赖对象
            IPeople people = container.Resolve<IPeople>();//返回调用者
            people.DrinkWater();//喝水
        }
        public static void FuTest03()
        {
            UnityContainer container = new UnityContainer();//创建容器
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            configuration.Configure(container, "defaultContainer");
            VillagePeople03 people = container.Resolve<IPeople>() as VillagePeople03;//返回调用者
            Console.WriteLine("people.tool == null（引用） ? {0}", people.tool == null ? "Yes" : "No");
            Console.WriteLine("people.tool2 == null（参数） ? {0}", people.tool2 == null ? "Yes" : "No");
            Console.WriteLine("people.tool3 == null（返回值） ? {0}", people.tool3 == null ? "Yes" : "No");
        }
        public static void FuTest04()
        {
            UnityContainer container = new UnityContainer();//创建容器
            container.RegisterType(typeof(IWaterTool), typeof(PressWater));//注册依赖对象
            IPeople people = (IPeople)container.Resolve(typeof(VillagePeople01));//返回调用者
            people.DrinkWater();//喝水
        }
        public static void FuTest05()
        {
            UnityContainer container = new UnityContainer();//创建容器
            container.RegisterType<IWaterTool, PressWater>("WaterTool1");//注册依赖对象WaterTool1
            container.RegisterType<IWaterTool, PressWater>("WaterTool2");//注册依赖对象WaterTool2

            IWaterTool wt = container.Resolve<IWaterTool>("WaterTool1");//返回依赖对象WaterTool1
            var list = container.ResolveAll<IWaterTool>();//返回所有注册类型为IWaterTool的对象
            Console.WriteLine(wt.returnWater());
        }
        public static void FuTest07()
        {
            UnityContainer container = new UnityContainer();//创建容器
            container.RegisterType<IWaterTool, PressWater>(new ContainerControlledLifetimeManager());//注册依赖对象
            IPeople people = container.Resolve<VillagePeople01>();//返回调用者
            people.DrinkWater();//喝水
            PressWater pw = new PressWater();
            container.RegisterInstance<IWaterTool>(pw);
        }
        public static void FuTest08()
        {
            UnityContainer container = new UnityContainer();//创建容器
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            configuration.Configure(container, "defaultContainer");
            IPeople people = container.Resolve<IPeople>();//返回调用者
            people.DrinkWater();//喝水
        }
    }
}
