﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public clsArtist GetArtist(string Name)

        {

            Dictionary<string, object> par = new Dictionary<string, object>(1);

            par.Add("Name", Name);

            DataTable lcResult =

            clsDBConnection.GetDataTable("SELECT * FROM Artist WHERE Name = @Name", par);

            if (lcResult.Rows.Count > 0)

                return new clsArtist()

                {

                    Name = (string)lcResult.Rows[0]["Name"],

                    Speciality = (string)lcResult.Rows[0]["Speciality"],

                    Phone = (string)lcResult.Rows[0]["Phone"]

                };

            else

                return null;

        }
    }
}
