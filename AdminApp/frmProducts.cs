﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp
{
    public partial class frmProducts : Form
    {
        private static readonly frmProducts Instance = new frmProducts();

        public frmProducts()
        {
            InitializeComponent();
        }

        //protected override void updateForm()
        //{
        //    base.updateForm();
        //    //clsProducts lcProduct = (clsProducts)_Category;
        //    tbProductName.Text = lcProduct.Name.ToString();
        //    tbOrigin.Text = lcProduct.Origin.ToString();
        //    tbProductCondition.Text = lcProduct.ProductCondition.ToString();
        //    tbBrand.Text = lcProduct.Brand.ToString();
        //    tbQuantity.Text = lcProduct.Quantity.ToString();
        //    tbPrice.Text = lcProduct.Price.ToString();
        //}

        //protected override void pushData()
        //{
        //    base.pushData();
        //    clsProducts lcProduct= (clsProducts)_Category;
        //    lcProduct.Name = tbProductName.Text;
        //    lcProduct.Origin = tbOrigin.Text;
        //    lcProduct.ProductCondition = tbProductCondition.Text;
        //    lcProduct.Brand = tbBrand.Text;
        //    lcProduct.Quantity = Convert.ToUInt16(tbQuantity.Text);
        //    lcProduct.Price = Convert.ToDecimal(tbPrice.Text);
    }
}