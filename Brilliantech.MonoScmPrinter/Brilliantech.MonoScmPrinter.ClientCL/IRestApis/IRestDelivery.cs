using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.Model;

namespace Brilliantech.MonoScmPrinter.ClientCL.IRestApis
{
    public interface IRestDelivery
    {
        /// <summary>
        /// get delivery note list from print queue
        /// </summary>
        /// <param name="staffId">staff id</param>
        /// <returns>delivery note key list</returns>
        List<string> DnList(int staffId);

        /// <summary>
        /// remove delivery note key from print queue
        /// </summary>
        /// <param name="dnKey">delivery note key</param>
        /// <returns>remove result message</returns>
        ReturnMsg<string> RemoveFromPrintQueue(string dnKey);

        /// <summary>
        /// get delivery package list
        /// </summary>
        /// <param name="dnKey">delivery note key</param>
        /// <returns>delivery package list</returns>
        List<DeliveryPackage> DnPackageList(string dnKey);

        /// <summary>
        /// get delivery item list
        /// </summary>
        /// <param name="dnKey">delivery note key</param>
        /// <returns>delivery item list</returns>
        List<DeliveryItem> DnItemList(string dnKey);

        /// <summary>
        /// get delivery item print data
        /// </summary>
        /// <param name="dnKey">delivery note key</param>
        /// <returns>delivery item print data</returns>
        PrintData DnItemPrintData(string dnKey,int templateType);

        /// <summary>
        /// print delivery item by item keys
        /// </summary>
        /// <param name="diKeys">item keys</param>
        /// <returns>delivery item print data</returns>
        PrintData DnItemPrintData(string[] diKeys, int templateType);

        /// <summary>
        /// get pack model condition
        /// </summary>
        /// <returns></returns>
        List<EnumItem> ClientPackTemplate();
    }
}
