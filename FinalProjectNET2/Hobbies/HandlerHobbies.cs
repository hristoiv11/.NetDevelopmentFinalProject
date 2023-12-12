using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public sealed class HandlerHobbies
    {

        static readonly string Constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        static readonly HandlerHobbies instance = new HandlerHobbies();



        private HandlerHobbies()
        {
            CreateTable();

            Hobbies newHobbie = new Hobbies()
            {
                Description = "I like to read romance books",
                Type = "Reading",




            };
            Hobbies newHobbie2 = new Hobbies()
            {
                Description = "Sitting next to a fire place to relax and think",
                Type = "Meditation",



            };



            //seed the table
            AddHobbie(newHobbie);
            AddHobbie(newHobbie2);
        }

        public static HandlerHobbies Instance
        {
            get { return instance; }
        }

        public void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(Constring))


            {
                con.Open();
                string drop = "drop table if exists Hobbies;";
                SQLiteCommand command1 = new SQLiteCommand(drop, con);
                command1.ExecuteNonQuery();

                string table = "create table Hobbies (HobbiesId integer primary key, Description text, Type text);";
                SQLiteCommand command2 = new SQLiteCommand(table, con);
                command2.ExecuteNonQuery();
            }
        }

        public int AddHobbie(Hobbies hobbies)
        {
            // Implement your AddPhone method logic here, using the SQLite code provided
            // Ensure to use the SQLite operations for inserting a new phone number
            // Return the newId or handle it as needed

            int rows = 0;
            int newId = 0;

            using (SQLiteConnection con = new SQLiteConnection(Constring))
            {
                con.Open();

                string query = "INSERT INTO Hobbies (Description,Type) VALUES (@Description, @Type)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@Description", hobbies.Description);
                insertcom.Parameters.AddWithValue("@Type", hobbies.Type);

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

        public Hobbies GetHobbie(int id)
        {
            Hobbies hobbie = new Hobbies();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                SQLiteCommand getcom = new SQLiteCommand("Select * from Hobbies WHERE HobbiesId = @HobbiesId", conn);
                getcom.Parameters.AddWithValue("@HobbiesId", id);

                using (SQLiteDataReader reader = getcom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Int32.TryParse(reader["HobbiesId"].ToString(), out int id2))
                        {
                            hobbie.HobbiesId = id2;
                        }

                        hobbie.Description = reader["Description"].ToString();
                        hobbie.Type = reader["Type"].ToString();
                    }
                }
            }
            return hobbie;
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
        public List<Hobbies> ReadAllHobbies()
        {
            List<Hobbies> listHobbies = new List<Hobbies>();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from Hobbies", conn);

                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Hobbies hobbies = new Hobbies();
                        if (Int32.TryParse(reader["PhoneNumberId"].ToString(), out int id))
                        {
                            hobbies.HobbiesId = id;
                        }

                        hobbies.Description = reader["Description"].ToString();
                        hobbies.Type = reader["Type"].ToString();


                        listHobbies.Add(hobbies);
                    }
                }

            }

            return listHobbies;

        }
    }
}
