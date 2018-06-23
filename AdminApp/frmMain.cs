using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public sealed partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        //private clsProductsList _ProductList = new clsProductsList();

        public delegate void Notify(string prProductName);

        public event Notify ProductNameChanged;

        public frmMain()
        {
            InitializeComponent();
        }

        public static frmMain Instance
        {
            get { return frmMain._Instance; }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //_ProductList = clsProductsList.RetrieveProductList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File retrieve error");
            }
            UpdateDisplayAsync();
            //ProductNameChanged += new Notify(updateTitle);
            //ProductNameChanged(_ProductList.Name);
            //updateTitle(_ArtistList.GalleryName);
        }

        private void updateTitle(string prCategoryName)
        {
            if (!string.IsNullOrEmpty(prCategoryName))
                Text = "Category " + prCategoryName;
        }

        public async Task UpdateDisplayAsync()
        {
            listProductsList.DataSource = null;
            listProductsList.DataSource = await ServiceClient.GetCategoryNameAsync();
            //string[] lcDisplayList = new string[_ProductList.Count];
            //_ProductList.Keys.CopyTo(lcDisplayList, 0);
            //listProductsList.DataSource = lcDisplayList;
        }

        public static class clsServiceClient
        {
            internal async static Task<List<string>> GetArtistNamesAsync()
            {
                using (HttpClient lcHttpClient = new HttpClient())
                    return JsonConvert.DeserializeObject<List<string>>
                        (await lcHttpClient.GetStringAsync("http://localhost:60000/api/gallery/GetCategory/"));
            }
        }

        private void listProductsList_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(listProductsList.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmProducts.Run(lcKey);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            try
            {
                frmProducts.Run(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new product");
            }
        }

        private void btnEditProducts_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            string lcRemove;

            lcRemove = Convert.ToString(listProductsList.SelectedItem);
            if (lcRemove != null && MessageBox.Show("Are you sure you want to delete this product?", "Deleting product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    //_ProductList.Remove(lcRemove);
                    listProductsList.ClearSelected();
                    UpdateDisplayAsync();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "There was an error deleting athe product");
                }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
