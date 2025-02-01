using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BlueMask
{
    public class BaseFormComponent : Component, IDisposable
    {
        private bool disposed = false;
        private readonly Form form; // تعریف متغیر form
        private readonly TitleBarManager titleBarManager;

        public BaseFormComponent(Form form)
        {
            this.form = form; // مقداردهی متغیر form
            InitializeComponent();
            if (!DesignMode)
            {
                titleBarManager = new TitleBarManager(form);
            }
        }

        private void InitializeComponent()
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.Text = string.Empty;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new System.Drawing.Size(800, 600);

            // Set custom background
            form.BackgroundImage = Properties.Resources.BaseForm01;
            form.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void InitializeTitleBar()
        {
            if (!DesignMode)
            {
                titleBarManager.InitializeTitleBar(); // فراخوانی InitializeTitleBar در زمان اجرا
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (titleBarManager != null)
                    {
                        titleBarManager.Dispose(); // رهاسازی TitleBarManager
                    }
                }
                disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
