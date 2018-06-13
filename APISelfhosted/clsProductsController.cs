using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISelfhosted
{
    class clsProductsController
    {
        public List<string> GetArtistNames()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT Name FROM Products", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }
    }
}
