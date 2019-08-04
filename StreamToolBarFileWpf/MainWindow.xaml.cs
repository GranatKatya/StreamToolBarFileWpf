using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace StreamToolBarFileWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //delegate void UpdateProgressBarDelegate(DependencyProperty dp, object value);
    public partial class MainWindow : Window
    {
        // BackgroundWorker worker;
        public MainWindow()
        {
            InitializeComponent();

            Cancel2.IsEnabled = false;
            cancel1.IsEnabled = false;


            //   worker = new BackgroundWorker();
            //  worker.DoWork += new DoWorkEventHandler(worker_DoWork);

            //BackgroundWorker worker = new BackgroundWorker();
            //worker.WorkerReportsProgress = true;
            //worker.DoWork += worker_DoWork1;
            //worker.ProgressChanged += worker_ProgressChanged1;

            //worker.RunWorkerAsync();

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  progressBar1.PerformStep();
        }


        //void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    CopyFiles();
        //}

        //Thread t = new Thread(Method);

        //// Делаем поток фоновым.
        //t.IsBackground = false; //попробовать заменить на false

        //    t.Start();

        // int t = 1;
        /// <summary>
        /// //////////////////////////////////////////
        ///   Process p = Process.GetCurrentProcess();
        //p.PriorityClass = ProcessPriorityClass.Normal;

        //    ParameterizedThreadStart ts = new ParameterizedThreadStart(Method);   
        //Thread t1 = new Thread(ts);
        //Thread t2 = new Thread(ts);

        //// Назначение приоритета потоку
        //t1.Priority = ThreadPriority.Highest;         

        //    t2.Priority = ThreadPriority.Lowest;

        //    t1.Start((object)"t1");
        //    t2.Start((object)"\t\tt2");    
        /// </summary>
        /// 
        //public void StartWorking()
        //{
        //    if (wh!=null)
        //    {
        //        wh.Set();
        //    }

        //}
        //private EventWaitHandle wh ;
        private void CopyFiles()
        {
            //  UpdateProgressBarDelegate updProgress = new UpdateProgressBarDelegate(progressBar.SetValue);


            //double value = 0;
            //foreach (string item in FilesToCopy)
            //{
            //    File.Copy(item, OutputFolderName);
            //    Dispatcher.Invoke(updProgress, new object[] { ProgressBar.ValueProperty, ++value });
            //}


        //    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
        //(ThreadStart)delegate ()
        //{


                //using (var input = new FileStream(open.Text, FileMode.Open, FileAccess.Read, FileShare.Read))
                //using (var output = new FileStream(save.Text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                //{
                //  Thread thisThread = Thread.CurrentThread;
                //  wh = new AutoResetEvent(true);


                byte[] buffer = new byte[4096];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                //if ((sender as BackgroundWorker).CancellationPending)
                //{
                //    e.Cancel = true;
                //    return;
                //}

                output.Write(buffer, 0, read);

                double pct = (1.0f * input.Position) / input.Length * 100.0f;
                //(sender as BackgroundWorker).ReportProgress((int)pct);
                //     Thread.Sleep(100);
                //   double value = 0;

                // Dispatcher.Invoke(updProgress, new object[] { ProgressBar.ValueProperty, pct });


                // Thread thisThread = Thread.CurrentThread;
                //  thisThread.Suspend();

                //   progressBar.Value += pct;
                //if (pct>50 && pct<70)
                //{
                //    thisThread.Suspend();
                //}
                //if (t<=2)
                //{
                //    wh.WaitOne();t++;
                //}

                SetText((int)pct);
                Thread.Sleep(1000);

                //  Thread.Sleep(100); // Остановка текущего потока на 1 сек.\

                //  Task.Delay(1000);
            }
            //   }//https://habr.com/ru/sandbox/38787/



            MessageBox.Show("File loaded");
            //    progressBar.Value = 0;
            SetText(0);
            input = null;
            output = null;
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    cancel1.IsEnabled = false;
                });

            //  threads1 = 0;
            //   threads--;
            //    t = 1;
            // progressBar.Maximum = 100;
            //}
            //   });

        }


        private void CopyFiles2()
        {
            Thread thisThread = Thread.CurrentThread;
            // wh = new AutoResetEvent(true);
            byte[] buffer = new byte[4096];
            int read;
            while ((read = input2.Read(buffer, 0, buffer.Length)) > 0)
            {
                output2.Write(buffer, 0, read);
                double pct = (1.0f * input2.Position) / input2.Length * 100.0f;

                SetText2((int)pct);
                Thread.Sleep(1000);
            }
            MessageBox.Show("File loaded");
            SetText2(0);
            input2 = null;
            output2 = null;
          
            Application.Current.Dispatcher.Invoke(() => Cancel2.IsEnabled = false);

           Application.Current.Dispatcher.Invoke(() => Stakpanel.Visibility = Visibility.Hidden);

            // Stakpanel.Visibility = Visibility.Hidden;

            //  threads2 = 0;
        }


        private void SetText(int text)
        {

            if (!progressBar.Dispatcher.CheckAccess())
            {
                Action<int> d = new Action<int>(SetText);
                Dispatcher.Invoke(d, new object[] { text });
            }
            else
            {

                this.progressBar.Value = text;


            }
        }

        private void SetText2(int text)
        {

            if (!progressBar2.Dispatcher.CheckAccess())
            {
                Action<int> d = new Action<int>(SetText2);
                Dispatcher.Invoke(d, new object[] { text });
            }
            else
            {

                this.progressBar2.Value = text;


            }
        }


        FileStream input = null;
        FileStream output = null;
        //int threads1 = 0;
        // int threads2 = 0;

        FileStream input2 = null;
        FileStream output2 = null;
        //  int threads3 = 0;

        Thread threadS;
        Thread threadS2;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // worker.RunWorkerAsync();



            //    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            //(ThreadStart)delegate ()
            //{
            //  worker.RunWorkerAsync();

            //      UpdateProgressBarDelegate updProgress = new UpdateProgressBarDelegate(progressBar.SetValue);


            if (!String.IsNullOrEmpty(save.Text) && !String.IsNullOrEmpty(open.Text))
            {

                if (input == null && output == null)
                {
                    input = new FileStream(open.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
                    output = new FileStream(save.Text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

                    progressBar.Maximum = 100;// (int)input.Length;// = 100;// (int)input.Length;

                    // Создание делегата, связанного с методом.
                    ThreadStart threadstartS = new ThreadStart(CopyFiles);

                    // Создание объекта потока.
                    threadS = new Thread(threadstartS);
                    threadS.Start(); // Запуск работы потока.
                                     //   threads1++;
                                     // threads2 = 1;
                    cancel1.IsEnabled = true;
                }
                // else if (threads2 == 1)
                else if (input2 == null && output2 == null)
                {
                    input2 = new FileStream(open.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
                    output2 = new FileStream(save.Text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

                    Stakpanel.Visibility = Visibility.Visible;
                    progressBar2.Maximum = 100;
                    ThreadStart threadstarts2 = new ThreadStart(CopyFiles2);

                    // Создание объекта потока.
                    threadS2 = new Thread(threadstarts2);
                    threadS2.Start(); // Запуск работы потока.
                                      //  threads2++;

                    Cancel2.IsEnabled = true;
                }
                else if ((input != null && output != null) && (input2 != null && output2 != null))
                {
                    MessageBox.Show("you cant create more than 2 process");
                    open.Text = "";
                    save.Text = "";
                    return;
                }

                //   worker.RunWorkerAsync();


                open.Text = "";
                save.Text = "";


            }
            else
            {
                MessageBox.Show("Enter path");
            }













            /////////////////////////////////////////////////////////////////////////////////////
            //if (!String.IsNullOrEmpty(save.Text) && !String.IsNullOrEmpty(open.Text))
            //{
            //    using (var input = new FileStream(open.Text, FileMode.Open, FileAccess.Read, FileShare.Read))
            //    using (var output = new FileStream(save.Text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            //    {
            //        progressBar.Maximum = 100;// (int)input.Length;// = 100;// (int)input.Length;

            //        byte[] buffer = new byte[4096];
            //        int read;
            //        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            //        {
            //            //if ((sender as BackgroundWorker).CancellationPending)
            //            //{
            //            //    e.Cancel = true;
            //            //    return;
            //            //}

            //            output.Write(buffer, 0, read);

            //            float pct = (1.0f * input.Position) / input.Length * 100.0f;
            //            //(sender as BackgroundWorker).ReportProgress((int)pct);
            //            //     Thread.Sleep(100);

            //            Dispatcher.Invoke(updProgress, new object[] { ProgressBar.ValueProperty, pct });
            //          //  progressBar.Value += pct;

            //            //Task.Delay(2000);
            //            // Thread.Sleep(1000);
            //        }
            //    }
            //}
            //else { MessageBox.Show("Enter path"); }



            //open.Text = "";
            //save.Text = "";
            //MessageBox.Show("File loaded");
            //progressBar.Value = 0;
            //progressBar.Maximum = 100;

            /////////////////////////////////////////////////////////////////////////////////////





















            //if (save.Text == "" || open.Text == "")
            //{
            //    MessageBox.Show("Enter path");
            //}
            //if (!String.IsNullOrEmpty(save.Text) && !String.IsNullOrEmpty(open.Text))
            //{
            //    try
            //    {
            //        FileStream fromStream = new FileStream(open.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
            //        FileStream sourceStream = new FileStream(save.Text, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            //        long  filSize = fromStream.Length;

            //        byte[] b = new byte[4096];
            //        byte[] buffer = new byte[fromStream.Length];

            // progressBar.Maximum = (int)fromStream.Length;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Внимание!", MessageBoxButton.OK);
            //    }

            //}
            //else { MessageBox.Show("Enter path"); }



        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                open.Text = openFileDialog.FileName;   // File.ReadAllText(openFileDialog.FileName);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = save.Text;
            if (saveFileDialog.ShowDialog() == true)
                save.Text = saveFileDialog.FileName;        //   File.WriteAllText(saveFileDialog.FileName, save.Text);
        }


        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    BackgroundWorker worker;
        //    worker = new BackgroundWorker();
        //    worker.WorkerReportsProgress = true;
        //    worker.DoWork += worker_DoWork;
        //    worker.ProgressChanged += worker_ProgressChanged;

        //    worker.RunWorkerAsync();
        //    // Application.Current.Dispatcher.Invoke(() => worker.RunWorkerAsync());

        //    //this.Dispatcher.Invoke(new Action(
        //    //                delegate () {  worker.RunWorkerAsync(); }));

        //    //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
        //    //(ThreadStart)delegate ()
        //    //{
        //    //    worker.RunWorkerAsync();
        //    //}
        //    //);
        //}
        //private void worker_DoWork(object sender, DoWorkEventArgs e)
        //{


        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////



        //void worker_DoWork1(object sender, DoWorkEventArgs e)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        (sender as BackgroundWorker).ReportProgress(i);
        //        Thread.Sleep(100);
        //    }
        //}

        //void worker_ProgressChanged1(object sender, ProgressChangedEventArgs e)
        //{
        //    progressBar.Value = e.ProgressPercentage;
        //}




        //private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressBar.Value = e.ProgressPercentage;
        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        MessageBox.Show("Копирование отменено!");
        //        return;
        //    }

        //    if (e.Error != null)
        //    {
        //        MessageBox.Show("Ошибка копирования: " + e.Error.Message);
        //        return;
        //    }

        //    MessageBox.Show("Копирование завершено!");
        //}




        private void Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_2(sender, e);


                //worker.RunWorkerAsync();



                //  int a = 0;
            }// startBtn.PerformClick();
        }

        private void Suspend(object sender, RoutedEventArgs e)
        {
            try
            {
                if (threadS != null)
                {
                    threadS.Suspend();
                    cancel1.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Resume(object sender, RoutedEventArgs e)
        {


            try
            {

                threadS.Resume();
                cancel1.IsEnabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Thread dont suspend. You cant resume it");
            }
        }

        private void Suspend2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (threadS2 != null)
                {
                    threadS2.Suspend();
                    Cancel2.IsEnabled = false;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Resume2(object sender, RoutedEventArgs e)
        {

            try
            {
                threadS2.Resume();
                Cancel2.IsEnabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)//2
        {
            try
            {
                
                    threadS2.Abort();
              //  threadS2.Join();

              //  threadS2.Abort();

                progressBar2.Value = 0;
                input2 = null;
                output2 = null;
               Stakpanel.Visibility = Visibility.Hidden;
               Cancel2.IsEnabled = false;
                SetText2(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Thread dont suspend. You cant abort it");
            }
        }

        private void Cancel1(object sender, RoutedEventArgs e)//1
        {
            try
            {
                if (threadS.ThreadState != ThreadState.Suspended)
                {
                    threadS.Abort();
                   // threadS.Join();

                    progressBar.Value = 0;
                    input = null;
                    output = null;
                    cancel1.IsEnabled = false;
                  //  threadS.Abort();
                    SetText(0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thread dont suspend. You cant abort it");
            }
        }
    }

}


//private void stopBtn_Click(object sender, EventArgs e)
//{
//    if (worker != null)
//    {
//        worker.Cancel();
//    }
//}