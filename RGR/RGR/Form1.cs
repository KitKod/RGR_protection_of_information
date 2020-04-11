using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR
{
    public partial class Form1 : Form
    {
        public int n, ep, phi, d, G, V, r, I, a, b, c, p, q, x, m, k, y;

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            p = int.Parse(textBox17.Text);
            q = int.Parse(textBox18.Text);
            x = int.Parse(textBox19.Text);
            m = int.Parse(textBox20.Text);
            k = int.Parse(textBox21.Text);
            n = p;
            y = cipher(q, x);
            a = cipher(q, k);
            int k_1 = find_d((p - 1), k);
            b = (k_1 * (m - a * x)) % (p - 1);
            if (b < 0)
            {
                b += (p - 1);
            }
            int V = (cipher(y, a) * cipher(a, b)) % p;
            int W = cipher(q, m);
            textBox22.Text = "V=" + V + "   W=" + W;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secr = 0;
            a = int.Parse(textBox12.Text);
            b = int.Parse(textBox13.Text);
            c = int.Parse(textBox14.Text);
            String s = textBox15.Text;
            for (int i = 0; i < s.Length; i++)
            {
                groups[i] = int.Parse(s.ElementAt(i).ToString());
            }
            for (int i = 1; i <= 4; i++)
            {
                secrets[i] = Func(i) % 5;
            }
            for (int i = 0; i < groups.Length; i++)
            {
                if (i == 0)
                {
                    secr += secrets[groups[i]] * groups[i + 1] * groups[i + 2] / ((groups[i] - groups[i + 1]) * (groups[i] - groups[i + 2]));
                }
                else if (i == 1)
                {
                    secr += secrets[groups[i]] * groups[i - 1] * groups[i + 1] / ((groups[i] - groups[i - 1]) * (groups[i] - groups[i + 1]));
                }
                else
                {
                    secr += secrets[groups[i]] * groups[i - 1] * groups[i - 2] / ((groups[i] - groups[i - 1]) * (groups[i] - groups[i - 2]));
                }

            }

            if (secr < 0)
            {
                secr += 5;
            }
            secr = secr % 5;
            textBox16.Text = "" + secr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox6.Text);
            G = int.Parse(textBox7.Text);
            V = int.Parse(textBox8.Text);
            r = int.Parse(textBox9.Text);
            d = int.Parse(textBox10.Text);
            int J = cipher(G, V);
            I = find_d(n, J);
            int T = cipher(r, V);
            textBox11.Text = "T=" + T + "   ";
            int D = (r % n * cipher(G, d)) % n;
            int Ts = (cipher(D, V) * cipher(I, d)) % n;
            textBox11.Text += "T'=" + Ts + "mod " + n + "=" + Ts % n;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            String[] arr = text.Split('-');
            int[] mes = new int[arr.Length];
            int[] res = new int[arr.Length];
            int[] ext_res = new int[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                mes[i] = int.Parse(arr[i]);
            }
            n = int.Parse(textBox2.Text);
            ep = int.Parse(textBox3.Text);
            phi = int.Parse(textBox4.Text);
            d = find_d(phi, ep);
            String s = "";
            for (int i = 0; i < mes.Length; i++)
            {
                res[i] = decipher(mes[i]);
            }
            for (int i = 0; i < res.Length; i++)
            {

                ext_res[i * 2] = res[i] / 100;
                ext_res[i * 2 + 1] = res[i] - ext_res[i * 2] * 100;
            }
            for (int i = 0; i < ext_res.Length; i += 2)
            {
                s += set[ext_res[i + 1] - 1];
                s += set[ext_res[i] - 1];
            }
            textBox5.Text = s;
        }

        public char[] set = new char[34] {' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К',
            'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        public int[] groups = new int[3];

        

        public int[] secrets = new int[5];

      

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

       

        public int decipher(int q)
        {
            int c = 1;
            for (int i = 1; i <= d; i++)
            {
                c = (c * q) % (int)n;
            }
            return c;
        }
        public int euclid(int a, int n)
        {
            int[] u = new int[3];
            int[] v = new int[3];
            int[] t = new int[3];
            int q;
            u[0] = 0; u[1] = 1; u[2] = n;
            v[0] = 1; v[1] = 0; v[2] = a;
            while (u[2] != 1)
            {
                q = u[2] / v[2];
                t[0] = u[0] - v[0] * q;
                t[1] = u[1] - v[1] * q;
                t[2] = u[2] - v[2] * q;
                u[0] = v[0];
                u[1] = v[1];
                u[2] = v[2];
                v[0] = t[0];
                v[1] = t[1];
                v[2] = t[2];
            }
            return u[1] % n;
        }
        public int find_d(long phi, int ep)
        {
            float res;
            for (int k = 0; k < 10000; k++)
            {
                res = ((float)k * (float)phi + 1) / (float)ep;
                if (res % 1 == 0) { return (int)res; }
            }
            return 0;
        }
        public int cipher(int q, int e)
        {
            int c = 1;
            for (int i = 1; i <= e; i++)
            {
                c = (c * q) % (int)n;
            }
            return c;
        }
        public int Func(int x)
        {
            return a * (x * x) + b * x + c;
        }
    }
}
