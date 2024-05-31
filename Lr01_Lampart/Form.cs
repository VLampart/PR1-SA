namespace Lr01_Lampart
{
    public partial class Form : System.Windows.Forms.Form
    {
        bool flagAnimation = false;
        public Form()
        {
            InitializeComponent();

            edited_NotifyIcon1.AnimationIcons = new Icon[]
            {
                new Icon("ico1.ico"),
                new Icon("ico2.ico"),
                new Icon("ico3.ico")
            };
 
            Application.ApplicationExit += (sender, e) =>
            {
                edited_NotifyIcon1.StopAnimation();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flagAnimation == false)
            {
                edited_NotifyIcon1.StartAnimation();
                button1.Text = "Stop";
                flagAnimation = true;
            }
            else
            {
                edited_NotifyIcon1.StopAnimation();
                button1.Text = "Start";
                flagAnimation = false;
            }
        }
    }
}
