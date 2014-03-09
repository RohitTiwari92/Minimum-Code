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
    class match
    {

       public void selectlinematch(ref string[] path, string line, int fileno, int lineno, int i)
        {

            StreamReader refline = new StreamReader(@path[fileno]);
            string reflinestring;

            for (int lc = 0; lc < lineno - 1; lc++)
            {
                reflinestring = refline.ReadLine();
            }
            reflinestring = refline.ReadLine();

            for (int mfp = fileno; mfp < path.Length; mfp++)
            {
                
                StreamReader ccff = new StreamReader(@path[mfp]);

                int count = 0;
                string matchline;
                if (mfp == fileno)
                {
                    for (int lc = 0; lc < lineno - 1; lc++)
                    {
                        ccff.ReadLine();

                        count++;
                        //  MessageBox.Show(count.ToString());
                    }
                    ccff.ReadLine();
                    count++;
                    int ok = 0;
                    while ((matchline = ccff.ReadLine()) != null)
                    {
                        count++;
                        ok++;
                        matchline = matchline.Trim();
                        if (matchline.StartsWith("/*"))
                        {


                            while (!matchline.EndsWith("*/"))
                            {


                                matchline = ccff.ReadLine();
                                count++;
                            }

                            continue;
                        }
                        if (matchline.Equals(""))
                        {

                            continue;
                        }
                        if (matchline.StartsWith("//") || matchline.StartsWith("///"))
                        {

                            continue;
                        }
                        // MessageBox.Show(count.ToString());


                        if (matchline.Equals(line))
                        {
                            int linecountm = 0;
                            int linecountc = 0;
                            int matchcount = 0;

                            //  MessageBox.Show(count.ToString());
                            //Console.WriteLine("hello match found   " + line+"     " + matchline +"    "+ fileno+" "+mfp);
                           // MessageBox.Show("match found    " + matchline + "    " + line + "   " + count);
                            string xread, yread;
                            int k = 0;
                            StreamReader mc = new StreamReader(@path[fileno]);
                            StreamReader ccd = new StreamReader(@path[mfp]);
                            while (true)
                            {

                                if (k == 0)
                                {
                                    // MessageBox.Show(count.ToString());
                                    for (int lc = 0; lc < count; lc++)
                                    {

                                        ccd.ReadLine();

                                    }



                                    for (int lc = 0; lc <= lineno - 1; lc++)
                                    {

                                        mc.ReadLine();

                                    }

                                    k++;

                                }
                                xread = mc.ReadLine();
                                yread = ccd.ReadLine();
                                //Console.WriteLine("mc in differnt file  :" + ());
                                //Console.WriteLine("ccd in diffrnt file  :" + ());
                              //    MessageBox.Show("in the hole "+xread + "      " + yread);
                                if (xread == null)
                                    break;
                                if (yread == null)
                                    break;
                                xread = xread.Trim();
                                yread = yread.Trim();


                                linecountc++;
                                linecountm++;


                                while (true)
                                {
                                    if (xread == null)
                                        break;
                                    if (xread.StartsWith("/*"))
                                    {


                                        while (!xread.EndsWith("*/"))
                                        {


                                            xread = mc.ReadLine();
                                            linecountc++;
                                         //   MessageBox.Show("*/ " + xread);
                                            if (xread == null)
                                                break;
                                            xread = xread.Trim();

                                        }
                                        xread = mc.ReadLine();
                                        linecountc++;
                                        if (xread == null)
                                            break;
                                        xread = xread.Trim();
                                      //  MessageBox.Show("/* xread" + xread);
                                        continue;
                                    }
                                    if (xread.Equals(""))
                                    {
                                        xread = mc.ReadLine();
                                        linecountc++;
                                       // MessageBox.Show("emp xread" + xread);
                                        if (xread == null)
                                            break;
                                        xread = xread.Trim();
                                      
                                        continue;
                                    }
                                    if (xread.StartsWith("//") || xread.StartsWith("///"))
                                    {

                                        xread = mc.ReadLine();
                                        linecountc++;
                                    //    MessageBox.Show("// xread" + xread);
                                        if (xread == null)
                                            break;
                                        xread = xread.Trim();
                                       
                                        continue;
                                    }
                                    break;
                                }

                             //   MessageBox.Show("after decommenting xread" + xread);

                                while (true)
                                {
                                    if (yread == null)
                                        break;
                                    if (yread.StartsWith("/*"))
                                    {


                                        while (!yread.EndsWith("*/"))
                                        {


                                            yread =ccd.ReadLine();
                                           // MessageBox.Show("/* yread" + yread);
                                            linecountm++;
                                            if (yread == null)
                                                break;
                                            yread = yread.Trim();
                                           // MessageBox.Show("*/ yread" + yread);
                                        }
                                        yread = ccd.ReadLine();
                                      //  MessageBox.Show("*/ yread" + yread);
                                        linecountm++;
                                        if (yread == null)
                                            break;
                                        yread = yread.Trim();
                                        continue;
                                    }
                                    if (yread.Equals(""))
                                    {
                                        yread = ccd.ReadLine();
                                        linecountm++;
                                      //  MessageBox.Show("emp yread" + yread);
                                        if (yread == null)
                                            break;
                                        yread = yread.Trim();

                                        continue;
                                    }
                                    if (yread.StartsWith("//") || yread.StartsWith("///"))
                                    {

                                        yread = ccd.ReadLine();
                                        linecountm++;
                                       // MessageBox.Show("// " + yread);
                                        if (yread == null)
                                            break;
                                        yread = yread.Trim();

                                        continue;
                                    }
                                    break;
                                }



                             //   MessageBox.Show("after decommenting yread" + yread);


                              //  MessageBox.Show("after read before null" + xread + "   " + yread);

                                if (xread == null || yread == null)
                                {
                                    break;
                                }
                                //Console.WriteLine("CONTINUE match  " + xread + "  " + yread);
                              //  MessageBox.Show("after read "+xread + "   " + yread);
                                if (xread.Equals(yread))
                                {
                                  //  MessageBox.Show("continue match found  " + xread + "   " + yread);
                                    //Console.WriteLine("cotinue    " + xread + "   " + yread);
                                    matchcount++;
                                }
                                else
                                {
                                    // MessageBox.Show("in k==fileno"+"linecountc:  " + linecountc + " linecountm:  " + linecountm + " matchcount:  " + matchcount + " count:  " + count + " line:  " + line + " k:  " + k + " fileno:  " + fileno + " lineno: " + lineno); 

                                    break;
                                }



                            }
                            if (i <= matchcount + 1)
                            {
                                store obj = new store();
                               //  MessageBox.Show("linecountc:  " + linecountc + " linecountm:  " + linecountm + " matchcount:  " + matchcount + " count:  " + count + " line:  " + line + " mfp  " + mfp + " fileno:  " + fileno + " lineno: " + lineno); 
                                obj.add(linecountc, linecountm, matchcount, count, line, mfp, fileno, ref path, lineno);

                            }


                        }







                    }


                }
                else
                {
                    int ok = 0;
                    while ((matchline = ccff.ReadLine()) != null)
                    {
                        ok++;
                        count++;
                        matchline = matchline.Trim();
                        if (matchline.StartsWith("/*"))
                        {


                            while (!matchline.EndsWith("*/"))
                            {


                                matchline = ccff.ReadLine();
                                count++;
                                // MessageBox.Show(count.ToString());
                            }

                            continue;
                        }
                        if (matchline.Equals(""))
                        {

                            continue;
                        }
                        if (matchline.StartsWith("//") || matchline.StartsWith("///"))
                        {

                            continue;
                        }
                        // int linecount = 0;
                        //  MessageBox.Show(count.ToString());
                        if (matchline.Equals(line))
                        {
                            int linecountm = 0;
                            int linecountc = 0;
                            int matchcount = 0;

                            //  MessageBox.Show(count.ToString());
                            // Console.WriteLine("hello match found   " + line +"   "+ matchline + "        "+fileno);
                           // MessageBox.Show("match found    " + matchline + "    " + line + "   " + count);
                            // MessageBox.Show(count.ToString());
                            string xread, yread;
                            int k = 0;
                            StreamReader mc = new StreamReader(@path[fileno]);
                            StreamReader ccd = new StreamReader(@path[mfp]);
                            while (true)
                            {

                                if (k == 0)
                                {

                                    for (int lc = 0; lc < count; lc++)
                                    {

                                        ccd.ReadLine();

                                    }



                                    for (int lc = 0; lc <= lineno - 1; lc++)
                                    {

                                        mc.ReadLine();

                                    }

                                    k++;

                                }

                                xread = mc.ReadLine();
                                yread = ccd.ReadLine();
                                //Console.WriteLine("mc in differnt file  :" +());
                                //Console.WriteLine("ccd in diffrnt file  :" + ());
                                //  MessageBox.Show(" firdt read "+xread+"     "+yread+"  "+count);
                                if (xread == null || yread == null)
                                {
                                    break;
                                }

                                xread = xread.Trim();
                                yread = yread.Trim();

                                linecountc++;
                                linecountm++;

                                while (true)
                                {
                                    if (xread == null)
                                        break;
                                    if (xread.StartsWith("/*"))
                                    {

                                      //  MessageBox.Show("/* xread" + xread);
                                        while (!xread.EndsWith("*/"))
                                        {


                                            xread = mc.ReadLine();
                                            linecountc++;
                                         //   MessageBox.Show("*/ xread" + xread);
                                            if (xread == null)
                                                break;
                                            xread = xread.Trim();

                                        }
                                        xread = mc.ReadLine();
                                        linecountc++;
                                       // MessageBox.Show("*/ xread" + xread);
                                        if (xread == null)
                                            break;
                                        xread = xread.Trim();
                                        continue;
                                    }
                                    if (xread.Equals(""))
                                    {
                                        xread = mc.ReadLine();
                                        linecountc++;
                                      //  MessageBox.Show("emp xread" + xread);
                                        if (xread == null)
                                            break;
                                        xread = xread.Trim();
                                        continue;
                                    }
                                    if (xread.StartsWith("//") || xread.StartsWith("///"))
                                    {

                                        xread = mc.ReadLine();
                                       // MessageBox.Show("// xread" + xread);
                                        linecountc++;
                                        if (xread == null)
                                            break;
                                        xread = xread.Trim();
                                      //  MessageBox.Show(xread);                    
                                        continue;
                                    }
                                    break;
                                }


                               // MessageBox.Show("after decomment xread" + xread);
                                while (true)
                                {
                                    if (yread == null)
                                        break;
                                    if (yread.StartsWith("/*"))
                                    {
                                      //  MessageBox.Show("/* yread" + yread);

                                        while (!yread.EndsWith("*/"))
                                        {


                                            yread = ccd.ReadLine();
                                            linecountm++;
                                           // MessageBox.Show("*/ yread" + yread);
                                            if (yread == null)
                                                break;
                                            yread = yread.Trim();
                                        }
                                        yread = ccd.ReadLine();
                                      //  MessageBox.Show("/* yread" + yread);
                                        linecountm++;
                                        if (yread == null)
                                            break;
                                        yread = yread.Trim();
                                        continue;
                                    }
                                    if (yread.Equals(""))
                                    {
                                        yread = ccd.ReadLine();
                                        linecountm++;
                                      //  MessageBox.Show("emp yread" + yread);
                                        if (yread == null)
                                            break;
                                        yread = yread.Trim();
                                        continue;
                                    }
                                    if (yread.StartsWith("//") || yread.StartsWith("///"))
                                    {

                                        yread = ccd.ReadLine();
                                        linecountm++;
                                     //   MessageBox.Show("// yread" + yread);
                                        if (yread == null)
                                            break;
                                        yread = yread.Trim();
                                      //  MessageBox.Show(yread);    
                                        continue;
                                    }
                                    break;
                                }
                             //   MessageBox.Show("after decommenting yread" + yread);
                             //   MessageBox.Show("before null "+xread + "   " + yread);
                                // Console.WriteLine("CONTINUE match  " + xread + "  " + yread);
                                if (xread == null || yread == null)
                                {
                                    break;
                                }
                             //   MessageBox.Show("after null "+xread + "   " + yread);
                                if (xread.Equals(yread))
                                {
                                   // MessageBox.Show("continue match found  " + xread + "  " + yread);
                                    //Console.WriteLine("cotinue    "+xread+"   "+yread);
                                    matchcount++;
                                }
                                else
                                {
                                    // MessageBox.Show("in k=> fileno linecountc:  " + linecountc + " linecountm:  " + linecountm + " matchcount:  " + matchcount + " count:  " + count + " line:  " + line + " k:  " + k + " fileno:  " + fileno + " lineno: " + lineno); 

                                    break;
                                }



                            }
                            if (i <= matchcount + 1)
                            {
                                store obj = new store();
                                // MessageBox.Show("linecountc:  " + linecountc + " linecountm:  " + linecountm + " matchcount:  " + matchcount + " count:  " + count + " line:  " + line + " mfp  " +mfp + " fileno:  " + fileno + " lineno: " + lineno); 
                                obj.add(linecountc, linecountm, matchcount, count, line, mfp, fileno, ref path, lineno);
                            }


                        }







                    }


                }
            }


        }
    }
}
