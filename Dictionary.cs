using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DictionaryProject
{
    class Dictionary
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd1 = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        public Dictionary(string conString)
        {
            con.ConnectionString = conString;
        }
        public DataTable search(string englishWord)
        {
            string sqlText = "select * from wordTBL where EnglishWord like '%" + englishWord + "%'";
            SqlCommand command = new SqlCommand();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandText = sqlText;
            command.Connection = con;
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);
            return table;
        }

        public void newItem(string EnglishWord, string PerisanWord)
        {
            con.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO wordTBL(EnglishWord,PersianWird) values(@englishWord , @persianWord)";
            command.Parameters.AddWithValue("englishWord", EnglishWord);
            command.Parameters.AddWithValue("persianWord", PerisanWord);
            command.Connection = con;
            command.ExecuteNonQuery();
            search(EnglishWord);
            con.Close();
        }
    }
}
