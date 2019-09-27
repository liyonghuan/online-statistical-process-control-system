using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace onlineSPC
{
    class SQL_Class
    {
        //定义一个SqlConnection类型的静态公共变量My_con，用于判断数据库是否连接成功
        public static SqlConnection My_con;

        //定义SQL Server连接字符串
        public static string My_sqlcon = "Data Source=(local);Initial Catalog=onlineSPC;Integrated Security=True";

        //该方法是用static定义的静态方法，其功能是建立与数据库的连接，然后通过SqlConnection对象的Open()方法打开与数据库的连接，并返回SqlConnection对象的信息
        public static SqlConnection getcon()
        {
            My_con = new SqlConnection(My_sqlcon);      //用SqlConnection对象与指定的数据库相连接
            My_con.Open();      //打开数据库连接
            return My_con;      //返回SqlConnection对象的信息
        }

        //该方法的主要功能是对数据库操作后，通过该方法判断是否与数据库连接，如果连接，则关闭数据库连接，并释放资源
        public void con_close()
        {
            if (My_con.State == ConnectionState.Open)        //判断是否打开与数据库的连接
            {
                My_con.Close();     //关闭数据库的连接
                My_con.Dispose();       //释放My_con变量的所有空间
            }
        }

        //该方法的主要功能是用SqlDataReader对象以只读的方式读取数据库中的信息，并以SqlDataReader对象进行返回，其中SQLstr参数表示传递的SQL语句
        public SqlDataReader getcom(string SQLstr)
        {
            getcon();       //打开与数据库的连接
            SqlCommand My_com = My_con.CreateCommand();     //创建一个SqlCommand对象，用于执行SQL语句
            My_com.CommandText = SQLstr;        //获取指定的SQL语句
            SqlDataReader My_read = My_com.ExecuteReader();     //执行SQL语句，生成一个SqlDataReader结果
            return My_read;
        }

        //该方法的主要功能是通过SqlCommand对象执行数据库中的添加、修改和删除操作，并在执行完成后，关闭与数据库的连接，其中SQLstr参数表示传递的SQL语句
        public void getsqlcom(string SQLstr)
        {
            getcon();       //打开与数据库的连接
            //创建一个SqlCommand对象，用于执行SQL语句
            SqlCommand SQLcom = new SqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();      //执行SQL语句
            SQLcom.Dispose();       //释放SQLcom变量的所有空间
            con_close();        //调用con_close方法，关闭与数据库的连接
        }

        //该方法的主要功能是通过用SqlDataAdapter对象读取数据库中的信息，并以DataSet对象进行返回，其中SQLstr参数表示传递的SQL语句，tableName参数表示返回表的名称
        public DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();       //打开与数据库的连接
            //创建SqlDataAdapter对象，以读取数据库中的信息
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();     //创建DataSet对象
            SQLda.Fill(My_DataSet, tableName);      //把读取的数据写入指定的数据表中
            return My_DataSet;      //返回DataSet对象的信息
        }
    }
}