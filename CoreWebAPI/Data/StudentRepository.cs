using CoreWebAPI.Models;
using DataHelpers.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoreWebAPI.Data
{
    public class StudentRepository : GenericDataHelper<Student>
    {
        string sqlSelect = @"select 
                                studnr,
	                            voornaam,
	                            familienaam,
	                            (select count(*) from studenten_cursussen sc where studnr = s.studnr) as aantalinschrijvingen
                                from studenten s";
        string sqlOrder = " order by voornaam, familienaam";

        public StudentRepository(SqlHelper sqlhelper) : base(sqlhelper)
        {
        }

        public override Student ConvertToEntity(DataRow row)
        {
            Student studentInschrijving = new Student
            {
                Studentnr = Convert.ToInt32(row["studnr"]),
                Voornaam = row["voornaam"].ToString(),
                Familienaam = row["familienaam"].ToString(),
                AantalInschrijvingen = Convert.ToInt32(row["aantalinschrijvingen"])
            };
            return studentInschrijving;
        }

        public List<Student> Get()
        {
            return ConvertToList(sqlSelect + sqlOrder);
        }

        public Student GetById(int id)
        {
            SqlParameter param = new SqlParameter("@studnr", id);
            return ConvertToEntity(sqlSelect +" where studnr = @studnr ", param);
        }
    }
}
