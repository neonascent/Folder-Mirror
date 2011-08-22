/* This project was based on the previous coding of
 * Gerald Nelson (CodeProject.com) and Jayesh Jain(CodeProject.com). But since there
 * where alot of errors and uncompleted code i decided
 * to freshen things up and get it working with more comments
 * better and cleaner code.
 * 
 * Hope u guys like it.
 * - Max Persson
 */

using System;
using System.Windows.Forms;

// Using System.IO to get the hooks from the system
using System.IO;

// Using System.Threading because the event that will
// be raised from the monitor is comming from a different
// thread that will run on your code.
using System.Threading;

namespace MonitorFolderActivity
{
    public partial class frmMain : Form
    {
        // System.IO
        FileSystemWatcher _watchFolder = new FileSystemWatcher();

        public frmMain()
        {
            InitializeComponent();
        }
        private void abortAcitivityMonitoring()
        {
            btnStart_Stop.Text = "Start";
            txtActivity.Focus();
        }

        /// <summary>
        /// This will start the activity-monitoring of a folder
        /// </summary>
        private void startActivityMonitoring(string sPath)
        {
            if (sPath.Length < 3)
            {
                MessageBox.Show("You have to enter a folder to monitor.",
                    "Hey..!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                abortAcitivityMonitoring();
            }
            else
            {
                // This is the path we want to monitor
                _watchFolder.Path = sPath;

                // Make sure you use the OR on each Filter because we need to monitor
                // all of those activities

                _watchFolder.NotifyFilter = System.IO.NotifyFilters.DirectoryName;

                _watchFolder.NotifyFilter = _watchFolder.NotifyFilter | System.IO.NotifyFilters.FileName;
                _watchFolder.NotifyFilter = _watchFolder.NotifyFilter | System.IO.NotifyFilters.Attributes;

                // Now hook the triggers(events) to our handler (eventRaised)
                _watchFolder.Changed += new FileSystemEventHandler(eventRaised);
                _watchFolder.Created += new FileSystemEventHandler(eventRaised);
                _watchFolder.Deleted += new FileSystemEventHandler(eventRaised);

                // Occurs when a file or directory is renamed in the specific path
                _watchFolder.Renamed += new System.IO.RenamedEventHandler(eventRenameRaised);

                // And at last.. We connect our EventHandles to the system API (that is all
                // wrapped up in System.IO)
                try
                {
                    _watchFolder.EnableRaisingEvents = true;
                }
                catch (ArgumentException)
                {
                    abortAcitivityMonitoring();
                }
            }
        }

        /// <summary>
        /// This just stops the monitoring process.
        /// </summary>
        private void stopActivityMonitoring()
        {
            _watchFolder.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Because the thread that is triggering the event, and will
        /// finaly end up doing your code is not created on our GUI-thread
        /// so we need to create a delegate and invoke the method.
        /// </summary>
        /// <param name="text">string; What text to add to txtAcitivty</param>
        private delegate void AddLogText(string text);
        private void TS_AddLogText(string text)
        {
            if (this.InvokeRequired)
            {
                AddLogText del = new AddLogText(TS_AddLogText);
                Invoke(del, text);
            }
            else
            {
                txtActivity.Text += text;
            }
        }

        /// <summary>
        /// Triggerd when an event is raised from the folder acitivty monitoring.
        /// All types exists in System.IO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">containing all data send from the event that got executed.</param>
        private void eventRaised(object sender, System.IO.FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    TS_AddLogText(string.Format("File {0} has been modified\r\n", e.FullPath));

                    break;
                case WatcherChangeTypes.Created:
                    TS_AddLogText(string.Format("File {0} has been created\r\n", e.FullPath));

                    break;
                case WatcherChangeTypes.Deleted:
                    TS_AddLogText(string.Format("File {0} has been deleted\r\n", e.FullPath));

                    break;
                default: // Another action
                    break;
            }
        }

        /// <summary>
        /// When a folder or file is renamed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void eventRenameRaised(object sender, System.IO.RenamedEventArgs e)
        {
            TS_AddLogText(string.Format("File {0} has been renamed to {1}\r\n", e.OldName, e.Name));
        }

        private void btnStart_Stop_Click(object sender, EventArgs e)
        {
            if (btnStart_Stop.Text.Equals("Start"))
            {
                btnStart_Stop.Text = "Stop";
                startActivityMonitoring(txtFolderPath.Text);
            }
            else
            {
                btnStart_Stop.Text = "Start";
                stopActivityMonitoring();
            }
        }
    }
}