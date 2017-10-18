using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winRemoteDataBase.Model
{
    public class DBButton
    {
        //The Id property is marked as the Primary Key
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int btn_ID { get; set; }
        public int btn_mc_ID { get; set; }
        public string btn_Description { get; set; }

        public DBButton()
        {

        }

        public DBButton(int btn_mc_ID, string btn_Description)
        {
            this.btn_mc_ID = btn_mc_ID;
            this.btn_Description = btn_Description;
        }
    }
}
