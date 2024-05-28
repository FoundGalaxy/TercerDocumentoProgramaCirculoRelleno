using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elipse
{
    public partial class Form1 : Form
    {
        private Pen lapiz, lapiz2;
        private Graphics punto, vector;
        double[] cx = new double[10000];
        double[] cy = new double[10000];
        int z = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "Pk\t-\tX\t-\tY \r\n";
            textBox6.Text = "X    -      -Y \r\n";
            textBox7.Text = "-X    -      -Y \r\n";
            textBox8.Text = "-X    -     Y \r\n";
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            int xc, yc, radio_x, radio_y;
            xc = Convert.ToInt32(textBox1.Text);
            yc = Convert.ToInt32(textBox2.Text);
            radio_x = Convert.ToInt32(textBox3.Text);
            radio_y = Convert.ToInt32(textBox4.Text);
            Circunferencia_Elipse(radio_x, radio_y);
            Dibujar_Elipse(xc, yc);

        }

        private void btnRellenar_Click(object sender, EventArgs e)
        {
            int xc, yc;
            xc = Convert.ToInt32(textBox1.Text);
            yc = Convert.ToInt32(textBox2.Text);
            vector = pictureBox1.CreateGraphics();
            int xcentro = pictureBox1.Width / 2;
            int ydecentro = pictureBox1.Height / 2;
            vector.TranslateTransform(xcentro, ydecentro);
            vector.ScaleTransform(1, -1);
            lapiz2 = new Pen(Color.Coral, 15);
            for (int i = 1; i < z; i++)
            {
                vector.DrawLine(lapiz2, xc, yc, ((float)cx[i] + xc-1), ((float)cy[i] + yc-1));
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            vector = pictureBox1.CreateGraphics();
            int xdecentro = pictureBox1.Width / 2;
            int ydecentro = pictureBox1.Height / 2;
            Pen lapiz = new Pen(Color.Black, 2);
            vector.TranslateTransform(xdecentro, ydecentro);
            vector.ScaleTransform(1, -1);
            vector.DrawLine(lapiz, xdecentro * -1, 0, xdecentro * 2, 0);
            vector.DrawLine(lapiz, 0, ydecentro, 0, ydecentro * -1);
            for (int i = -xdecentro; i < xdecentro; i += 10)
            {
                //division del eje de y
                vector.DrawLine(lapiz, 5, i, -5, i);
                //division del eje de x
                vector.DrawLine(lapiz, i, 5, i, -5);
            }
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = "Pk\t-\tX\t-\tY \r\n";
            textBox6.Text = "X    -      -Y \r\n";
            textBox7.Text = "-X    -      -Y \r\n";
            textBox8.Text = "-X    -     Y \r\n";

            z = 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int xdecentro = pictureBox1.Width / 2;
            int ydecentro = pictureBox1.Height / 2;
            lapiz = new Pen(Color.Black, 2);
            //convierte las coordenadas a su manera de la grafica
            e.Graphics.TranslateTransform(xdecentro, ydecentro);
            //se convierten a coordenadas normales
            e.Graphics.ScaleTransform(1, -1);
            e.Graphics.DrawLine(lapiz, xdecentro * -1, 0, xdecentro * 2, 0);
            e.Graphics.DrawLine(lapiz, 0, ydecentro, 0, ydecentro * -1);
            using (Font myFont = new Font("Arial", 14))

                for (int i = -xdecentro; i < xdecentro; i += 10)
                {
                    e.Graphics.DrawLine(lapiz, 5, i, -5, i);//division de las y
                    e.Graphics.DrawLine(lapiz, i, 5, i, -5);//division de las x
                }

            int j = -300, k = 250, m = 18;
            for (int l = 50; l < 700; l += 50)
            {
                using (Font font = new Font("Times New Roman", 10, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    Point punto1 = new Point(l - 10, ydecentro + 10);
                    if (j != 0)
                    {
                        TextRenderer.DrawText(e.Graphics, Convert.ToString(j), font, punto1, Color.Blue);
                    }
                    Point punto2 = new Point(xdecentro + 10, m);
                    if (k != 0)
                    {
                        TextRenderer.DrawText(e.Graphics, Convert.ToString(k), font, punto2, Color.Blue);
                    }
                }
                j += 50;
                k -= 50;
                m += 50;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDeX_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDeY_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDeCx_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDeCy_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        void Circunferencia_Elipse(int r1, int r2)
        {
            double corX, corY, radio_x, radio_y, p1, p2;
            corX = 0;
            corY = r2;
            radio_x = r1;
            radio_y = r2;
            p1 = (radio_y * radio_y) - ((radio_x * radio_x) * radio_y) + (0.25 * (radio_x * radio_x));
            int xc, yc;
            xc = Convert.ToInt32(textBox1.Text);
            yc = Convert.ToInt32(textBox2.Text);
            int l = 0;

            while ((2 * (radio_y * radio_y) * corX) <= (2 * (radio_x * radio_x) * corY))
            {
                textBox5.Text += p1 + "\t-\t";
                if (p1 < 0)
                {
                    corX += 1;
                    p1 = p1 + (2 * (radio_y) * (radio_y) * (corX)) + (radio_y * radio_y);
                }
                else if (p1 >= 0)
                {
                    corX += 1;
                    corY -= 1;
                    p1 = p1 + (2 * (radio_y) * (radio_y) * corX) - (2 * (radio_x) * (radio_x) * (corY)) + (radio_y * radio_y);
                }
                cx[z] = corX;
                cy[z] = corY;
                textBox5.Text +=""+ (cx[z]+xc) + "\t-\t" + (cy[z]+yc) + " \r\n";
                z++;
                l++;
            }
            p2 = ((radio_y * radio_y) * ((corX + 0.5) * (corX + 0.5))) + ((radio_x * radio_x) * ((corY - 1) * (corY - 1))) - ((radio_x * radio_x) * (radio_y * radio_y));
            while (corY > 0)
            {
                textBox5.Text += p2 + "\t-\t";
                if (p2 > 0)
                {
                    corY -= 1;
                    p2 = p2 - (2 * (radio_x) * (radio_x) * (corY)) + (radio_x * radio_x);
                }
                else if (p2 <= 0)
                {
                    corX += 1;
                    corY -= 1;
                    p2 = p2 + (2 * (radio_y) * (radio_y) * (corX)) - (2 * (radio_x) * (radio_x) * (corY)) + (radio_x * radio_x);
                }
                cx[z] = corX;
                cy[z] = corY;
                textBox5.Text += (cx[z]+xc) + "\t-\t" + (cy[z]+yc) + " \r\n";
                z++;
                l++;
            }
            //X,-Y
            for (int j=l;j>0;j--)
            {
                cx[z] = cx[j];
                cy[z] = -cy[j];
                textBox6.Text += " " + (cx[z]+xc) + "     -     " + (cy[z]+yc) + " \r\n";
                z++;
            }
            //-X,-Y
            for (int j=1;j<=l;j++)
            {
                cx[z] = -cx[j];
                cy[z] = -cy[j];
                textBox7.Text += " " + (cx[z]+xc) + "     -     " + (cy[z]+yc) + " \r\n";
                z++;
            }
            //-X,Y
            for (int j = l; j > 0; j--)
            {
                cx[z] = -cx[j];
                cy[z] = cy[j];
                textBox8.Text += " " + (cx[z]+xc) + "     -     " + (cy[z]+yc) + " \r\n";
                z++;
            }
        }

        void Dibujar_Elipse(int x, int y)
        {
            int xc, yc;
            xc = x;
            yc = y;
            punto = pictureBox1.CreateGraphics();
            int xdecentro = pictureBox1.Width / 2;
            int ydecentro = pictureBox1.Height / 2;
            lapiz = new Pen(Color.Black, 3);
            punto.TranslateTransform(xdecentro, ydecentro);
            punto.ScaleTransform(1, -1);
            for (int i = 1; i < z; i++)
            {
                punto.DrawRectangle(lapiz, ((float)cx[i] + xc), ((float)cy[i] + yc), 1, 1);
            }
        }
    }
}
