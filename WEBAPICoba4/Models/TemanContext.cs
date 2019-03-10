using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPICoba4.Models
{
    public class TemanContext
    {
        public string ConnectionString { get; set; }

        public List<TemanItem> Teman { get; set; }

        = new List<TemanItem>();

        public TemanContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<TemanItem> GetAllTeman()
        {
            List<TemanItem> list = new List<TemanItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM teman ORDER By id DESC", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add( new TemanItem()
                        {
                            Id = reader.GetInt32("id"),
                            Nama = reader.GetString("nama"),
                            Angkatan = reader.GetInt32("angkatan"),
                            Jurusan = reader.GetString("jurusan"),
                            Universitas = reader.GetString("universitas")
                        });
                    }
                }
            }
            return list;
        }

        public List<TemanItem> GetTeman(string id)
        {
            List<TemanItem> list = new List<TemanItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM teman WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TemanItem()
                        {
                            Id = reader.GetInt32("id"),
                            Nama = reader.GetString("nama"),
                            Angkatan = reader.GetInt32("angkatan"),
                            Jurusan = reader.GetString("jurusan"),
                            Universitas = reader.GetString("universitas")
                        });
                    }
                }
            }
            return list;
        }

        //public bool AddTeman(TemanItem teman)
        //{
        //    bool stauts;
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        //var id = "";
        //        //var nama = "";
        //        //var angkatan = "";
        //        //var jurusan = "";
        //        //var universitas = "";
                
        //        //string query = string.Format("INSERT INTO teman (id, nama, angkatan, jurusan, universitas)" + "VALUE (NULL, '{0}','{1}','{2}','{4}', NOW())", new object[] {id, nama, angkatan, jurusan, universitas});

        //        //conn.Open();
        //        //MySqlCommand cmd = new MySqlCommand();
        //        //cmd.CommandText = query;

        //        try
        //        {
        //            Teman.
        //        }
        //        catch
        //        {

        //        }

        //    }
        //}
    }
}
