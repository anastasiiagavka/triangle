using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResult.Visible = false;
            btnRestart.Visible = false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            bool isAValid = int.TryParse(txtSideA.Text, out int a);
            bool isBValid = int.TryParse(txtSideB.Text, out int b);
            bool isCValid = int.TryParse(txtSideC.Text, out int c);

            if (!isAValid || !isBValid || !isCValid)
            {
                MessageBox.Show("Ошибка: Введите целые числа во все поля.", "Ошибка ввода");
                return; 
            }

            if (a <= 0 || b <= 0 || c <= 0)
            {
                MessageBox.Show("Ошибка: Длины сторон должны быть больше нуля.", "Ошибка ввода");
                return;
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                MessageBox.Show("Ошибка: Это не треугольник (сумма двух сторон меньше третьей).", "Ошибка");
                return;
            }

            if (a == b && b == c)
            {
                lblResult.Text = "Полученный треугольник\nравносторонний";
            }
            else if (a == b || a == c || b == c)
            {
                lblResult.Text = "Полученный треугольник\nравнобедренный";
            }
            else
            {
                lblResult.Text = "Полученный треугольник\nразносторонний";
            }

            txtSideA.Visible = false;
            txtSideB.Visible = false;
            txtSideC.Visible = false;
            btnCheck.Visible = false;
            lblTitle.Visible = false;

            lblResult.Visible = true;
            btnRestart.Visible = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtSideA.Text = "";
            txtSideB.Text = "";
            txtSideC.Text = "";

            lblResult.Visible = false;
            btnRestart.Visible = false;

            txtSideA.Visible = true;
            txtSideB.Visible = true;
            txtSideC.Visible = true;
            btnCheck.Visible = true;
            lblTitle.Visible = true;

            txtSideA.Focus();
        }
    }
}
