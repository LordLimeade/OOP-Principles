using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase
{
    public class ErrorList
    {
        public List<string> Errors { get; set; }

        public bool hasErrors
        {
            get
            {
                if (Errors.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            private set
            {

            }
        }

        public string CompileErrors()
        {
            string sendBack = "";
            int x = 0;

            if (this.hasErrors)
            {
                foreach (string s in Errors)
                {
                    if (x == 0)
                    {
                        sendBack += s;
                        x++;
                    }
                    else
                    {
                        sendBack += "\n" + s;
                        x++;
                    }
                }
                sendBack += "\n" + "Errors Found: " + x.ToString();
                return sendBack;
            }
            else
            {
                return "No errors found.";
            }
        }

        public ErrorList()
        {
            Errors = new List<string>();
            hasErrors = false;
        }
    }
}
