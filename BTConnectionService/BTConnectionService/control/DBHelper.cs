using winRemoteDataBase.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.Generic;

namespace winRemoteDataBase.Controller
{
    static class DBHelper
    {
        private const string DB_PATH = "winremote_db.sqlite";

        /// <summary>
        /// Checks to ensure the database already exists. If not, creates it.
        /// </summary>
        private static void CheckDatabase()
        {
            if(File.Exists(DB_PATH))
            {
                return;
            }

            CreateDatabase();
        }

        /// <summary>
        /// Creates the database and necessary tables.
        /// </summary>
        private static void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            { 
                conn.CreateTable<DBKeyCode>();
                conn.CreateTable<DBMacro>();
                conn.CreateTable<DBButton>();
            }
        }

        public static List<string> GetActions(int buttonID)
        {
            DBButton dummyButton = new DBButton();
            dummyButton.btn_ID = buttonID;

            return GetActions(dummyButton);
        }

        // TODO multiple actions w/ same button, ordinality
        public static List<string> GetActions(DBButton buttonPressed)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                string keycodeQuery = "SELECT kc_Value FROM DBKeyCode " +
                    "LEFT JOIN DBMacro ON DBKeyCode.kc_ID = DBMacro.mc_kc_ID " +
                    "LEFT JOIN DBButton ON DBButton.btn_mc_ID = DBMacro.mc_ID " +
                    "WHERE DBButton.btn_ID = " + buttonPressed.btn_ID;

                List<DBKeyCode> dbKeycodes = conn.Query<DBKeyCode>(keycodeQuery);

                List<string> actions = new List<string>();

                foreach(var keycode in dbKeycodes)
                {
                    actions.Add(keycode.kc_Value);
                }

                return actions;
            }
        }

        // Insert the new keycode in the Keycodes table. 
        public static void InsertKeycode(DBKeyCode keycode)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(keycode);
                });
            }
        }

        // Insert the new macro in the Macros table. 
        public static void InsertMacro(DBMacro macro)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(macro);
                });
            }
        }
        // Insert the new button in the Buttons table. 
        public static void InsertButton(DBButton button)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(button);
                });
            }
        }

        // Retrieve the specific keycode from the database.   
        public static DBKeyCode ReadKeycode(int keycodeId)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                // TODO 
                var existingKeycode = conn.Query<DBKeyCode>("select * from DBKeycode where kc_ID =" + keycodeId).FirstOrDefault();
                return existingKeycode;
            }
        }

        // Retrieve the specific macro from the database.   
        public static DBMacro ReadMacro(int macroId)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                var existingMacro = conn.Query<DBMacro>("select * from DBMacro where mc_ID =" + macroId).FirstOrDefault();
                return existingMacro;
            }
        }

        // Retrieve the specific button from the database.   
        public static DBButton ReadButton(int buttonId)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                var existingButton = conn.Query<DBButton>("select * from DBButton where btn_ID =" + buttonId).FirstOrDefault();
                return existingButton;
            }
        }

        public static ObservableCollection<DBKeyCode> ReadAllKeycodes()
        {
            CheckDatabase();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
                {
                    List<DBKeyCode> myCollection = conn.Table<DBKeyCode>().ToList<DBKeyCode>();
                    ObservableCollection<DBKeyCode> keycodeList = new ObservableCollection<DBKeyCode>(myCollection);
                    return keycodeList;
                }
            }
            catch
            {
                return null;
            }

        }

        public static ObservableCollection<DBMacro> ReadAllMacros()
        {
            CheckDatabase();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
                {
                    List<DBMacro> myCollection = conn.Table<DBMacro>().ToList<DBMacro>();
                    ObservableCollection<DBMacro> macroList = new ObservableCollection<DBMacro>(myCollection);
                    return macroList;
                }
            }
            catch
            {
                return null;
            }

        }


        public static ObservableCollection<DBButton> ReadAllButtons()
        {
            CheckDatabase();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
                {
                    List<DBButton> myCollection = conn.Table<DBButton>().ToList<DBButton>();
                    ObservableCollection<DBButton> buttonList = new ObservableCollection<DBButton>(myCollection);
                    return buttonList;
                }
            }
            catch
            {
                return null;
            }

        }
        //Update existing keycode 
        public static void UpdateDetails(DBKeyCode keycode)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingKeycode = conn.Query<DBKeyCode>("select * from DBKeycode where kc_ID =" + keycode.kc_ID).FirstOrDefault();
                if (existingKeycode != null)
                {

                    conn.RunInTransaction(() =>
                    {
                        conn.Update(keycode);
                    });
                }

            }
        }

        //Update existing macro 
        public static void UpdateDetails(DBMacro macro)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingconact = conn.Query<DBMacro>("select * from DBMacro where mc_ID =" + macro.mc_ID).FirstOrDefault();
                if (existingconact != null)
                {

                    conn.RunInTransaction(() =>
                    {
                        conn.Update(macro);
                    });
                }

            }
        }


        //Update existing button 
        public static void UpdateDetails(DBButton button)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingconact = conn.Query<DBButton>("select * from DBButton where btn_ID =" + button.btn_ID).FirstOrDefault();
                if (existingconact != null)
                {

                    conn.RunInTransaction(() =>
                    {
                        conn.Update(button);
                    });
                }

            }
        }

        //Delete specific keycode   
        public static void DeleteKeycode(int id)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingKeycode = conn.Query<DBKeyCode>("select * from DBKeycode where kc_ID =" + id).FirstOrDefault();
                if (existingKeycode != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingKeycode);
                    });
                }
            }
        }

        //Delete specific macro   
        public static void DeleteMacro(int id)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingMacro = conn.Query<DBMacro>("select * from DBMacro where mc_ID =" + id).FirstOrDefault();
                if (existingMacro != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingMacro);
                    });
                }
            }
        }

        //Delete specific button   
        public static void DeleteButton(int id)
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                var existingButton = conn.Query<DBButton>("select * from DBButton where btn_ID =" + id).FirstOrDefault();
                if (existingButton != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingButton);
                    });
                }
            }
        }
      
        //Delete Keycodes table   
        public static void DeleteAllKeycode()
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                conn.DropTable<DBKeyCode>();
                conn.CreateTable<DBKeyCode>();
                conn.Dispose();
                conn.Close();

            }
        }

        //Delete Macros table   
        public static void DeleteAllMacro()
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                conn.DropTable<DBMacro>();
                conn.CreateTable<DBMacro>();
                conn.Dispose();
                conn.Close();

            }
        }

        //Delete Buttons table   
        public static void DeleteAllButton()
        {
            CheckDatabase();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                conn.DropTable<DBButton>();
                conn.CreateTable<DBButton>();
                conn.Dispose();
                conn.Close();

            }
        }
    }
}
