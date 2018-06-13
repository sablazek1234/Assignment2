using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    [Serializable()]
    public class clsCategory : SortedDictionary<string, clsInventory>
    {
        private const string _FileName = "products.dat";
        private string _ProductName;

    public void NewProduct(clsInventory prProduct)
        {
            if (!string.IsNullOrEmpty(prProduct.Name))
            {
                Add(prProduct.Name, prProduct);
            }
            else
                throw new Exception("No product name entered");
        }

    public decimal GetTotalValue()
    {
        decimal lcTotal = 0;
        foreach (clsInventory lcProduct in Values)
        {
            lcTotal += lcProduct.Price;
        }
        return lcTotal;
    }

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        public static clsCategory RetrieveProductList()
        {
            clsInventory lcProductList;
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open);
                BinaryFormatter lcFormatter = new BinaryFormatter();
                lcProductList = (clsInventory)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                lcProductList = new clsInventory();
                throw new Exception("File Retrieve Error: " + ex.Message);
            }
            return lcProductList;
        }

        public void Save()
        {
            System.IO.FileStream lcFileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create);
            BinaryFormatter lcFormatter = new BinaryFormatter();
            lcFormatter.Serialize(lcFileStream, this);
            lcFileStream.Close();
        }
    }
}
