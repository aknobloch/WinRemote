using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winRemoteDataBase.Model
{
    public class Macros
    {
        //The Id property is marked as the Primary Key
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int mc_ID { get; set; }
        public int mc_kc_ID { get; set; }
        public int mc_Group { get; set; }
        public int mc_Order { get; set; }
        public Macros()
        {

        }
        public Macros(int mc_kc_ID, int mc_Group, int mc_Order)
        {
            this.mc_kc_ID = mc_kc_ID;
            this.mc_Group = mc_Group;
            this.mc_Order = mc_Order;
        }
    }
}
