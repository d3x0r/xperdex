using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using System.IO;

namespace Blackout
{
    internal static class local
    {
        internal static Color color;
        internal static List<Floater> floaters;
        internal static Form1 main;
        internal static String FILE_NAME;
        static bool reading;
        internal static bool locked;
        internal static bool resize;

        internal static void WriteFloaters()
        {
            if (reading)
                return;
            FileStream fs = new FileStream(FILE_NAME, FileMode.Create);

            BinaryWriter w;
            w = new BinaryWriter(fs);
            w.Write(resize);
            w.Write(locked);
            w.Write(color.ToArgb());
            foreach (Floater f in floaters)
            {
                f.canvas.SaveConfig(); 
                w.Write(f.Location.X);
                w.Write(f.Location.Y);
                w.Write(f.Width);
                w.Write(f.Height);
            }
            fs.Close();
        }
        static local()
        {
            
             //FILE_NAME = Application.UserAppDataPath + "\\floaters.bin";
             FILE_NAME = Application.ExecutablePath + ".bin2";
             color = Color.Black;
            floaters = new List<Floater>();
            try
            {
                reading = true;
                FileStream fs = new FileStream(FILE_NAME, FileMode.Open);
                BinaryReader r = new BinaryReader(fs);
                try
                {
                    resize = r.ReadBoolean();
                    locked = r.ReadBoolean();
                    color = Color.FromArgb( r.ReadInt32() );
                    while (true)
                    {
                        int x = r.ReadInt32();
                        int y = r.ReadInt32();
                        int width = r.ReadInt32();
                        int height = r.ReadInt32();
                        Floater f = new Floater();
                        f.Size = new Size(width, height);
                        floaters.Add(f);
                        f.Show();
                        f.Location = new Point(x, y);
                    }
                }
                catch (Exception e)
                {
                }
                fs.Close();
            }
            catch (Exception e)
            {
            }
            reading = false;

             if (local.floaters.Count == 0)
             {
                 Floater floater = new Floater();
                 local.floaters.Add(floater);
                 //            floater.Visible = true;
                 floater.Size = new Size(250, 800);
                 floater.Show();
             }

        }
    }
}
