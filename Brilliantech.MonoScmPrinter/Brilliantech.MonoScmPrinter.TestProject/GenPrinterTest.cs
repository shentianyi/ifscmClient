using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Brilliantech.ReportGenConnector;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;
using Brilliantech.MonoScmPrinter.ClientCL;
using System.IO;

namespace Brilliantech.MonoScmPrinter.TestProject
{
    
    
    /// <summary>
    ///这是 GenPrinterTest 的测试类，旨在
    ///包含所有 GenPrinterTest 单元测试
    ///</summary>
    [TestClass()]
    public class GenPrinterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GenPrinter 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void GenPrinterConstructorTest()
        {
            GenPrinter target = new GenPrinter();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///Print 的测试
        ///</summary>
        [TestMethod()]
        public void PrintTest()
        {
            string dnKey = "DN2013012820571";
            PrintData data;
            IRestDelivery restDelivery = new RestDelivery();
            data = restDelivery.DnItemPrintData(dnKey,200);

            IGenPrinter target = new GenPrinter();
            ReportGenConfig printerConfig = new ReportGenConfig()
            {
                NumberOfCopies = SettingConfig.Copy,
                Printer = SettingConfig.PrinterName,
                PrinterType = SettingConfig.PrinterType,
                Template = Path.Combine(SettingConfig.TemplatePath, data.template)
            };

            ReturnMsg<string> actual;
            actual = target.Print(data.dataset, printerConfig);
            Assert.AreEqual(true, actual.result);
        }
    }
}
