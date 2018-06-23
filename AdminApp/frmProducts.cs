using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AdminApp.DTO;

namespace AdminApp
{
    public sealed partial class frmProducts : AdminApp.frmProductDetails
    {
        private static readonly frmProducts Instance = new frmProducts();

        public frmProducts()
        {
            InitializeComponent();
        }

        public static void Run(clsProducts prProducts)
        {
            Instance.SetDetails(prProducts);
        }

        protected override void updateForm()
        {
            base.updateForm();
            tbProductName.Text = _Products.Name.ToString();
            tbQuantity.Text = _Products.Quantity.ToString();
            tbPrice.Text = _Products.Price.ToString();
        }

        protected override void pushData()
        {
            base.pushData();
            _Products.Name = tbProductName.Text;
            _Products.Quantity = Convert.ToUInt16(tbQuantity.Text);
            _Products.Price = Convert.ToDecimal(tbPrice.Text);
        }
    }
}
