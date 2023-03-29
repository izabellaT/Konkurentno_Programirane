using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockingCPUIntensive
{
    public partial class frmFactorial : Form
    {
        public frmFactorial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(txtNumber.Text);
                MessageBox.Show("Резултат: " + Factorial(number));
            }
            catch (IOException)
            {
                MessageBox.Show("Моля въведете валидно цяло число.");
            }
        }

        private BigInteger Factorial(BigInteger number)
        {
            if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
    }
}
