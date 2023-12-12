using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectNET2
{
    public sealed class HandlerReferences
    {

        static readonly string Constring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        static readonly HandlerReferences instance = new HandlerReferences();



        private HandlerReferences()
        {
            CreateTable();

            References newRef = new References()
            {
                Name = "Jhon Pearson",
                Description = "Employee of my last job",
                PhoneNumber = "450-347-2020"

            };
           

            //seed the table
            AddReference(newRef);
           
        }

        public static HandlerReferences Instance
        {
            get { return instance; }
        }

        public void CreateTable()
        {
            using (SQLiteConnection con = new SQLiteConnection(Constring))


            {
                con.Open();
                string drop = "drop table if exists References;";
                SQLiteCommand command1 = new SQLiteCommand(drop, con);
                command1.ExecuteNonQuery();

                string table = "create table References (ReferenceId integer primary key, Name text, Description text, PhoneNumber text);";
                SQLiteCommand command2 = new SQLiteCommand(table, con);
                command2.ExecuteNonQuery();
            }
        }

        public int AddReference(References references)
        {
            // Implement your AddPhone method logic here, using the SQLite code provided
            // Ensure to use the SQLite operations for inserting a new phone number
            // Return the newId or handle it as needed

            int rows = 0;
            int newId = 0;

            using (SQLiteConnection con = new SQLiteConnection(Constring))
            {
                con.Open();

                string query = "INSERT INTO References (Name,Description,PhoneNumber) VALUES (@Name, @Description, @PhoneNumber)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@Name", references.Name);
                insertcom.Parameters.AddWithValue("@Description", references.Description);
                insertcom.Parameters.AddWithValue("@PhoneNumber", references.PhoneNumber);

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

        public References GetReference(int id)
        {
            References references = new References();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                SQLiteCommand getcom = new SQLiteCommand("Select * from References WHERE ReferenceId = @ReferenceId", conn);
                getcom.Parameters.AddWithValue("@ReferenceId", id);

                using (SQLiteDataReader reader = getcom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Int32.TryParse(reader["ReferenceId"].ToString(), out int id2))
                        {
                            references.ReferenceId = id2;
                        }

                        references.Name = reader["Name"].ToString();
                        references.Description = reader["Description"].ToString();
                        references.PhoneNumber = reader["PhoneNumber"].ToString();
                    }
                }
            }
            return references;
        }

        //public int UpdatePhoneNumber(PhoneNumber phoneNumber)
        //{
        //    int row = 0;

        //    using (SQLiteConnection conn = new SQLiteConnection(Constring))
        //    {
        //        conn.Open();

        //        string query = "UPDATE PhoneNumber SET Number = @Number , Type = @Type WHERE PhoneNumberId = @PhoneNumberId";


        //        SQLiteCommand updatecom = new SQLiteCommand(query, conn);
        //        updatecom.Parameters.AddWithValue("@PhoneNumberId", phoneNumber.PhoneNumberId);
        //        updatecom.Parameters.AddWithValue("@Number", phoneNumber.Number);
        //        updatecom.Parameters.AddWithValue("@Type", phoneNumber.Type);


        //        try
        //        {
        //            row = updatecom.ExecuteNonQuery();
        //        }
        //        catch (SQLiteException e)
        //        {
        //            Console.WriteLine("Error Generated. Details:" + e.ToString());
        //        }

        //    }
        //    return row;
        //}

        //public int DeletePhoneNumber(PhoneNumber phoneNumber)
        //{
        //    int row = 0;

        //    using (SQLiteConnection conn = new SQLiteConnection(Constring))
        //    {
        //        conn.Open();

        //        string query = "Delete From PhoneNumber WHERE PhoneNumberId = @PhoneNumberId";
        //        SQLiteCommand deletecom = new SQLiteCommand(query, conn);
        //        deletecom.Parameters.AddWithValue("@PhoneNumberId", phoneNumber.PhoneNumberId);

        //        try
        //        {
        //            row = deletecom.ExecuteNonQuery();

        //        }
        //        catch (SQLiteException e)
        //        {
        //            Console.WriteLine("Error Generated. Details:" + e.ToString());
        //        }

        //        return row;
        //    }
        //}

        public List<References> ReadAllReferences()
        {
            List<References> listReferences = new List<References>();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from References", conn);

                using (SQLiteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        References references = new References();
                        if (Int32.TryParse(reader["ReferenceId"].ToString(), out int id))
                        {
                            references.ReferenceId = id;
                        }

                        references.Name = reader["Name"].ToString();
                        references.Description = reader["Description"].ToString();
                        references.PhoneNumber = reader["PhoneNumber"].ToString();


                        listReferences.Add(references);
                    }
                }

            }

            return listReferences;

        }
    }
}
