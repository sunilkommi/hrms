using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace error_handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBonus(object sender, EventArgs e)
        {
            int salary = int.Parse(textBox1.Text);
            double bonus=GetBonus(salary);
            MessageBox.Show("bonus: " + bonus);
        }
        private double GetBonus(int salary)
        {
            double bonus = 0;
            if(salary>5000)
            {
                bonus = 0.1 * salary;
            }
            else
            {
                bonus = 0.02 * salary;
            }
            return bonus;
        }
    }
}
