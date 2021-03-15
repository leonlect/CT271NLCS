using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKho
{
    class clsDatabase
    {
        public static SqlConnection con;
        //Tạo đối tượng kết nối

        public static bool OpenConnection() //Initial method open connection
        {
            try
            {
                con = new SqlConnection("Server=DESKTOP-E5AILH0\\SQLEXPRESS; Database = QuanLyKho; uid=sa;pwd=sa");
                con.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #region Method đổ dữ liệu vào combobox
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }
        #endregion

        #region Method lấy trường dữ liệu khi query bằng mã
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        #endregion

        #region Method đổ dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = clsDatabase.con; //Kết nối cơ sở dữ liệu
            da.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        #endregion

        #region Method kiểm tra trùng khóa
        //Hàm kiểm tra khoá trùng
        public static bool checkKey(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        #endregion

        public static void RunSQL(string sql)
        {
            SqlCommand com; //Đối tượng thuộc lớp SqlCommand
            com = new SqlCommand();
            com.Connection = con; //Gán kết nối
            com.CommandText = sql; //Gán lệnh SQL
            try
            {
                com.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            com.Dispose();//Giải phóng bộ nhớ
            com = null;
        }

        
    }
}
