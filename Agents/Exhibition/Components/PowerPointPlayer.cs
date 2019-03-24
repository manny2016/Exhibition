


namespace Exhibition.Components
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Exhibition.Core;
    using Exhibition.Core.Models;

    public partial class PowerPointPlayer : UserControl, IOperate
    {
        //private static PowerPointPlayer instance;
        //private static object lockObject = new object();
        //public static PowerPointPlayer CreatePowerPointPlayer(Resource resource)
        //{
        //    lock (lockObject)
        //    {
        //        if (instance == null)
        //        {
        //            lock (lockObject)
        //            {
        //                instance = new PowerPointPlayer(resource);
        //            }
        //        }
        //    }
        //    return instance;
        //}

        private Resource resource;
        public PowerPointPlayer(Resource resource) 
        {
            this.resource = resource;
            timer.Tick += Timer_Tick;
            timer.Interval = 6000;
            this.InitializeComponent();
        }
        bool bfirst = true;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (bfirst)
            {
                Thread.CurrentThread.Join(3000);
                bfirst = false;
            }
            //this.axOfficeViewer1.SlideGotoNext();
        }



     

        public void Play(Resource resource)
        {
            //this.Width = this.Parent.Width;
            //this.Height = this.Parent.Height;

            //this.axOfficeViewer1.BorderStyle = 0;
            //this.axOfficeViewer1.Top = 0;
            //this.axOfficeViewer1.Left = 0;
            //this.axOfficeViewer1.Width = this.Width;
            //this.axOfficeViewer1.Height = this.Height;
            ////this.axOfficeViewer1.Open(resource.FullName, 1, 0, 0);
           // this.axOfficeViewer1.SlideShowOpenAndPlay(resource.FullName, false,false,false,false);
            this.timer.Start();
        }

        public void Stop()
        {
            try
            {
                this.timer.Stop();
                //this.axOfficeViewer1.Close();                 
            }
            catch (Exception ex)
            {

                //this.axOfficeViewer1 = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.axOfficeViewer1.SlideShowOpenAndPlay(resource.FullName, false, false, false, false);
        }
    }
}
