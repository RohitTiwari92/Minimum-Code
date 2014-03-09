using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;

namespace gen
{
    class read
    {
               
        public void readfile(ref string[] path,int i) 
        {
            Thread g=Thread.CurrentThread;

            //  g.Name="dr";
           // MessageBox.Show(g.Name);
            int fileno=0, lineno;
            foreach (string s in path)
            {
                Thread.Sleep(100);
                lineno = 0;
                StreamReader read = new StreamReader(@s);
                string line;
              //  MessageBox.Show("sleep");

               
               // MessageBox.Show("awake");
                while ((line = read.ReadLine()) != null)
                {
                       
                    line = line.Trim();
                    if (line.StartsWith("/*") )
                    {
                        
                        lineno++;
                        while (!line.EndsWith("*/"))
                        {

                        
                         line=   read.ReadLine();
                            lineno++;
                        }
                        
                        continue;   
                    }
                    if (line.Equals(""))
                    {
                        lineno++;
                        continue;
                    }
                    if (line.StartsWith("//") || line.StartsWith("///"))
                    {

                         
                        lineno++;
                        continue;
                    }
                   
                    lineno++;
                   // Console.WriteLine("in first function   :"+line + "  " + lineno+"  "+fileno+"  "+s);
                    match ma = new match();
                   
                    ma.selectlinematch(ref path, line, fileno, lineno,i);
                               
                   

                }
                fileno++; 
                
                                            
            }
          
 
        }
















        

    }
}
