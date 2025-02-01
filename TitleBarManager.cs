using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlueMask
{
    public class TitleBarManager : IDisposable
    {
        private readonly Form form; // تعریف متغیر form
        private Button closeButton;
        private Button maximizeButton;
        private Button minimizeButton;
        private bool disposed = false;

        public TitleBarManager(Form form)
        {
            this.form = form; // مقداردهی متغیر form
            InitializeTitleBar();
        }

        public void InitializeTitleBar()
        {
            // Close button
            closeButton = new Button
            {
                Text = "X",
                Size = new Size(20, 20),
                Location = new Point(10, 10),
                Margin = new Padding(0),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.MouseEnter += new EventHandler(Button_MouseEnter);
            closeButton.MouseLeave += new EventHandler(Button_MouseLeave);
            closeButton.Click += new EventHandler(CloseButton_Click);
            form.Controls.Add(closeButton);

            // Maximize button
            maximizeButton = new Button
            {
                Text = "⬜",
                Size = new Size(20, 20),
                Location = new Point(40, 10),
                Margin = new Padding(0),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            maximizeButton.FlatAppearance.BorderSize = 0;
            maximizeButton.MouseEnter += new EventHandler(Button_MouseEnter);
            maximizeButton.MouseLeave += new EventHandler(Button_MouseLeave);
            maximizeButton.Click += new EventHandler(MaximizeButton_Click);
            form.Controls.Add(maximizeButton);

            // Minimize button
            minimizeButton = new Button
            {
                Text = "—",
                Size = new Size(20, 20),
                Location = new Point(70, 10),
                Margin = new Padding(0),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.MouseEnter += new EventHandler(Button_MouseEnter);
            minimizeButton.MouseLeave += new EventHandler(Button_MouseLeave);
            minimizeButton.Click += new EventHandler(MinimizeButton_Click);
            form.Controls.Add(minimizeButton);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Gold;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Transparent;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            form.Close();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // رهاسازی منابع مدیریت شده
                    if (closeButton != null)
                    {
                        closeButton.Dispose();
                    }
                    if (maximizeButton != null)
                    {
                        maximizeButton.Dispose();
                    }
                    if (minimizeButton != null)
                    {
                        minimizeButton.Dispose();
                    }
                }

                // رهاسازی منابع غیرمدیریت شده (در صورت وجود)

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TitleBarManager()
        {
            Dispose(false);
        }
    }
}
