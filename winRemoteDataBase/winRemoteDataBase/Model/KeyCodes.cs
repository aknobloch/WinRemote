using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winRemoteDataBase.Model
{
    public class Keycodes
    {
        //The Id property is marked as the Primary Key
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int kc_ID { get; set; }
        public string kc_Value { get; set; }
        public string kc_Description { get; set; }
        public bool kc_Switch { get; set; }
        public Keycodes()
        {

        }
        public Keycodes(string kc_Value, string kc_Description, bool kc_Switch)
        {
            this.kc_Value = kc_Value;
            this.kc_Description = kc_Description;
            this.kc_Switch = kc_Switch;
        }
    }
}
