using CoreWebAPI.Helpers;
using CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoreWebAPI.Data
{
    public class CursusRepository : GenericDataHelper<Cursus>
    {
        public CursusRepository(SqlHelper sqlhelper) : base(sqlhelper)
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

        public List<Cursus> Get()
        {
            return ConvertToList("Select * from cursussen");
        }

        public Cursus GetById(int id)
        {
            SqlParameter param = new SqlParameter("@cursusnr", id);
            return ConvertToEntity("Select * from cursussen where cursusnr = @cursusnr", param);
        }

        public List<Cursus> GetByNaamEnInschrijvingsgeld(string naamBevat, int maxInschrijvingsgeld)
        {
            SqlParameter pNaam = new SqlParameter("@naambevat", naamBevat);
            SqlParameter pInschrijving = new SqlParameter("@maxInschrijvingsgeld", maxInschrijvingsgeld);
            return ConvertToList("getCursussen", CommandType.StoredProcedure, pNaam, pInschrijving);
        }
    }
}
