using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exhibition.Components;
using Exhibition.Core;
using Exhibition.Core.Configuration;
using Exhibition.Core.Models;

namespace Exhibition
{
    public partial class FrmContainer : Form
    {
        private UserControl player;
        public FrmContainer()
        {
            InitializeComponent();
            this.Load += FrmContainer_Load;
            Host.Operate += Host_Operate;
        }


        Settings settings = ExhibitionConfiguration.GetSettings();
        private void FrmContainer_Load(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length > 1)
            {
                var screen = Screen.AllScreens[settings.DefaultMonitor - 1];
                this.Location = new Point(screen.Bounds.X, screen.Bounds.Y);
                this.Width = screen.Bounds.Width;
                this.Height = screen.Bounds.Height;
            }
            this.DisposePlayer();

        }
        private void Locating()
        {
            if (Screen.AllScreens.Length > 1)
            {
                var screen = Screen.AllScreens[settings.DefaultMonitor - 1];
                this.Location = new Point(screen.Bounds.X, screen.Bounds.Y);
                this.Width = screen.Bounds.Width;
                this.Height = screen.Bounds.Height;
            }
        }
        private void Host_Operate(object sender, OperatorEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OperationEventHandler(this.InvokeOperate), sender, e);
            }
            else
            {
                this.InvokeOperate(sender, e);
            }

        }
        private void InvokeOperate(object sender, OperatorEventArgs e)
        {

            switch (e.Type)
            {
                case OperationTypes.Play:
                    this.ReadytoPlay(e.Resource);
                    ((IOperate)this.player).Play(e.Resource);
                    break;
                case OperationTypes.Stop:
                    this.DisposePlayer();
                    break;
            }
        }
        private UserControl CreatePlayer(Resource resource)
        {
            switch (resource.Type)
            {
                case ResourceType.ImageFolder:
                    return new ImagePlayer(resource);
                case ResourceType.PowerPoint:
                    //return new PowerPointPlayer(resource);
                default:
                    break;

            }
            throw new NotSupportedException(resource.SerializeToJson());
        }
        private void ReadytoPlay(Resource resource)
        {
            if (this.player != null)
            {
                ((IOperate)this.player).Stop();
            }
            this.SuspendLayout();
            this.player = CreatePlayer(resource);
            this.Controls.Add(this.player);
            this.ResumeLayout(false);
        }
        private void DisposePlayer()
        {
            if (player != null)
            {
                ((IOperate)this.player).Stop();
                this.Controls.Remove(player);
                this.player.Dispose();
                this.player = null;
            }
        }

    }
}
