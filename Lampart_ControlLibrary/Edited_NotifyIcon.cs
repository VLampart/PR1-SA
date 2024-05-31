using System.ComponentModel;

namespace Lampart_ControlLibrary
{
    [ToolboxBitmap(@"Lr01_Lampart\Lampart_ControlLibrary\Lampart_UserControl.ico")]
    public class Edited_NotifyIcon : Component
    {
        private Icon[] icons; 
        private int currentIndex = 0; 
        private System.Windows.Forms.Timer timer;

        private NotifyIcon notifyIcon;
        public Icon CurrentIcon
        {
            get => notifyIcon.Icon;
            set
            {
                notifyIcon.Icon = value;
            }
        }
        public String Text
        {
            get => notifyIcon.Text;
            set
            {
                notifyIcon.Text = value;
            }
        }
        public Edited_NotifyIcon()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            icons = new Icon[1];
        }

        public Icon[] AnimationIcons
        {
            get { return icons; }
            set
            {
                icons = value;
                if (icons != null && icons.Length > 0)
                {
                    notifyIcon.Icon = icons[0]; 
                    currentIndex = 0;
                }
            }
        }

        public void StartAnimation()
        {
            if (icons == null || icons.Length == 0)
                throw new InvalidOperationException("Animation icons are not set.");

            timer.Start();
        }

        public void StopAnimation()
        {
            timer.Stop();
            notifyIcon.Icon = icons[0]; 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % icons.Length;
            notifyIcon.Icon = icons[currentIndex];
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();

                }
                notifyIcon.Icon = null;
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            }
        }
    }
}
