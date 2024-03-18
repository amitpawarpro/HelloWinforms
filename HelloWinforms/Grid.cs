using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWinforms
{
    public class Grid
    {
        static readonly Random rng = new Random();
        readonly Color[,] data;
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            data = new Color[3, 3];

            data[0, 0] = Color.Red;
            data[0, 1] = Color.Green;
            data[0, 2] = Color.Blue;
            data[1, 0] = Color.Yellow;
            data[1, 1] = Color.Lavender;
            data[1, 2] = Color.Violet;
            data[2, 0] = Color.Cyan;
            data[2, 1] = Color.Magenta;
            data[2, 2] = Color.Orange;
        }

        public void SetRandomColor(int row, int column)
        {
            data[row, column] = Color.FromArgb(
                rng.Next(256),
                rng.Next(256),
                rng.Next(256),
                rng.Next(256));
        }

        public int Rows { get; }
        public int Columns { get; }

        public (int row, int column) GetCoordinates(Control target, Point point)
        {
            float wt = target.ClientSize.Width, ht = target.ClientSize.Height;
            float dx = wt / Columns, dy = ht / Rows;

            return ((int)(point.X / dx), (int)(point.Y / dy));
        }

        public Color this[int row, int column]
        {
            get => data[row, column];
            set => data[row, column] = value;
        }

        public static void Render(Graphics g, float wt, float ht, List<Holiday> holidays)
        {
            var border = 2;
            var counter = 0;
            using (var fill = new SolidBrush(Color.Gray))
            {
                switch (holidays.Count)
                {
                    case 1:
                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt, ht);
                        break;
                    case 2:

                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt/2, ht);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt/2, 0, wt, ht);

                        break;
                    case 3:

                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt / 2, ht/2);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt / 2, 0, wt, ht/2);

                        fill.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(fill, 0, ht/2, wt, ht / 2);
                        break;
                    case 4:
                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt / 2, ht / 2);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt / 2, 0, wt, ht / 2);

                        fill.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(fill, 0, ht / 2, wt, ht / 2);

                        fill.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(fill, wt/2, ht / 2, wt, ht / 2);
                        break;
                    case 5:
                        // x x x
                        //  x x   
                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt / 3, ht / 2);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt / 3, 0, wt / 3, ht / 2);

                        fill.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(fill, wt / 3 * 2, 0, wt / 3, ht / 2);

                        fill.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(fill, 0, ht / 2, wt / 2, ht / 2);

                        fill.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(fill, wt /2, ht / 2, wt / 2, ht / 2);
                        break;
                    case 6:
                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt / 3, ht / 2);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt / 3, 0, wt / 3, ht / 2);

                        fill.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(fill, wt / 3 * 2, 0, wt / 3, ht / 2);

                        fill.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(fill, 0, ht / 2, wt / 3, ht / 2);

                        fill.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(fill, wt / 3, ht / 2, wt / 3 * 2, ht / 2);

                        fill.Color = holidays[5].Calendar.Color;
                        g.FillRectangle(fill, wt / 3*2, ht / 2, wt, ht / 2);
                        break;
                    case 7:
                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt / 3, ht / 3);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt / 3, 0, wt / 3, ht / 3);

                        fill.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(fill, wt / 3 * 2, 0, wt / 3, ht / 3);



                        fill.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(fill, 0, ht/3, wt / 2, ht / 3*2);

                        fill.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(fill, wt/2, ht/3, wt, ht / 3*2);

                        fill.Color = holidays[5].Calendar.Color;
                        g.FillRectangle(fill, 0, ht / 3*2, wt / 2, ht);

                        fill.Color = holidays[6].Calendar.Color;
                        g.FillRectangle(fill, wt / 2, ht / 3 * 2, wt / 2, ht);

                        break;
                    case 8:

                        fill.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(fill, 0, 0, wt / 3, ht / 3);

                        fill.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(fill, wt / 3, 0, wt / 3, ht / 3);

                        fill.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(fill, wt / 3 * 2, 0, wt / 3, ht / 3);



                        fill.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(fill, 0, ht / 3, wt / 2, ht / 3 * 2);

                        fill.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(fill, wt / 2, ht / 3, wt, ht / 3 * 2);


                        fill.Color = holidays[5].Calendar.Color;
                        g.FillRectangle(fill, 0, ht / 3 * 2, wt / 3, ht);

                        fill.Color = holidays[6].Calendar.Color;
                        g.FillRectangle(fill, wt/3, ht / 3 * 2, wt / 3 * 2, ht);

                        fill.Color = holidays[7].Calendar.Color;
                        g.FillRectangle(fill, wt / 3 * 2, ht / 3 * 2, wt, ht);
                        break;
                    default:
                        break;
                }

                fill.Color = SystemColors.ButtonFace;
                g.FillRectangle(fill, border, border, wt - 1- border * 2, ht -1- border * 2);
            }
        }

        private Point GetRowsColumns(int n)
        {
            if (n == 1) return new Point(1, 1);
            if (n == 2) return new Point(1, 2);
            if (n <= 4) return new Point(2, 2);
            return new Point(3, 3);
        }

        public static Bitmap GenerateBitmap(int wt, int ht, List<Holiday> holidays)
        {

            Bitmap bmp = new Bitmap(wt, ht, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            Render(g, wt, ht, holidays); 
            return bmp;
        }

        public enum HolidayColors
        {
            Red,
            Green,
            Blue,
            Oragne,
            Violet,
            Yellow,
            Cyan,
            Magenta
        }

    }
}
