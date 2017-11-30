using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite.Net.Platform.Generic;
using System.Data.SQLite;
using System.Data;

namespace WinRemoteDesktop_Test
{
    class DBHelper
    {
        private const string DB_PATH = "C:\\Users\\Tobin\\Desktop\\winremote_db.sqlite";
        public static Dictionary<int, string> codelib;
        public static void CreateDatabase()
        {
            if (!File.Exists(DB_PATH))
            {
                SQLiteConnection.CreateFile(DB_PATH);
                buildStockDB();
                createStockMacros();
            }
            else
            {
                //DB already exists.
            }
        }

        public static void buildStockDB()
        {
            string macroTable = "CREATE TABLE WR_MACRO(mc_ID INTEGER PRIMARY KEY AUTOINCREMENT, mc_description VARCHAR(2000), mc_command VARCHAR(2000), mc_tag VARCHAR(2000))";
            string buttonTable = "CREATE TABLE WR_BUTTON(btn_ID INTEGER PRIMARY KEY AUTOINCREMENT, btn_mc_ID INT, btn_description VARCHAR(2000))";
            string keycodeTable = "CREATE TABLE WR_KEYCODE(kc_ID INTEGER PRIMARY KEY AUTOINCREMENT, kc_value VARCHAR(2000), kc_description VARCHAR(2000), kc_switch INT)";
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
            conn.Open();
            
            SQLiteCommand cmd = new SQLiteCommand(macroTable, conn);
            cmd.ExecuteNonQuery();
            cmd.CommandText = keycodeTable;
            cmd.ExecuteNonQuery();
            cmd.CommandText = buttonTable;
            cmd.ExecuteNonQuery();
        }

        public static void addKeyCodes(string code)
        {
            string query = "INSERT INTO WR_KEYCODE(kc_value, kc_description, kc_switch) VALUES('"+ code +"','ctrl key',1)";
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static DataSet grabDataset(string table)
        {
            string sql = "Select * from " + table;
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");

            DataSet ds = new DataSet();
            try
            {
                conn.Open();             
                var da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;

            }
            conn.Close();
            return ds;
        }

        public static void executeQuery(string query)
        {            
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void createSimpleMacro(string macro, string tag, string description)
        {
            string insert = "INSERT INTO WR_MACRO(mc_description, mc_command, mc_tag) VALUES('"+description+"','"+macro+"','"+tag+"')";
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(insert, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void createSimpleButton(string mcID, string desc)
        {
            string insert = "INSERT INTO WR_BUTTON(btn_mc_ID, btn_description) VALUES('" + mcID + "','" + desc + "')";
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(insert, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static string getNewBtnID()
        {
            string query = "SELECT MAX(mc_ID) FROM WR_MACRO WHERE mc_tag = 'BTN'";
            var conn = new SQLiteConnection("Data Source=" + DB_PATH + ";Version=3;");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            string btnid = cmd.ExecuteScalar().ToString();
            return btnid;
        }

        public static Dictionary<int, string> buildLibrary()
        {
            codelib = new Dictionary<int, string>();

            return codelib;
        }

        public static void createStockMacros()
        {
            createSimpleMacro("^C","Win","Ctrl-C");
            createSimpleMacro("^V", "Win", "Ctrl-V");
            createSimpleMacro("^A", "Win", "Ctrl-A");
            createSimpleMacro("&{TAB}", "Win", "Alt-Tab");           
        }
    }
}
