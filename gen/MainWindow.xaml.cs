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
using System.Windows.Forms;
using System.Threading;
using System.Configuration;

namespace gen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            nev.IsReadOnly = true;
            nev.Text = "";
            lns.Text = "";
            pro.Visibility = System.Windows.Visibility.Collapsed;
           sbar.Visibility = System.Windows.Visibility.Collapsed;
           // dg.Visibility = System.Windows.Visibility.Collapsed;
        }



       public string[] path;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.c;*.cpp;*.java;*.cs;)|*.c;*.cpp;*.java;*.cs|" + "All files (*.*)|*.*";
            ofd.Multiselect = true;
            // Show the dialog and get result.
            DialogResult result = ofd.ShowDialog();
            Console.WriteLine(result);

            if (result.ToString() == "OK") // Test result.
            {
                path = ofd.FileNames;
                FileInfo x = new FileInfo(path[0]);
                DirectoryInfo dir = x.Directory;
                nev.Text = dir.ToString();
               
               

               
            }
            

        }



        string pathf;
        //string[] p=new string[1000];
       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
             
            folderDialog.ShowNewFolderButton = false;
            DialogResult result = folderDialog.ShowDialog();

            if (result.ToString() == "OK")
            {
                pathf = folderDialog.SelectedPath;
                nev.Text = pathf;
               // string[] p = Directory.GetFiles(@pathf, "*.*", SearchOption.AllDirectories);
                string[] extensions = { "java", "cs", "c", "cpp" };

                path = Directory.GetFiles(@pathf, "*.*", SearchOption.AllDirectories)
                    .Where(f => extensions.Contains(f.Split('.').Last().ToLower())).ToArray();
                

                
               }
          

        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
              System.Windows.MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow(null, _caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        int i;
        Thread t;
        Thread tp;
        //async
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!lns.Text.Equals("") && !nev.Text.Equals(""))
            {
                Thread th = Thread.CurrentThread;
                th.Name = "main";
                //th.Start();
              //  th = new Thread(MakeOne);
                                   
                bfile.Visibility = System.Windows.Visibility.Collapsed;
                bdict.Visibility = System.Windows.Visibility.Collapsed;
                label1.Visibility = System.Windows.Visibility.Collapsed;
                lns.Visibility = System.Windows.Visibility.Collapsed;
                bdict.Visibility = System.Windows.Visibility.Collapsed;
                search.Visibility = System.Windows.Visibility.Collapsed;
                pro.Visibility = System.Windows.Visibility.Visible;
                sbar.Visibility = System.Windows.Visibility.Visible;
                
                MakeOne();

               AutoClosingMessageBox.Show("Prosses Start", "Info", 1000);
                i = Convert.ToInt16(lns.Text);
                t = new Thread(tbp);

                   
                

                t.Name = "backprocess";
              
               // t.Start();
              
               //t.Join();
                await Task.Run(()=>tbp());

   
               AutoClosingMessageBox.Show("Prosses Complite", "Info", 1000);

                Duplicate_Code dc = new Duplicate_Code();
                dc.Show();
                this.Close();

       
               
            }
            else
            {
                System.Windows.MessageBox.Show("fill all entery's");
            }
        }

        public void tbp()
        {
            
           // Thread ts = new Thread(MakeOne);
           // ts.Start();
            read a = new read();
            // Thread t1=new Thread(new ThreadStart(new (a.readfile(ref path,i))));
            a.readfile(ref path, i);
        }

        private  void MakeOne()
        {

            
            sbar.Items.Clear();
            System.Windows.Controls.Label lbl = new System.Windows.Controls.Label();
            lbl.Background = new LinearGradientBrush(Colors.Pink, Colors.Red, 90);
            lbl.Content = "Indeterminate ProgressBar.";
            //sbar.Items.Add(lbl);
            //<Snippet3>
            System.Windows.Controls.ProgressBar progbar = new System.Windows.Controls.ProgressBar();
            progbar.Background = Brushes.Gray;
            progbar.Foreground = Brushes.Green;
            progbar.Width = 257;
            progbar.Height = 21;
            progbar.IsIndeterminate = true;
            //</Snippet3>
            sbar.Items.Add(progbar);
           


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nev_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            
        }
  
        private void lns_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }


        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           // Environment.Exit(0);
            //t.Abort();
        }   
    }
}
