/* Author: Aaron U'Ren
 * Email: aauren@gmail.com
 * Date: 8/8/2014
 * 
 * My version of this file was HEAVILY inspired by:
 * spotifynotifier: https://code.google.com/p/spotifynotifier/
 * Created By: Ranveer Raghuwanshi - ranveer.raghu@gmail.com - http://stackoverflow.com/users/776084/ranrag
 */

using System;
using System.Diagnostics;
using System.Text;
using Metadata;
using System.Windows.Forms;
using System.Drawing;
using spotifytoaster;

namespace Notification
{
    class Notify
    {
        private AlbumInfo albumInfo = new AlbumInfo();

        private String getNotificationText(String track, String artist)
        {
            //string command = string.Format("/t:\"Song: {0}\" /i:\"C:\\spotify.jpg\" /n:\"Spotify\" /a:\"Spotify\" \"Artist: {1}\"",track,artist);
            return String.Format("Song: {0} Artist: {1}", track, artist);
        }

        public void showViaToast(ToastForm myForm, String track, String artist)
        {
            myForm.setArtist(artist);
            myForm.setTrack(track);
            myForm.setAlbum("");
            myForm.setAlbumImage(spotifytoaster.Properties.Resources.album_missing);

            // Attempt to load additional information about the track
            if (albumInfo.loadAlbumInfo(artist, track))
            {
                // Set Album Title if we have one
                if (null != albumInfo.getAlbumTitle())
                {
                    myForm.setAlbum(albumInfo.getAlbumTitle());
                }

                // Set Album Image URL if we have one
                if (null != albumInfo.getAlbumImageURL())
                {
                    myForm.setAlbumImageUrl(albumInfo.getAlbumImageURL());
                }

                // Add Track Number to the title if we have one
                if (null != albumInfo.getTrackNumber())
                {
                    myForm.setTrack(albumInfo.getTrackNumber() + ". " + track);
                }
            }

            myForm.Show();
        }

        public void showViaSystemTrayBalloon(String track, String artist)
        {
            NotifyIcon balloon = new NotifyIcon();
            balloon.Icon = SystemIcons.Exclamation;
            balloon.BalloonTipIcon = ToolTipIcon.Info;
            balloon.BalloonTipTitle = "Spotify Song Changed";
            balloon.BalloonTipText = getNotificationText(track, artist);
            balloon.Visible = true;
            balloon.ShowBalloonTip(3000);
        }

        public void showViaGrowl(String track, String artist)
        {
            ProcessStartInfo cmdsi = new ProcessStartInfo("growlnotify.exe");
            cmdsi.Arguments = getNotificationText(track, artist);
            Process cmd = Process.Start(cmdsi);
        }

        public void showViaMessageBox(String track, String artist)
        {
            MessageBox.Show(getNotificationText(track, artist));
        }
    }
}
