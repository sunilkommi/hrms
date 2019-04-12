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
    public partial class exceptionDemo : Form
    {
        public exceptionDemo()
        {
            InitializeComponent();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                int n1 = int.Parse(txtN1.Text);
                int n2 = int.Parse(txtN2.Text);

                int result = n1 / n2;
                MessageBox.Show("result" + result);
            }
            catch(DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(FormatException ex)
            {
                MessageBox.Show("enter only numbers");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("good bye");
            }
        }
    }
}
