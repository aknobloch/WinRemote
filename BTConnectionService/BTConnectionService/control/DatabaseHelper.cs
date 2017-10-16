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
    class DatabaseHelper
    {
        private const string DB_PATH = "winremote_db.sqlite";

        //Create Table 
        public void CreateDatabase()
        {
            if (File.Exists(DB_PATH))
            {
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            { 
                conn.CreateTable<Keycodes>();
                conn.CreateTable<Macros>();
                conn.CreateTable<Buttons>();
            }
        }

        // Insert the new keycode in the Keycodes table. 
        public void InsertKeycode(Keycodes keycode)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(keycode);
                });
            }
        }
        // Insert the new macro in the Macros table. 
        public void InsertMacro(Macros macro)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(macro);
                });
            }
        }
        // Insert the new button in the Buttons table. 
        public void InsertButton(Buttons button)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(button);
                });
            }
        }

        // Retrieve the specific keycode from the database.   
        public Keycodes ReadKeycode(int keycodeId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                // TODO 
                var existingKeycode = conn.Query<Keycodes>("select * from Keycodes where kc_ID =" + keycodeId).FirstOrDefault();
                return existingKeycode;
            }
        }
        // Retrieve the specific macro from the database.   
        public Macros ReadMacro(int macroId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                var existingMacro = conn.Query<Macros>("select * from Macros where mc_ID =" + macroId).FirstOrDefault();
                return existingMacro;
            }
        }
        // Retrieve the specific button from the database.   
        public Buttons ReadButton(int buttonId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                var existingButton = conn.Query<Buttons>("select * from Buttons where btn_ID =" + buttonId).FirstOrDefault();
                return existingButton;
            }
        }

        public ObservableCollection<Keycodes> ReadAllKeycodes()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
                {
                    List<Keycodes> myCollection = conn.Table<Keycodes>().ToList<Keycodes>();
                    ObservableCollection<Keycodes> keycodeList = new ObservableCollection<Keycodes>(myCollection);
                    return keycodeList;
                }
            }
            catch
            {
                return null;
            }

        }
        public ObservableCollection<Macros> ReadAllMacros()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
                {
                    List<Macros> myCollection = conn.Table<Macros>().ToList<Macros>();
                    ObservableCollection<Macros> macroList = new ObservableCollection<Macros>(myCollection);
                    return macroList;
                }
            }
            catch
            {
                return null;
            }

        }
        public ObservableCollection<Buttons> ReadAllButtons()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
                {
                    List<Buttons> myCollection = conn.Table<Buttons>().ToList<Buttons>();
                    ObservableCollection<Buttons> buttonList = new ObservableCollection<Buttons>(myCollection);
                    return buttonList;
                }
            }
            catch
            {
                return null;
            }

        }
        //Update existing keycode 
        public void UpdateDetails(Keycodes keycode)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingKeycode = conn.Query<Keycodes>("select * from Keycodes where kc_ID =" + keycode.kc_ID).FirstOrDefault();
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
        public void UpdateDetails(Macros macro)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingconact = conn.Query<Macros>("select * from Macros where mc_ID =" + macro.mc_ID).FirstOrDefault();
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
        public void UpdateDetails(Buttons button)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingconact = conn.Query<Buttons>("select * from Buttons where btn_ID =" + button.btn_ID).FirstOrDefault();
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
        public void DeleteKeycode(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingKeycode = conn.Query<Keycodes>("select * from Keycodes where kc_ID =" + id).FirstOrDefault();
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
        public void DeleteMacro(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                var existingMacro = conn.Query<Macros>("select * from Macros where mc_ID =" + id).FirstOrDefault();
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
        public void DeleteButton(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {
                var existingButton = conn.Query<Buttons>("select * from Buttons where btn_ID =" + id).FirstOrDefault();
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
        public void DeleteAllKeycode()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                conn.DropTable<Keycodes>();
                conn.CreateTable<Keycodes>();
                conn.Dispose();
                conn.Close();

            }
        }
        //Delete Macros table   
        public void DeleteAllMacro()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                conn.DropTable<Macros>();
                conn.CreateTable<Macros>();
                conn.Dispose();
                conn.Close();

            }
        }
        //Delete Buttons table   
        public void DeleteAllButton()
        {
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformGeneric(), DB_PATH))
            {

                conn.DropTable<Buttons>();
                conn.CreateTable<Buttons>();
                conn.Dispose();
                conn.Close();

            }
        }
    }
}
