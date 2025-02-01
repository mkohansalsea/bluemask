using System;
using System.Windows.Forms;

namespace BlueMask
{
    public partial class MainForm : Form
    {
        private readonly BaseFormComponent baseFormComponent;

        public MainForm()
        {
            InitializeComponent();
            baseFormComponent = new BaseFormComponent(this); // اینجا this به عنوان Form ارسال می‌شود
            this.Text = "MainForm";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            baseFormComponent.InitializeTitleBar();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (baseFormComponent != null)
                {
                    baseFormComponent.Dispose(); // رهاسازی baseFormComponent
                }
            }
            base.Dispose(disposing);
        }
    }
}
