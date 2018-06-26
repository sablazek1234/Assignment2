using AdminApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    interface IProductDetailsControl
    {
        void PushData(clsProducts prProducts);
        void UpdateControl(clsProducts prProducts);
    }
}
