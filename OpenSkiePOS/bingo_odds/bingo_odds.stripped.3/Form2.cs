using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace BingoGameCore4
{
    public partial class WaitBox : Form
    {
        public Thread waitBoxThread = null;

        public WaitBox()
        {
            InitializeComponent();
            waitBoxThread = new Thread( new ThreadStart( WaitBoxProc ) );
            waitBoxThread.Start();
        }

        /// <summary>
        /// Lock covering stopping and stopped
        /// </summary>
        private readonly object stopLock = new object();

        /// <summary>
        /// Whether or not the thread has been asked to stop
        /// </summary>
        private bool stopping = false;

        /// <summary>
        /// Wheter or not the thread has stopped
        /// </summary>
        private bool stopped = false;

        /// <summary>
        /// Returns whether the thread has been asked to stop
        /// This continues to return true even after the thread has stopped
        /// </summary>
        private bool Stopping
        {
            get
            {
                lock (stopLock)
                {
                    return stopping;
                }
            }
        }

        /// <summary>
        /// Returns whether the thread has stopped
        /// </summary>
        private bool Stopped
        {
            get
            {
                lock (stopLock)
                {
                    return stopped;
                }
            }
        }

        /// <summary>
        /// Tells the worker thread to stop, typically after completing its 
        /// current work item. (The thread is *not* guaranteed to have stopped
        /// by the time this method returns.)
        /// </summary>
        private void Stop()
        {
            lock( stopLock )
            {
                stopping = true;
            }
        }

        /// <summary>
        /// Called by the worker thread to indicate when it has stopped.
        /// </summary>
        public void SetStopped()
        {
            lock( stopLock )
            {
                stopping = true;
                stopped = true;
            }
        }

        /// <summary>
        /// WaitBox Thread
        /// </summary>
        public void WaitBoxProc()
        {
            int waitTextLen = label2.Text.Length;

            try
            {
                var Stopwatch = System.Diagnostics.Stopwatch.StartNew();

                while( !Stopping )
                {
                    // This must be done here to ensure that WaitBox
                    // is fully initialized on the other thread.
                    Thread.Sleep( 500 );

                    // Check after sleep
                    if( !Stopping )
                    {
                        // .NET takes care of the InvokeRequired check
                        lock( label2 )
                        {
                            Invoke( ( MethodInvoker )delegate
                            {
                                //if( label2.Text.Length > waitTextLen + 60 )
                                //    label2.Text = label2.Text.Remove( waitTextLen );
                                //else
                                //    label2.Text += " .";
                                if( label2.Text.Length > waitTextLen )
                                    label2.Text = label2.Text.Remove( waitTextLen );
                                label2.Text += "  (" + Stopwatch.Elapsed.Minutes + ":" + Stopwatch.Elapsed.Seconds + ")";
                            } );
                        }
                    }
                }
            }
            finally
            {
                SetStopped();
            }
        }

        /// <summary>
        /// Process "Cancel Data Update" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click( object sender, EventArgs e )
        {
            label2.Text = "Stopping Current Processing...";
            label2.Update();

            // This will tell waitBoxThread that it should 
            // stop processing and exit its' thread.
            Stop();

            // Make sure that waitBoxThread has enough time to shut
            // down so it doesn't try to use the Disposed WaitBox.
            if( RunDetails.rateRankThread.IsAlive )
            {
                //RateRank.StopUpdate();
                Thread.Sleep(500);
                while( RunDetails.rateRankThread.IsAlive )
                {
                    RunDetails.rateRankThread.Interrupt();
                    RunDetails.rateRankThread.Abort();
                }
            }

            if( !Stopped )
            {
                // One more check to see if waitBoxThread is still active.
                if( waitBoxThread.IsAlive )
                {
                    // Force an Abort on the obstinate waitBoxThread.
                    waitBoxThread.Abort();
                    Thread.Yield();
                }
            }
            // WaitBox will now automatically close.
        }
    }
}
