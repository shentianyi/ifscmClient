using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brilliantech.MonoScmPrinter.ClientCL.Model;

namespace Brilliantech.MonoScmPrinter.Client.ViewModel
{
    class DeliveryItemViewModel : DeliveryItem, IComparable
    {
        private bool _isScaned = false;
        private string _borderColor = "#FFEAEDEC";
        private int _borderThickness = 1;

        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; }
        }

        public string BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        public bool IsScaned { get { return _isScaned; } set { _isScaned = value; } }


        public static List<DeliveryItemViewModel> VMConvertor(List<DeliveryItem> items)
        {
            List<DeliveryItemViewModel> vmitems = new List<DeliveryItemViewModel>();
            foreach (DeliveryItem item in items)
            {
                vmitems.Add(new DeliveryItemViewModel() { key = item.key, cpartNr = item.cpartNr, spartNr = item.spartNr, perPackAmount = item.perPackAmount });
            }
            return vmitems;
        }

        public int CompareTo(object obj)
        {
            int result = 0;
            try
            {
                DeliveryItemViewModel vmobj = obj as DeliveryItemViewModel;
                if (!this.IsScaned && vmobj.IsScaned)
                    result = -1;
                else if (this.IsScaned && !vmobj.IsScaned)
                    result = 1;
            }
            catch(Exception e){
             throw new Exception("比较异常", e.InnerException);}
            return result;
        }
    }
}
