using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    class HandlerWorkExperience
    {
        static readonly string Constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        static readonly HandlerWorkExperience instance = new HandlerWorkExperience();

        private HandlerWorkExperience()
        {
            CreateTable();

            WorkExperience workExperience = new WorkExperience
            {
                CompanyName = "AnyCompany",
                JobTitle = "Programmer",
                YearsSpent = "2"
            };

            //seed the table
            AddWorkExperience(workExperience);

        }

        public static HandlerWorkExperience Instance
        {
            get { return instance; }
        }

        public void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(Constring))


            {
                con.Open();

                string drop = "drop table if exists WorkExperience;";
                SQLiteCommand command1 = new SQLiteCommand(drop, con);
                command1.ExecuteNonQuery();

                string table = "create table WorkExperience (WorkExperienceId integer primary key, CompanyName text, JobTitle text, YearsSpent text);";
                SQLiteCommand command2 = new SQLiteCommand(table, con);
                command2.ExecuteNonQuery();
            }
        }

        public int AddWorkExperience(WorkExperience workExperience)
        {
            // Implement your AddPhone method logic here, using the SQLite code provided
            // Ensure to use the SQLite operations for inserting a new phone number
            // Return the newId or handle it as needed

            int rows = 0;
            int newId = 0;

            using (SQLiteConnection con = new SQLiteConnection(Constring))
            {
                con.Open();

                string query = "INSERT INTO WorkExperience (CompanyName,JobTitle,YearsSpent) VALUES (@CompanyName, @JobTitle, @YearsSpent)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@CompanyName", workExperience.CompanyName);
                insertcom.Parameters.AddWithValue("@JobTitle", workExperience.JobTitle);
                insertcom.Parameters.AddWithValue("@YearsSpent", workExperience.YearsSpent);
   
                try
                {
                    rows = insertcom.ExecuteNonQuery();

                    // Get the rowid inserted
                    insertcom.CommandText = "select last_insert_rowid()";
                    long LastRowID64 = Convert.ToInt64(insertcom.ExecuteScalar());

                    // Grab the bottom 32 bits as the unique id of the row
                    newId = Convert.ToInt32(LastRowID64);
                }
                catch (SQLiteException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
            }

            return newId;
        }

        public WorkExperience GetWorkExperience(int id)
        {
            WorkExperience workExperience = new WorkExperience();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                SQLiteCommand getcom = new SQLiteCommand("Select * from WorkExperience WHERE WorkExperienceId = @WorkExperienceId", conn);
                getcom.Parameters.AddWithValue("@WorkExperienceId", id);

                using (SQLiteDataReader reader = getcom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Int32.TryParse(reader["WorkExperienceId"].ToString(), out int id2))
                        {
                            workExperience.WorkExperienceId = id2;
                        }

                        workExperience.CompanyName = reader["CompanyName"].ToString();
                        workExperience.JobTitle = reader["JobTitle"].ToString();
                        workExperience.YearsSpent = reader["YearsSpent"].ToString();
                    }
                }
            }
            return workExperience;
        }

        public int UpdateWorkExperience(WorkExperience workExperience)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "UPDATE WorkExperience SET CompanyName = @CompanyName , JobTitle = @JobTitle,YearsSpent =@YearsSpent WHERE WorkExperienceId = @WorkExperienceId";


                SQLiteCommand updatecom = new SQLiteCommand(query, conn);
                updatecom.Parameters.AddWithValue("@WorkExperienceId", workExperience.WorkExperienceId);
                updatecom.Parameters.AddWithValue("@CompanyName", workExperience.CompanyName);
                updatecom.Parameters.AddWithValue("@JobTitle", workExperience.JobTitle);
                updatecom.Parameters.AddWithValue("@YearsSpent", workExperience.YearsSpent);

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

        public int DeleteWorkExperience(WorkExperience workExperience)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "Delete From WorkExperience WHERE WorkExperienceId = @WorkExperienceId";
                SQLiteCommand deletecom = new SQLiteCommand(query, conn);
                deletecom.Parameters.AddWithValue("@WorkExperienceId", workExperience.WorkExperienceId);

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

        public List<WorkExperience> ReadAllWorkExperiences()
        {
            List<WorkExperience> listWorkExperiences = new List<WorkExperience>();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from WorkExperience", conn);

                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WorkExperience workExperience = new WorkExperience();
                        if (Int32.TryParse(reader["WorkExperienceId"].ToString(), out int id))
                        {
                            workExperience.WorkExperienceId = id;
                        }

                        workExperience.CompanyName = reader["CompanyName"].ToString();
                        workExperience.JobTitle = reader["JobTitle"].ToString();
                        workExperience.YearsSpent = reader["YearsSpent"].ToString();

                        listWorkExperiences.Add(workExperience);
                    }
                }

            }

            return listWorkExperiences;

        }
    }
}
