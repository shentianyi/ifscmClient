using Brilliantech.MonoScmPrinter.ClientCL.RestApis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Brilliantech.MonoScmPrinter.ClientCL.Model;
using Brilliantech.MonoScmPrinter.ClientCL.IRestApis;

namespace Brilliantech.MonoScmPrinter.TestProject
{
    
    
    /// <summary>
    ///这是 RestDeliveryTest 的测试类，旨在
    ///包含所有 RestDeliveryTest 单元测试
    ///</summary>
    [TestClass()]
    public class RestDeliveryTest
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
        ///DnList 的测试
        ///</summary>
        [TestMethod()]
        public void DnListTest()
        {
            int staffId = 3; // TODO: 初始化为适当的值
            List<string> actual;
            IRestDelivery restDelivery = new RestDelivery();
            actual = restDelivery.DnList(staffId);
            foreach (string s in actual) {
                TestContext.WriteLine(s);
            }
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///RemoveFromPrintQueue 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveFromPrintQueueTest()
        {
            string dnKey = "DN2013012820571"; // TODO: 初始化为适当的值 
            ReturnMsg<string> actual;
            IRestDelivery restDelivery = new RestDelivery(); 
            actual = restDelivery.RemoveFromPrintQueue(dnKey);
            Assert.AreEqual(true, actual.result); 
        }

        ///// <summary>
        /////DnPackageList 的测试
        /////</summary>
        //[TestMethod()]
        //public void DnPackageListTest()
        //{
        //    string dnKey = "DN2013012820571"; // TODO: 初始化为适当的值 
        //    List<DeliveryPackage> actual;
        //    IRestDelivery restDelivery = new RestDelivery();
        //    actual = restDelivery.DnPackageList(dnKey);
        //    Assert.AreEqual(1, actual.Count); 
        //}

        /// <summary>
        ///DnItemList 的测试
        ///</summary>
        [TestMethod()]
        public void DnItemListTest()
        {
            string dnKey = "DN2013012820571"; // TODO: 初始化为适当的值 
            List<DeliveryItem> actual;
            IRestDelivery restDelivery = new RestDelivery();
            actual = restDelivery.DnItemList(dnKey);
            Assert.AreEqual(3, actual.Count); 
        }

        /// <summary>
        ///DnItemPrintData 的测试
        ///</summary>
        [TestMethod()]
        public void DnItemPrintDataTest()
        {
            string dnKey = "DN2013012820571"; // TODO: 初始化为适当的值
            string template = "Leoni_Nbtp_DPackTemplete.tff";
            PrintData actual;
            IRestDelivery restDelivery = new RestDelivery();
            actual = restDelivery.DnItemPrintData(dnKey,200);
            Assert.AreEqual(template, actual.template);
        }

        /// <summary>
        ///DnArrive 的测试
        ///</summary>
        [TestMethod()]
        public void DnArriveTest()
        {
            IRestDelivery target = new RestDelivery(); // TODO: 初始化为适当的值
            int orgId = 1; // TODO: 初始化为适当的值
            string dnKey = "DN130312B8"; // TODO: 初始化为适当的值 
            ReturnMsg<string> actual;
            actual = target.DnArrive(orgId, dnKey);
            Assert.AreEqual(false, actual.result);
            TestContext.WriteLine(actual.content);
        }
    }
}
