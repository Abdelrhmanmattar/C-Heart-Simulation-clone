using HeartSim.classes.DataAndTypes;
using HeartSim.classes.HeartNS;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeartSim
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Heart myheart = Heart.GetInstance();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            var txtbx = form.GetTextBox1();
            var cancellationToken = form.GetCancellationToken();

            // Start a new task to update the colors
            Task.Run(() =>
            {
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    for (int j = 0; j < 1000; ++j)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;

                        myheart.HeartAutomaton();
                        var newPointsLoc = new List<Position>();
                        var newPointsColor = new List<int>();

                        for (int i = 0; i < Data.NodePositions.Count; ++i)
                        {
                            newPointsLoc.Add(new Position { X = Data.NodePositions[i].X, Y = Data.NodePositions[i].Y });
                            newPointsColor.Add((int)myheart.GetNodeTable().node_table[i].GetParameters().NodeStateIndex - 1);
                            
                        }

                        string updateString = "";
                        for (int i = 0; i < Data.NodeNames.Count; ++i)
                        {
                            updateString += ((int)myheart.GetNodeTable().node_table[i].GetParameters().NodeStateIndex - 1).ToString() + " ";
                        }
                        // Safely update the UI on the UI thread
                        form.Invoke((MethodInvoker)delegate
                        {
                            if (form.IsDisposed || !form.IsHandleCreated)
                                return;

                            form.points_loc.Clear();
                            form.points_color.Clear();
                            form.points_loc.AddRange(newPointsLoc);
                            form.points_color.AddRange(newPointsColor);
                            txtbx.Text = updateString;
                            form.RedrawPictureBox();
                        });

                        Thread.Sleep(5); // Adjust sleep time as needed
                    }
                }
            }, cancellationToken);

            Application.Run(form);
        }
    }
}
