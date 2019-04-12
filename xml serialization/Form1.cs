using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace xml_serialization
{
    public partial class Form1 : Form
    {
        List<Employee> emplist;
        public Form1()
        {
            emplist = new List<Employee>();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //create object using user input
            Employee emp = new Employee()
            {
                Ecode = int.Parse(txtEcode.Text),
                Ename = txtEname.Text,
                Salary=int.Parse(txtSalary.Text),
                Deptid=int.Parse(txtDeptid.Text)
            };
            //add to the list
            emplist.Add(emp);
            MessageBox.Show("record added");

            //clear all the text boxes
            txtEcode.Clear();
            txtEname.Clear();
            txtSalary.Clear();
            txtDeptid.Clear();

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\my programs\c#prgms\employee.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xmlser = new XmlSerializer(emplist.GetType());
           emplist=(List<Employee>) xmlser.Deserialize(fs);

            //display in data grid view
            dgvEmp.DataSource = null;
            dgvEmp.DataSource = emplist;
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            FileStream fs1 = new FileStream(@"D:\my programs\c#prgms\employee.txt", FileMode.Create, FileAccess.Write);
            FileStream fs2 = new FileStream(@"D:\my programs\c#prgms\employee.xml", FileMode.Create, FileAccess.Write);

            BinaryFormatter binfmt = new BinaryFormatter();
            binfmt.Serialize(fs1, emplist);

            XmlSerializer xmlser = new XmlSerializer(emplist.GetType());
            xmlser.Serialize(fs2, emplist);

            MessageBox.Show("records serialized to binary and xml formats");
            fs1.Close();
            fs2.Close();
        }
    }
    [Serializable]
   public class Employee
    {
        public int Ecode { get; set; }
        public string Ename { get; set; }
        public int Salary { get; set; }
        public int Deptid { get; set; }
    }
}
