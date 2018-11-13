using CoreWebAPI.Helpers;
using CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoreWebAPI.Data
{
    public class CursusData : GenericDataHelper<Cursus>
    {
        public CursusData(SqlHelper sqlhelper) : base(sqlhelper)
        {
        }

        public override Cursus ConvertToEntity(DataRow row)
        {
            Cursus cursus = new Cursus
            {
                Id = Convert.ToInt32(row["cursusnr"]),
                Cursusnaam = row["cursusnaam"].ToString(),
                Inschrijvingsgeld = Convert.ToInt32(row["inschrijvingsgeld"])
            };
            return cursus;
        }
   
    }
}
