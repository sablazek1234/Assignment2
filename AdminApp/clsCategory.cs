using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    [Serializable()]
    public abstract class clsCategory
    {
        private string _CategoryName;
        private string _Description;

        public clsCategory()
        {
            EditDetails();
        }

        public abstract void EditDetails();

        public override string ToString()
        {
            return _CategoryName;
        }

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }   
}
