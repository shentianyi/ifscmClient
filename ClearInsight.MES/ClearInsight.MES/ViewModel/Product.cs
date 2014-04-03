using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearInsight.MES.ViewModel
{
    public class Product : EntityBase
    {
        public string Nr { get; set; }
        public string Type { get; set; } 
    }
    public class ContractProduct : Product
    {
        private static Random r = new Random();
        public string Value { get; set; }
        public string Unit
        {
            get
            {
                return units[r.Next(0, 3)];
            } 
        }

        private static List<string> units = new List<string>() { "百万", "万", "千" };
        public static List<ContractProduct> GetSource()
        {
            Random r = new Random();
            int count = r.Next(3, 10);
            List<ContractProduct> contract_products = new List<ContractProduct>();
            for (int i = 0; i < count; i++)
            {
                contract_products.Add(new ContractProduct() { 
                    Nr = "PRO0" + (i + 1).ToString(), 
                    Value = r.Next(20, 50).ToString() });
            }
            return contract_products;
        }
    }
}
