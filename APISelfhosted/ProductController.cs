using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace APISelfhosted
{
    public class ProductController : ApiController
    {
        public List<string> GetCategory()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblCategory", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public List<string> GetProduct()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblProduct", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public List<string> GetOrderDetails()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblOrderDetails", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public clsCategory GetCategoryName(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("CategoryName", Name);
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblCategory", par);
            if (lcResult.Rows.Count > 0)
                return new clsCategory()
                {
                    CategoryName = (string)lcResult.Rows[0]["CategoryName"],
                    Description = (string)lcResult.Rows[0]["Description"],
                };
            else
                return null;
        }

        public clsProducts GetProductName(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ProductName", Name);
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblProduct", par);
            if (lcResult.Rows.Count > 0)
                return new clsProducts()
                {
                    Name = (string)lcResult.Rows[0]["ProductName"],
                    Origin = (string)lcResult.Rows[0]["Origin"],
                    ProductCondition = (string)lcResult.Rows[0]["ProductCondition"],
                    Brand = (string)lcResult.Rows[0]["Brand"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                };
            else
                return null;
        }

        public clsOrderDetails GetOrderDetailsName(string Name)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ProductName", Name);
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblProduct", par);
            if (lcResult.Rows.Count > 0)
                return new clsOrderDetails()
                {
                    CustomerName = (string)lcResult.Rows[0]["CustomerName"],
                    CustomerPhone = (string)lcResult.Rows[0]["Origin"],
                    DateofPurchase = (DateTime)lcResult.Rows[0]["ProductCondition"],
                    Price = (float)lcResult.Rows[0]["Price"],
                    Quantity = (int)lcResult.Rows[0]["Quantity"],
                };
            else
                return null;
        }

            private clsProducts dataRow2AllWork(DataRow prDataRow)
        {
            return new clsProducts()
            {
                Name = Convert.ToString(prDataRow["ProductName"]),
                Origin = Convert.ToString(prDataRow["Origin"]),
                ProductCondition = Convert.ToString(prDataRow["ProductCondition"]),
                Brand = Convert.ToString(prDataRow["Brand"]),
                Quantity = Convert.ToInt16(prDataRow["Quantity"]),
            };

        }

        public string PutCategory(clsCategory prCategory)
        {   // update
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "UPDATE tblCategory SET Description = @Description, WHERE CategoryName = @CategoryName",
        prepareCategoryParameters(prCategory));
                if (lcRecCount == 1)
                    return "One Category updated";
                else
                    return "Unexpected Category update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteCategory(string ProductName, string CategoryName)
        {   // delete
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "DELETE FROM tblProduct WHERE CategoryName='" + CategoryName + "' AND ProductName='" + ProductName + "'", null);
                if (lcRecCount == 1)
                    return "One category deleted";
                else
                    return "Unexpected category delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteProduct(string Name)
        {   // delete
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "DELETE FROM tblProduct WHERE ProductName='" + Name + "'", null);
                if (lcRecCount == 1)
                    return "One product deleted";
                else
                    return "Unexpected product delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostCategory(clsCategory prCategory)
        {   // insert
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "Insert Into tblCategory(CategoryName,Description) Values(@CategoryName, @Description)",
        prepareCategoryParameters(prCategory));
                if (lcRecCount == 1)
                    return "One category inserted";
                else
                    return "Unexpected category insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareCategoryParameters(clsCategory prCategory)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("CategoryName", prCategory.CategoryName);
            par.Add("Description", prCategory.Description);
            return par;
        }

        public string PutProduct(clsProducts prProduct)
        {   // update
            try
            {
                int lcRecCount = clsDBConnection.Execute("UPDATE tblProduct SET " +
                "ProductName = @ProductName, Origin = @Origin, ProductCondition = @ProductCondition, Brand = @Brand, Quantity = @Quantity",
                prepareProductParameters(prProduct));
                if (lcRecCount == 1)
                    return "One product updated";
                else
                    return "Unexpected product update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostProduct(clsProducts prWork)
        {   // insert
            try
            {
                int lcRecCount = clsDBConnection.Execute("INSERT INTO tblProduct " +
                "(ProductName, Origin, ProductCondition, Brand, Quantity) " +
                "VALUES (@ProductName, @Origin, @ProductCondition, @Brand, @Quantity)",
                prepareProductParameters(prWork));
                if (lcRecCount == 1)
                    return "One Product inserted";
                else
                    return "Unexpected product insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareProductParameters(clsProducts prProducts)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("ProductName", prProducts.Name);
            par.Add("Origin", prProducts.Origin);
            par.Add("ProductCondition", prProducts.ProductCondition);
            par.Add("Brand", prProducts.Brand);
            par.Add("Quantity", prProducts.Quantity);
            return par;
        }
    }
}
