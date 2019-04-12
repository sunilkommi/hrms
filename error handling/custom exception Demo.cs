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
    public partial class custom_exception_Demo : Form
    {
        Account acc;
        public custom_exception_Demo()
        {
            acc = new Account();

            InitializeComponent();
        }

        private void btnWithDraw_Click(object sender, EventArgs e)
        {
            try
            {
                int amt = int.Parse(txtAmount.Text);
                acc.Withdraw(amt);
                MessageBox.Show("amount withdrawn successfully,current balance:" + acc.GetBalance());
            }
            catch(AtmException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                int amt = int.Parse(txtAmount.Text);
                acc.Deposit(amt);
                MessageBox.Show("amount deposited successfully,current balance:" + acc.GetBalance());
            }
            catch(AtmException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    class AtmException:Exception
    {
        public AtmException(string errmsg):base(errmsg)
        {
            //to do task like logging exception

        }
    }
    class Account
    {
        double Balance;
        private void Credit(int amt)
        {
            Balance += amt;
        }
        private void Debit(int amt)
        {
            Balance -= amt;
        }
        public double GetBalance()
        {
            return Balance;
        }
        public void Withdraw(int amt)
        {
            if (amt > Balance)
            {
                //throw exception
                throw new AtmException("insufficient balance to withdraw");
            }
            else
            {
                Debit(amt);
            }
        }
        public void Deposit(int amt)
        {
            if (amt < 100)
            {
                throw new AtmException("invalid amount to deposit");
            }
            else
            {
                Credit(amt);
            }
        }
    }
}
