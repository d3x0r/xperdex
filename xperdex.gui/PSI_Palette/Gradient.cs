using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace xperdex.gui.PSI_Palette
{

        public partial class Gradient : PSI_Control
        {
            public enum gradient_mode
            {
                black_white
                ,
                red
              ,
                green
              , blue
            };
            //static int count;
            public gradient_mode mode;
            public Gradient()
            {
                InitializeComponent();
            }

            Color Scale(Color a, Color b, int range, int step)
            {
                Color r;
                r = Color.FromArgb((a.R * (range-step)) / range + (b.R * (step)) / range
                , (a.G * (range - step)) / range + (b.G * (step)) / range
                , (a.B * (range - step)) / range + (b.B * (step)) / range
                );
                return r;
            }
            private void GradientPaint(object sender, PaintEventArgs e)
            {
                //Brush b = Gradient.
                Color current_color;
                try
                {
                    current_color = Color.FromArgb(255, ((Palette)this.Parent).current_color);
                }
                catch (Exception ee)
                {
					Console.WriteLine( ee.Message );
					return;
                }
                //Color color1;
                //Color color2;
                switch (mode)
                {
                    case gradient_mode.black_white:

                        Brush b = new LinearGradientBrush(new Point(0, 0), new Point(0, Height / 2), Color.Black, current_color);
                        e.Graphics.FillRectangle(b, 0, 0, Width, Height / 2);
                        b = new LinearGradientBrush(new Point(0, Height/2), new Point(0, Height), current_color, Color.White);
                        e.Graphics.FillRectangle(b, 0, Height/2, Width, Height);
#if adfasdf
                        color1 = Color.Black;
                        color2 = current_color;
                        for (y = 0; y < Height / 2; y++)
                        {
                            Pen p = new Pen(Scale(color1, color2, Height / 2, y));
                            e.Graphics.DrawLine(p, 0, y, Width, y);
                            //e.Grph
                        }
                        color1 = current_color;
                        color2 = Color.White;
                        for (; y < Height; y++)
                        {
                            Pen p = new Pen(Scale(color1, color2, Height / 2, y - Height/2));
                            e.Graphics.DrawLine(p, 0, y, Width, y);
                        }
#endif
                        break;
                    case gradient_mode.red:
                        b = new LinearGradientBrush(new Point(0, 0), new Point(0, Height)
                            , Color.FromArgb(0/*current_color.R*/, current_color.G, current_color.B)
                            , Color.FromArgb(255/*current_color.R*/, current_color.G, current_color.B));
                        e.Graphics.FillRectangle(b, 0, 0, Width, Height);
#if adfadf
                        color1 = Color.FromArgb(0/*current_color.R*/, current_color.G, current_color.B);
                        color2 = Color.FromArgb(255/*current_color.R*/, current_color.G, current_color.B);
                        for (y = 0; y < Height; y++)
                        {
                            Pen p = new Pen(Scale(color1, color2, Height, y));
                            e.Graphics.DrawLine(p, 0, y, Width, y);
                        }
#endif
                        break;
                    case gradient_mode.green:
                        b = new LinearGradientBrush(new Point(0, 0), new Point(0, Height)
                            , Color.FromArgb(current_color.R, 0/*current_color.G*/, current_color.B)
                            , Color.FromArgb(current_color.R, 255/*current_color.G*/, current_color.B));
                        e.Graphics.FillRectangle(b, 0, 0, Width, Height);
#if asdfadsf
                        color1 = Color.FromArgb(current_color.R, 0/*current_color.G*/, current_color.B);
                        color2 = Color.FromArgb(current_color.R, 255/*current_color.G*/, current_color.B);
                        for (y = 0; y < Height; y++)
                        {
                            Pen p = new Pen(Scale(color1, color2, Height, y));
                            e.Graphics.DrawLine(p, 0, y, Width, y);
                        }
#endif
                        break;
                    case gradient_mode.blue:
                        b = new LinearGradientBrush(new Point(0, 0), new Point(0, Height)
                            , Color.FromArgb(current_color.R, current_color.G, 0/*current_color.B*/)
                            , Color.FromArgb(current_color.R, current_color.G, 255/*current_color.B*/));
                        e.Graphics.FillRectangle(b, 0, 0, Width, Height);
#if adsfasdf
                        color1 = Color.FromArgb(current_color.R, current_color.G, 0/*current_color.B*/);
                        color2 = Color.FromArgb(current_color.R, current_color.G, 255/*current_color.B*/);
                        for (y = 0; y < Height; y++)
                        {
                            Pen p = new Pen(Scale(color1, color2, Height, y));
                            e.Graphics.DrawLine(p, 0, y, Width, y);
                        }
#endif
                        break;
                }
            }

            bool pick_color;

            void SetColor(Palette p, int Y)
            {
                        Color color1, color2;
                        if (pick_color)
                        {
                            switch (mode)
                            {
                                case gradient_mode.black_white:
                                    if (Y < Height / 2)
                                    {
                                        color1 = Color.Black;
                                        color2 = p.current_color;
                                        p.current_color = Scale(color1, color2, Height / 2, Y);
                                    }
                                    else
                                    {
                                        color1 = p.current_color;
                                        color2 = Color.White;
                                        p.current_color = Scale(color1, color2, Height / 2, Y - Height / 2);
                                    }
                                    break;
                                case gradient_mode.red:
                                    color1 = Color.FromArgb(0/*current_color.R*/, p.current_color.G, p.current_color.B);
                                    color2 = Color.FromArgb(255/*current_color.R*/, p.current_color.G, p.current_color.B);
                                    p.current_color = Scale(color1, color2, Height, Y);
                                    break;
                                case gradient_mode.green:
                                    color1 = Color.FromArgb(p.current_color.R, 0/*current_color.G*/, p.current_color.B);
                                    color2 = Color.FromArgb(p.current_color.R, 255/*current_color.G*/, p.current_color.B);
                                    p.current_color = Scale(color1, color2, Height, Y);
                                    break;
                                case gradient_mode.blue:
                                    color1 = Color.FromArgb(p.current_color.R, p.current_color.G, 0/*current_color.B*/);
                                    color2 = Color.FromArgb(p.current_color.R, p.current_color.G, 255/*current_color.B*/);
                                    p.current_color = Scale(color1, color2, Height, Y);
                                    break;
                            }
                            p.Refresh();
                        }            
            }

            private void CM_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    pick_color = true;
                    try
                    {
                        PSI_Palette.Palette p = (Palette)this.Parent;
                        SetColor( p, e.Y );
                    }
                    catch (Exception e2)
                    {
						Console.WriteLine( e2.Message );
					}
                }

            }
            private void CM_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {
                    if (e.Y >= 0 && e.Y <= Height)
                    {
                        PSI_Palette.Palette p = (Palette)this.Parent;
                        if (pick_color)
                        {
                            SetColor(p, e.Y);
                        }
                    }
                }
                catch (Exception e2)
                {
					Console.WriteLine( e2.Message );
				}

            }
            private void CM_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                    pick_color = false;

            }

        }
    }


