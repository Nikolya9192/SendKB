using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SendKB
{
    /* Программа перекладчик для відправки файлів. 
      По імені файлу у форматі <цифровий код клієнта>_хххх.ххх 
      витягуються з бази Oracle(банківська база) по коду клієнта шляхи для перекладання в них даного файлу. 
      Можна включити таймер, який з певним періодом в секундах буде запускати цикл обробки.
   */

    public partial class Form1 : Form
    {
        AccessDB accessDB = new AccessDB();
        FileName fileName = new FileName();
        ArrayList kodName = new ArrayList();
        Props props = new Props(); 
        Options options = new Options();
        Form1 f1;
        public static Point locationForm1;

        public Point y;
        
              
       
              

        public Form1()
        {    
            InitializeComponent();

             

        }

        public void Run()
        {            
            if (fileName.CheckEmptyDir(options.outFolder) == true)
            {
                fileName.GetFilesNameIn(options.outFolder);                
            }
            else
                return;
           
        }

        private void отправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            options.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Run();            
        }


        static bool isCheked;
      

        //public void Timer()
        //{ 
            
        //    Timer timer1 = new Timer();
        //    timer1.Interval = (int)number * 1000;            
        //    timer1.Tick += new EventHandler(timer1_Tick);            
        //    timer1.Enabled = isCheked;           
        //    btn_Start.Enabled = !isCheked;
        //    counter = (int)number;
            
            
        //}


        //private void timer1_Tick(object sender, EventArgs e)
        //{            
        //    Run();
        //}
        
                
        private void btn_Stop_Click(object sender, EventArgs e)
        {            
            btn_Start.Enabled = true;
        }

        private void chbx_Timer_CheckedChanged(object sender, EventArgs e)
        {
            isCheked = chbx_Timer.Checked;
            if (isCheked)
            {          
                btn_Start.Enabled = false;
                initTimer(Options.number);

            }
            else
            {
                timer.Stop();                
                lbl_Timer.Text = counter1.ToString();
                btn_Start.Enabled = true;

            }
        }

        Timer timer;
        int counter1;

        public void initTimer(int interval)
        {
            isCheked = chbx_Timer.Checked;
            lbl_Timer.Text = interval.ToString();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timerTick);
            counter1 = interval;
            timer.Start();
           
        }

        private void timerTick(Object myObject, EventArgs myEventArgs)
        {
            lbl_Timer.Text = counter1.ToString();                       
            counter1--;
            if (counter1 == -1)
            {
                btn_Start.Enabled = true;
                Run();
                btn_Start.Enabled = false;
                counter1 = Options.number;
            }
        }

        
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            Close();          
        }

      
        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            options.ReadXml();
            f1 = new Form1();
            Login lg = new Login();

            string tmp = lg.ShowLogin();
            if (tmp == "nemo")
            {
                MessageBox.Show("У доступі відмовлено.");
                this.Close();
                return;
            }

            

            lbl_interval.Text = Options.number.ToString();
            chbx_Timer.Checked = options.timer;

            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            Location = Options.locationForm1;


            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            locationForm1 = Location;
                        
        }

        public Point LocationForm1 
        { 
            get { return locationForm1; }
            set { locationForm1 = value; }
        }

       
        public Point GetLocation()
        {
            return locationForm1;
        }

        
    }

    
}
