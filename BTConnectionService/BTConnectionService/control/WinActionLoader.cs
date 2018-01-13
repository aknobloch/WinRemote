using BTConnectionService.model;
using System.Collections.Generic;
using System.IO;

namespace BTConnectionService.control
{
    class WinActionLoader
    {
        const string BUTTON_FILE_PATH = "config\\button_definitions.txt";
        private static List<WinAction> m_ButtonList;

        private WinActionLoader()
        {
            // prevent instantiation, static class
        }
        
        private static void LoadActions()
        {
            m_ButtonList = new List<WinAction>();

            using (StreamReader fileIn = File.OpenText(BUTTON_FILE_PATH))
            {
                string nextLine = "";
                while((nextLine = fileIn.ReadLine()) != null)
                {
                    if(nextLine.StartsWith("#") || string.IsNullOrWhiteSpace(nextLine))
                    {
                        continue;
                    }

                    AddAction(nextLine);
                }
            }
        }

        private static void AddAction(string line)
        {
            string[] lineInfo = line.Split(';');

            if(lineInfo.Length < 2 || lineInfo.Length > 3)
            {
                Log.Write("Skipping invalid button config definition: " + line);
            }

            string template;
            string name;
            string action;

            if(lineInfo.Length >= 3)
            {
                template = lineInfo[0];
                name = lineInfo[1];
                action = lineInfo[2];
            }
            else
            {
                template = null;
                name = lineInfo[0];
                action = lineInfo[1];
            }

            WinAction newButton = new WinAction(m_ButtonList.Count, template, name, action);
            m_ButtonList.Add(newButton);
        }

        /// <summary>
        /// Gets the buttons that have been cached. If the LoadButtons() method
        /// has not been explicity called already, the buttons will be loaded
        /// implicitly by this method.
        /// </summary>
        /// <returns></returns>
        public static List<WinAction> GetWinActions()
        {
            if(m_ButtonList == null)
            {
                LoadActions();
            }

            return m_ButtonList;
        }

        /// <summary>
        /// Gets the button referenced by the given ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static WinAction GetWinActionByID(int ID)
        {
            foreach(WinAction action in GetWinActions())
            {
                if(action.GetID() == ID)
                {
                    return action;
                }
            }

            throw new System.ArgumentOutOfRangeException("ID", ID, "ID value could not be found in available actions.");
        }
    }
}
