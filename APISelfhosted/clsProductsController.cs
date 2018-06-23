using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APISelfhosted.DTO;

namespace APISelfhosted
{
    class clsProductsController
    {
        public List<string> GetCategory()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT Name FROM Category", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public clsProducts GetProduct(string Name)

        {

            Dictionary<string, object> par = new Dictionary<string, object>(1);

            par.Add("Name", Name);

            DataTable lcResult =

            clsDBConnection.GetDataTable("SELECT * FROM Products WHERE Name = @Name", par);

            if (lcResult.Rows.Count > 0)

                return new clsProducts()
                {
                    Name = (string)lcResult.Rows[0]["Name"],
                    Origin = (string)lcResult.Rows[0]["Origin"],
                    ProductCondition = (string)lcResult.Rows[0]["ProductCondition"],
                    Brand = (string)lcResult.Rows[0]["Brand"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                };
            else
                return null;
        }
    }
}
