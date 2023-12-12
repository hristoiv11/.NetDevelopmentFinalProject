using System;
using System.Collections.Generic;
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

            Education newEd = new Education()
            {
                Name = "Saint-Lamber Highschool",
                Level = "High-School",
                Address = "750 rue Green",




            };
 
            //seed the table
            AddEducation(newEd);
            
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

                string table = "create table Education (EducationId integer primary key, Name text, Level text, Address text);";
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

                string query = "INSERT INTO Education (Name,Level,Address) VALUES (@Name, @Level, @Address)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@Name", education.Name);
                insertcom.Parameters.AddWithValue("@Level", education.Level);
                insertcom.Parameters.AddWithValue("@Address",education.Address);

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

                        education.Name = reader["Name"].ToString();
                        education.Level= reader["Level"].ToString();
                        education.Address = reader["Address"].ToString();
                    }
                }
            }
            return education;
        }

        public int UpdatePhone(PhoneNumber phoneNumber)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "UPDATE PhoneNumber SET Number = @Number , Type = @Type, ResumeId = @ResumeId WHERE PhoneNumberId = @PhoneNuberId";


                SQLiteCommand updatecom = new SQLiteCommand(query, conn);
                updatecom.Parameters.AddWithValue("@PhoneNumberId", phoneNumber.PhoneNumberId);
                updatecom.Parameters.AddWithValue("@Number", phoneNumber.Number);
                updatecom.Parameters.AddWithValue("@Type", phoneNumber.Type);
                updatecom.Parameters.AddWithValue("@ResumeId", phoneNumber.ResumeId);

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
        public List<Education> ReadAllEducation()
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

                        education.Name = reader["Name"].ToString();
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
