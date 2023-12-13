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

            References newRef = new References
            {
                Name = "Jhon Pearson",
                Description = "Employee of my last job",
                PhoneNumber = "450-347-2020",
                Email = "personemail@gmail.com"

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

                string drop = "drop table if exists REFERENCE;";
                SQLiteCommand command1 = new SQLiteCommand(drop, con);
                command1.ExecuteNonQuery();

                string table = "create table REFERENCE (ReferenceId integer primary key, Name text, Description text, PhoneNumber text,Email text);";
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

                string query = "INSERT INTO REFERENCE (Name,Description,PhoneNumber,Email) VALUES (@Name, @Description, @PhoneNumber,@Email)";
                SQLiteCommand insertcom = new SQLiteCommand(query, con);

                insertcom.Parameters.AddWithValue("@Name", references.Name);
                insertcom.Parameters.AddWithValue("@Description", references.Description);
                insertcom.Parameters.AddWithValue("@PhoneNumber", references.PhoneNumber);
                insertcom.Parameters.AddWithValue("@Email", references.Email);
                

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

        public References GetReference(int id)
        {
            References references = new References();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                SQLiteCommand getcom = new SQLiteCommand("Select * from REFERENCE WHERE ReferenceId = @ReferenceId", conn);
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
                        references.Email = reader["Email"].ToString();
                    }
                }
            }
            return references;
        }

        public int UpdateReference(References references)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "UPDATE REFERENCE SET Name = @Name , Description = @Description,PhoneNumber =@PhoneNumber, Email=@Email WHERE ReferenceId = @ReferenceId";


                SQLiteCommand updatecom = new SQLiteCommand(query, conn);
                updatecom.Parameters.AddWithValue("@ReferenceId", references.ReferenceId);
                updatecom.Parameters.AddWithValue("@Name", references.Name);
                updatecom.Parameters.AddWithValue("@Description", references.Description);
                updatecom.Parameters.AddWithValue("@PhoneNumber", references.PhoneNumber);
                updatecom.Parameters.AddWithValue("@Email", references.Email);

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

        public int DeleteReference(References references)
        {
            int row = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();

                string query = "Delete From REFERENCE WHERE ReferenceId = @ReferenceId";
                SQLiteCommand deletecom = new SQLiteCommand(query, conn);
                deletecom.Parameters.AddWithValue("@ReferenceId", references.ReferenceId);

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

        public List<References> ReadAllReferences()
        {
            List<References> listReferences = new List<References>();

            using (SQLiteConnection conn = new SQLiteConnection(Constring))
            {
                conn.Open();
                SQLiteCommand com = new SQLiteCommand("Select * from REFERENCE", conn);

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
                        references.Email = reader["Email"].ToString();


                        listReferences.Add(references);
                    }
                }

            }

            return listReferences;

        }
    }
}
