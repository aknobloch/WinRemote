using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BTConnectionService.model
{
    [DataContract]
    class WinAction
    {
        [DataMember]
        int m_ID;

        [DataMember]
        string m_Template;

        [DataMember]
        string m_Name;

        [DataMember]
        string m_SendKeysAction;

        public WinAction(int id, string template, string name, string action)
        {
            this.m_ID = id;
            this.m_Template = template;
            this.m_Name = name;
            this.m_SendKeysAction = action;
        }
    }
}
