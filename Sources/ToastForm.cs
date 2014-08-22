﻿/* Author: Aaron U'Ren
 * Email: aauren@gmail.com
 * Date: 8/8/2014
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace spotifytoaster
{
    public partial class ToastForm : Form
    {
        private Timer timer;
        private int startPosX;
        private int startPosY;
        private NameChangeTracker nct;
        private NotifyIcon trayIcon;
        private ToastOverlay overlay;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr createRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public ToastForm()
        {
            InitializeComponent();

            // Create rounded corners
            this.Region = System.Drawing.Region.FromHrgn(createRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Initialize our form's appearance from user settings
            initializeFromSettings();

            // Create overlay so that our text isn't transparent and difficult to read
            initializeOverlay();

            // Create tray icon
            createTrayIconAndMenu();

            // Create and run timer for animation
            timer = new Timer();
            timer.Interval = (int) Properties.Settings.Default["ToastMovementSpeed"];
            timer.Tick += new EventHandler(timerTick);

            // Now let's setup our Spotify Window tracker
            nct = new NameChangeTracker(this);
        }

        private void initializeFromSettings()
        {
            this.Opacity = (double)Properties.Settings.Default["ToastAlphaLevel"];
            this.BackColor = (Color)Properties.Settings.Default["ToastBackgroundColor"];
        }

        private void initializeOverlay()
        {
            overlay = new ToastOverlay();
            this.LocationChanged += delegate { overlay.Location = this.Location; };
            this.Load += delegate { overlay.Visible = false; overlay.Show(this); };
        }

        private void createTrayIconAndMenu()
        {
            // Create a simple tray menu with only one item.
            ContextMenu trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Spotify Toaster";
            trayIcon.Icon = new Icon(Icon.ExtractAssociatedIcon("SpotifyToaster.exe"), 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            // Create rounded corners
            System.Drawing.Region.FromHrgn(createRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void toastVisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                // Move window out of screen
                startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
                startPosY = Screen.PrimaryScreen.WorkingArea.Height;
                SetDesktopLocation(startPosX, startPosY);
                base.OnLoad(e);

                // Setup overlay also
                TopMost = true;
                overlay.TopMost = true;

                // Begin animation
                timer.Enabled = true;
                timer.Start();
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY -= 2;
            //If window is fully visible stop the timer
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
            {
                timer.Stop();
                timer.Enabled = false;
                System.Threading.Thread.Sleep((int)Properties.Settings.Default["ToastTimeToLive"]);
                overlay.Hide();
                Hide();
            }
            else
            {
                SetDesktopLocation(startPosX, startPosY);
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            //Console.WriteLine("Form Close Detected");
            nct.removeWindowHooks();
            trayIcon.Visible = false;
            Application.Exit();
        }

        public void setArtist(String text)
        {
            overlay.artistBox.Text = text;
        }

        public void setTrack(String text)
        {
            overlay.trackBox.Text = text;
        }

        public void setAlbum(String text)
        {
            overlay.albumBox.Text = text;
        }

        public void setAlbumImageUrl(String url)
        {
            albumArt.Load(url);
        }

        public void setAlbumImage(Bitmap image)
        {
            albumArt.Image = image;
        }
    }
}
