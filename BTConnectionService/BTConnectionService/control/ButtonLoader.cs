using BTConnectionService.model;
using System.Collections.Generic;
using System.IO;

namespace BTConnectionService.control
{
    class ButtonLoader
    {
        const string BUTTON_FILE_PATH = "config\\button_definitions.txt";

        List<DTButton> buttonList;

        public void LoadButtons()
        {
            buttonList = new List<DTButton>();

            using (StreamReader fileIn = File.OpenText(BUTTON_FILE_PATH))
            {
                string nextLine = "";
                while((nextLine = fileIn.ReadLine()) != null)
                {
                    if(nextLine.StartsWith("#"))
                    {
                        continue;
                    }

                    AddButton(nextLine);
                }
            }
        }

        private void AddButton(string line)
        {
            string[] lineInfo = line.Split(';');

            if(lineInfo.Length < 2 || lineInfo.Length > 3)
            {
                Log.write("Skipping invalid button config definition: " + line);
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

            DTButton newButton = new DTButton(buttonList.Count + 1, template, name, action);
            buttonList.Add(newButton);
        }

        /// <summary>
        /// Gets the buttons that have been cached. If the LoadButtons() method
        /// has not been explicity called already, or if the buttons cache has been
        /// invalidated, the buttons will be loaded implicitly by this method.
        /// </summary>
        /// <returns></returns>
        public List<DTButton> GetButtons()
        {
            if(buttonList == null)
            {
                LoadButtons();
            }

            return buttonList;
        }
    }
}
