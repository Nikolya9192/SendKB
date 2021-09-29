using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Numeric;


namespace SendKB
{

   
    class FileName
    {
        Props props = new Props();
        Options options = new Options();
        
        
        AccessDB accessDB = new AccessDB();
        
        public void GetFilesNameIn(string src)
        {
            ArrayList ArlKodFileName = new ArrayList();
            //string src = options.outFolder;

            DirectoryInfo di = new DirectoryInfo(src);
            foreach (FileSystemInfo fsi in di.GetFiles())
            {
                if (fsi.Name.Contains("_"))
                {
                    char[] chr = { '_' };
                    string fname = fsi.Name.ToString();
                    int numb = fname.IndexOfAny(chr);
                    string s = fname.Substring(0, numb);
                    int kod;                    
                    bool result = Int32.TryParse(s, out kod);
                    if (result == true && kod != 0)
                    {
                        ArlKodFileName = accessDB.Connect(kod);
                        if (ArlKodFileName.Count != 0)
                        {                            
                            GetPathToOutAttach(src, fsi.Name, ArlKodFileName);
                        }
                        
                    }   
                }
            }
            
            //return ArlKodFileName;
        }

        private void LogTxt(string fileName)
        {
            string datetimenow = DateTime.Now.ToString();
            string path = String.Format(Application.StartupPath + @"\history.txt");
            string text = String.Format("{0} -  {1}", datetimenow, fileName);
            
            bool flag = File.Exists(path);                
            StreamWriter streamWriter = new StreamWriter(path, flag, Encoding.GetEncoding(1251));                
            streamWriter.WriteLine(text);
            streamWriter.Close();
           
        }
            
                

        public bool CheckEmptyDir(string src)
        {
            DirectoryInfo di = new DirectoryInfo(src);

            if (di.GetFiles().Count() != 0)
                return true;
            else
                return false;
        }
        
        string archdir = "";

        public void Atribut(string path)
        {
            //    if (!File.Exists(path)) 
            //{
            //    File.Create(path);
            //}

            FileAttributes attributes = File.GetAttributes(path);

            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                // Show the file.
                //attributes = File. RemoveAttribute(attributes, FileAttributes.ReadOnly);
                File.SetAttributes(path, attributes);
                
            } 
        }


        public bool CheckArchDir()
        {
            string path = String.Format(Application.StartupPath);
            DirectoryInfo di = new DirectoryInfo(path);

            DirectoryInfo diArch = new DirectoryInfo(path + @"\Arch");

            if (diArch.Exists == true)
            {
                archdir = path + @"\Arch";
                Atribut(archdir);
                return true;
            }
            else
            {
                archdir = di.CreateSubdirectory("Arch").ToString();
                Atribut(archdir);
                return true;
            }
            
        }

        public void GetPathToOutAttach(string filepath, string fileName, ArrayList arlPath)
        {
            int count = 1; 
            foreach (string pathToCopy in arlPath)
            {
                string filePath = filepath + "\\" + fileName;
                string outdir = pathToCopy + "\\" + fileName;

                string errmesfile = String.Format(Application.StartupPath + @"\SendErrMes.bat");


                //Копіювання в Arch
                if (CheckArchDir() == true)
                {
                    File.Copy(filePath, outdir, true); //(filePath, archdir + "\\" + fileName, true)
                    LogTxt(outdir);
                }
                
                //Копіювання в Arch та Видалення з Out
                try
                {
                    if (arlPath.Count - count == 0)
                    {
                        File.Copy(filePath, archdir + "\\" + fileName, true); //(archdir + "\\" + fileName, outdir, true);

                        if (File.Exists(archdir + "\\" + fileName) == true)
                            File.Delete(filePath);
                        else
                            MessageBox.Show("Не удается скопировать в архив " + fileName);
                    }
                    else
                    {
                        count = count + 1;
                        //return;
                    }
                }
                catch (Exception e)
                {
                    string args = String.Format(@"""Программа Отправки файлов по Клиент-банку SendKB вызвала ошибку отправки. {0} Пользователю необходимо закрыть файл. """, e.Message.ToString());
                    if (File.Exists(errmesfile))
                        System.Diagnostics.Process.Start(errmesfile, args);
                    else                       
                        MessageBox.Show("Не найден файл рассылки сообщений " + errmesfile, "Отправка сообщений по КБ (SendKB)",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Якщо файл видалено з Out, тоді копіювання клієнту в папку і запис в history
                //if (!File.Exists(filePath))
                //{
                //    File.Copy(archdir + "\\" + fileName, outdir, true); //(archdir + "\\" + fileName, outdir, true);
                //    LogTxt(fileName);
                //}
            }
        }

    }
}
