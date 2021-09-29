using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;

namespace SendKB
{
    [Serializable]
    public class Props
    {

        public Props()
        { 
        }
                
        public string OutFolder { get; set; }
        public int Number { get; set; }
        public bool Timer { get; set; }
        public Point LocationForm1 { get; set;}
        public string Login { get; set; }
        public string Baza { get; set; }

        

        public Props(string outfolder, int number, bool timer, Point locationForm1, string login, string baza)
        {
            this.OutFolder = outfolder;
            this.Number = number;
            this.Timer = timer;
            this.LocationForm1 = locationForm1;
            this.Login = login;
            this.Baza = baza;
            
        }

       
        
    }
}
