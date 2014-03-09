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
using System.IO;

namespace gen
{
    
    class store
    {
        static int hashno = 0;
        public static List<string> filename=new List<string>();
        public static List<int> startlineno=new List<int>();
        public static List<int> endlineno = new List<int>();
        public static List<int> hashnumber = new List<int>();

        //m and c interchange
       public void add(int linecountm, int linecountc, int matchcount, int count, string line, int k, int fileno, ref string[] path,int lineno)
        {
            int ok = 0;
           // MessageBox.Show(filename.Count.ToString());
            for (int i = 0; i < filename.Count; i++)
            {
                if (path[fileno].Equals(filename[i]))
                {
                   // MessageBox.Show("calling search");
                    int m = serch(i, linecountc, linecountm, matchcount, count, line, k, fileno, ref path, lineno);
                    if (m != 0)
                    {
                      
                        ok++;
                        break;
                    }
                }
            }
            if (ok == 0)
            {
                filename.Add(path[fileno]);
                filename.Add(path[k]);
                startlineno.Add(lineno);
                startlineno.Add(count);
                endlineno.Add((linecountm + lineno ));
                endlineno.Add((count + linecountc ));
                hashnumber.Add(hashno);
                hashnumber.Add(hashno);
                hashno++;
               // Console.WriteLine("add " + path[fileno] + "  " + path[k] + "  " + lineno + "  " + count + " " + (linecountm + lineno) + "  " + (count + linecountc) + "  " + hashno);
               // MessageBox.Show("in ok  "+filename.Count.ToString());
            }
        }
       
        
        
        
       int serch(int i, int linecountc, int linecountm, int matchcount, int count, string line, int k, int fileno, ref string[] path,int lineno)
        {
           // MessageBox.Show("in search");
            int hs = hashnumber[i];
            int ok=0;
            for (int j = 0; j < filename.Count; j++)
            {
                if (hashnumber[j] == hs && j != i)
                {
                  //  MessageBox.Show("hash found");
                    if (filename[j].Equals(path[k]))
                    {
                       // MessageBox.Show("file found");
                        if (lineno > startlineno[i])
                        {
                           // MessageBox.Show("line detected in main");
                            if (count > startlineno[j])
                            {
                               // MessageBox.Show("line detected in copy");
                                if ((linecountm + lineno) == endlineno[i])
                                {
                                   // MessageBox.Show("equelity of main");
                                    if ((linecountc + count) == endlineno[j])
                                    {
                                       // MessageBox.Show("equelity of copy");
                                        ok++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ok;

           
        }
    }
}
