using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
       delegate void CharParamDelegate(char aChar);
        private const string MESSAGE = "This application demonstrates " + "Thread.Suspend() and Thread.Resume() methods. ";
        private Thread mThread;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonSuspend;
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            mThread = new Thread(new ThreadStart(this.PrintMessages));
            mThread.IsBackground = true;
            mThread.Start();
            SuspendThread();
        }
        private void SuspendThread()
        {
            mThread.Suspend();
            buttonSuspend.Enabled = false;
            buttonResume.Enabled = true;
        }
        private void ResumeThread()
        {
            mThread.Resume();
            buttonSuspend.Enabled = true;
            buttonResume.Enabled = false;
        }
        private void AppendTextToTextBox(char aChar)
        {
            textBoxMessage.AppendText(aChar.ToString());
        }
        /// <summary> 
        /// PrintMessages() runs in a separate thread and slowly 
        /// prints messages in the MainForm's text box. 
        /// </summary> 
        private void PrintMessages()
        {
            while (true)
            {
                foreach (char letter in MESSAGE.ToCharArray())
                {
                    try
                    {
                        this.Invoke(new CharParamDelegate(
                        AppendTextToTextBox), new object[] { letter });
                    }
                    catch (Exception)
                    {
                        // Can not call Invoke() bacause the form is closed. 
                        return;
                    }
                    Thread.Sleep(50);
                }
            }
        }
        private void buttonSuspend_Click(object sender,
        System.EventArgs e)
        {
            SuspendThread();
        }
        private void ButtonResume_Click(object sender,
        System.EventArgs e)
        {
            ResumeThread();
        }

    }
}
    

