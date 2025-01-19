using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBankProcesses : Form
    {
        public FrmBankProcesses()
        {
            InitializeComponent();
        }


        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            displayData();

            comboBox1.DisplayMember = "BankTitle";
            comboBox1.ValueMember = "BankId";
            var bankList = db.Banks.ToList();
            comboBox1.DataSource = bankList;



            mtxDate.Mask = "00/00/0000";
        }

        private void displayData()
        {
            var values = db.BankProcesses.Include(b => b.Banks).Select(o => new
            {
                o.BankProcessId,
                o.Description,
                o.ProcessDate,
                o.ProcessType,
                o.Amount,
                o.Banks.BankTitle,

            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            var procesDate = mtxDate.Text;
            string procesType = txtProcesesType.Text;
            int amount = int.Parse(txtProcessesAmount.Text);
            int bankName = int.Parse(comboBox1.SelectedValue.ToString());




            BankProcesses bankProcesses = new BankProcesses();
            bankProcesses.Description = description;
            bankProcesses.ProcessDate = Convert.ToDateTime(procesDate);
            bankProcesses.ProcessType = procesType;
            bankProcesses.Amount = amount;
            bankProcesses.BankId = bankName;
            db.BankProcesses.Add(bankProcesses);
            db.SaveChanges();
            MessageBox.Show("işlem başarılı");
            displayData();


        }

        private void button10_Click(object sender, EventArgs e)
        {

            string description = txtDescription.Text;
            var procesDate = mtxDate.Text;
            string procesType = txtProcesesType.Text;
            int amount = int.Parse(txtProcessesAmount.Text);
            int bankName = int.Parse(comboBox1.SelectedValue.ToString());

            int updateId = int.Parse(txtBankProcessesId.Text);

            var values =  db.BankProcesses.Find(updateId);
          
            values.Description = txtDescription.Text;
            values.ProcessDate = Convert.ToDateTime(procesDate);
            values.ProcessType = procesType;
            values.Amount = amount;
            values.BankId = bankName;
            db.SaveChanges();
            MessageBox.Show("Güncelleme yapıldı.");
            displayData();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int removeId = int.Parse(txtBankProcessesId.Text);

            var values = db.BankProcesses.Find(removeId);
            db.BankProcesses.Remove(values);
            db.SaveChanges();
            MessageBox.Show("Banka hareketi başarıyla silindi");
            displayData();

        }
    }
}
