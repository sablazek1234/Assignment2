using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    class clsInventory
    {
        private string _Name;
        private string _Origin;
        private string _ProductCondition;
        private string _Brand;
        private string _Quantity;
        private decimal _Price;

        private clsCategory _ProductList;

        public clsInventory() { }

        public clsInventory(clsCategory prCategoryList)
        {
            _ProductList = prCategoryList;
        }

        public void NewProduct()
        {
            if (!string.IsNullOrEmpty(Name))
                _ProductList.Add(Name, this);
            else
                throw new Exception("No product name entered");
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Origin
        {
            get { return _Origin; }
            set { _Origin = value; }
        }

        public string ProductCondition
        {
            get { return _ProductCondition; }
            set { _ProductCondition = value; }
        }

        public string Brand
        {
            get { return _Brand; }
            set { _Brand = value; }
        }

        public string Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public clsCategory ProductList
        {
            get { return _ProductList; }
        }
    }
}
