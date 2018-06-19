using System;
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
    public partial class frmCategory : Form
    {
        protected clsCategory _Category;
        public frmCategory()
        {
            InitializeComponent();
        }      

        public void SetDetails(clsCategory prCategory)
        {
            _Category = prCategory;
            updateForm();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            tbCategoryName.Text = _Category.CategoryName;
            tbDescription.Text = _Category.Description;
        }

        protected virtual void pushData()
        {
            _Category.CategoryName = tbCategoryName.Text;
            _Category.Description = tbDescription.Text;
        }

    }
}
