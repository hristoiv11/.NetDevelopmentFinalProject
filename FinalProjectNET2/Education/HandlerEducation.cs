using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public sealed class HandlerEducation
    {

        static readonly string Constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        static readonly HandlerEducation instance = new HandlerEducation();



        private HandlerEducation()
        {
            CreateTable();

            Education newEd1 = new Education()
            {
                InstitutionName = "Saint-Lamber Highschool",
                Level = "High-School",
                Address = "750 rue Green",

            };

            //seed the table
            AddEducation(newEd1);

        }

        public static HandlerEducation Instance
        {
            get { return instance; }
        }

        public void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(Constring))


            {
                con.Open();
                string drop = "drop table if exists Education;";
                SQLiteCommand command1 = new SQLiteCommand(drop, con);
                command1.ExecuteNonQuery();

                string table = "create table Education (EducationId integer primary key, InstitutionName text, Level text, Address text);";
                SQLiteCommand command2 = new SQLiteCommand(table, con);
                command2.ExecuteNonQuery();
            }
        }

        public int AddEducation(Education education)
        {
            // Implement your AddPhone method logic here, using the SQLite code provided
            // Ensure to use the SQLite operations for inserting a new phone number
            // Return the newId or handle it as needed

            int rows = 0;
            int newId = 0;

            using (SQLiteConnection con = new SQLiteConnection(Constring))
            {
                con.Open();

                string query = "INSERT INTO Education (InstitutionName,Level,Address) VALUES (@InstitutionName, @Level, @Address)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@InstitutionName", education.InstitutionName);
                insertcom.Parameters.AddWithValue("@Level", education.Level);
                insertcom.Parameters.AddWithValue("@Address", education.Address);

                try
                {
                    rows = insertcom.ExecuteNonQuery();

                    // Get the rowid inserted
                    insertcom.CommandText = "select last_insert_rowid()";
                    long LastRowID64 = Convert.ToInt64(insertcom.ExecuteScalar());

                    // Grab the bottom 32 bits as the unique id of the row
                    newId = Convert.ToInt32(LastRowID64);
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newId;
        }

        public Education GetEducation(int id)
        {
            Education education = new Education();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                SQLiteCommand getcom = new SQLiteCommand("Select * from Education WHERE EducationId = @EducationId", conn);
                getcom.Parameters.AddWithValue("@EducationId", id);

                using (SQLiteDataReader reader = getcom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Int32.TryParse(reader["EducationId"].ToString(), out int id2))
                        {
                            education.EducationId = id2;
                        }

                        education.InstitutionName = reader["InstitutionName"].ToString();
                        education.Level = reader["Level"].ToString();
                        education.Address = reader["Address"].ToString();
                    }
                }
            }
            return education;
        }

        public int UpdateEducation(Education education)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "UPDATE Education SET InstitutionName = @InstitutionsName , Level = @Level,Address = @Address WHERE EducationId = @EducationId";


                SQLiteCommand updatecom = new SQLiteCommand(query, conn);
                updatecom.Parameters.AddWithValue("@EducationId", education.EducationId);
                updatecom.Parameters.AddWithValue("@InstitutionName", education.InstitutionName);
                updatecom.Parameters.AddWithValue("@Level", education.Level);
                updatecom.Parameters.AddWithValue("@Address", education.Address);
                

                try
                {
                    row = updatecom.ExecuteNonQuery();
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Error Generated. Details:" + e.ToString());
                }

            }
            return row;
        }

        public int DeleteEducation(Education education)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "Delete From Education WHERE EducationId = @EducationId";
                SQLiteCommand deletecom = new SQLiteCommand(query, conn);
                deletecom.Parameters.AddWithValue("@EducationId", education.EducationId);

                try
                {
                    row = deletecom.ExecuteNonQuery();

                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Error Generated. Details:" + e.ToString());
                }

                return row;
            }
        }
        public List<Education> ReadAllEducations()
        {
            List<Education> listEducation = new List<Education>();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from Education", conn);

                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Education education = new Education();
                        if (Int32.TryParse(reader["EducationId"].ToString(), out int id))
                        {
                            education.EducationId = id;
                        }

                        education.InstitutionName = reader["InstitutionName"].ToString();
                        education.Level = reader["Level"].ToString();
                        education.Address = reader["Address"].ToString();


                        listEducation.Add(education);
                    }
                }

            }

            return listEducation;

        }
    }
}
