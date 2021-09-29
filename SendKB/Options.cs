using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace SendKB
{
    [Serializable]
    public partial class Options : Form
    {
        Form1 f1; 
        Props props;
        //Login login = new Login();
        
        //Путь до файла настроек
        public String xmlFileName = Environment.CurrentDirectory + "\\settings.xml";

        public string outFolder;
        public static int number;
        public bool timer;
        public Point ocationForm1;
        public Point Ly;
        public static Point locationForm1;
        public Point y;
        public static string login_;
        public static string baza_;
       


        
        public Options()
        {
            InitializeComponent();
            
           
        }

        private void Options_Load(object sender, EventArgs e)
        {                       
            //ReadXml();
            tb_OutFolder.Text = outFolder;
            txbx_OptionsInterval.Text = number.ToString();
            Timer_On_Off_chbx.Checked = timer;
            
        }
                
       
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void btn_Save_Click(object sender, EventArgs e)
        {
            SaveOptions();
        }

        public void SaveOptions()
        {
            if (DialogResult == DialogResult.OK)
            {
                if ((tb_OutFolder.Text != "") && (txbx_OptionsInterval.Text.Trim()!= null ))
                {                    
                    outFolder = tb_OutFolder.Text;
                    number = Convert.ToInt32(txbx_OptionsInterval.Text);
                    timer = Timer_On_Off_chbx.Checked;
                    f1 = new Form1();
                    f1.GetLocation();
                    locationForm1 = f1.LocationForm1;                   
                    props = new Props(outFolder, number, timer, locationForm1, Login.login, Login.baza );//, Ly);
                    WriteXml();
                }
                else
                {
                    MessageBox.Show("Виберіть ім'я каталогу");
                    DialogResult = DialogResult.None;
                }
            }
        }

        
        private void btn_OutFolderSend_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
               tb_OutFolder.Text = folderBrowserDialog1.SelectedPath;
            }
              
        }

        public void WriteXml()
        {
           
            XmlSerializer ser = new XmlSerializer(typeof(Props));            
            TextWriter writer = new StreamWriter(xmlFileName);
            ser.Serialize(writer, props);
            writer.Close();
        }
      

        public void ReadXml()
        {
            
            if (File.Exists(xmlFileName))
            {
                props = new Props();
                XmlSerializer ser =  new XmlSerializer(typeof(Props));
                TextReader reader = new StreamReader(xmlFileName);
                //FileStream reader = new FileStream(Application.StartupPath + xmlFileName, FileMode.Open);
                props = (Props)ser.Deserialize(reader);                
                reader.Close();

                outFolder = props.OutFolder;
                number = props.Number;
                timer = props.Timer;
                locationForm1 = props.LocationForm1;
                login_ = props.Login;
                baza_ = props.Baza;
               


            }
            else
            {
                MessageBox.Show("Файл конфигурации " + xmlFileName + "не найден");
            }


        }

       

        
    }
}
