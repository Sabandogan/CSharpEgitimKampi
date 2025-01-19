using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinancialCrm
{
    public partial class FrmSpending : Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        FinancialCrmDbEntities   db  = new FinancialCrmDbEntities();
        private void FrmSpending_Load(object sender, EventArgs e)
        {
            displayData();
            mtxSpendingDate.Mask = "00/00/0000";
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            var categoryList = db.Categories.ToList();
            cmbCategory.DataSource = categoryList;


        }

        private void displayData()
        {
            var values = db.Spendings.Include(b => b.Categories).Select(o => new
            {
                o.SpendingId,
                o.SpendingTitle,
                o.SpendingAmount,
                o.SpendingDate,
                o.Categories.CategoryName,

            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            int spendingAmount = int.Parse(txtSpendingAmount.Text);
            var spendingDate = Convert.ToDateTime(mtxSpendingDate.Text);
            int category = int.Parse(cmbCategory.SelectedValue.ToString());



            Spendings spendings = new Spendings();


            spendings.SpendingTitle = spendingTitle;
            spendings.SpendingAmount = spendingAmount;
            spendings.SpendingDate = spendingDate;
            spendings.CategoryId  = category;
            db.Spendings.Add(spendings);
            db.SaveChanges();
            MessageBox.Show("Harcama kaydedildi");
            displayData();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateId = int.Parse(txtSpendingId.Text);


            var values = db.Spendings.Find(updateId);
            string spendingTitle = txtSpendingTitle.Text;
            int spendingAmount = int.Parse(txtSpendingAmount.Text);
            var spendingDate = Convert.ToDateTime(mtxSpendingDate.Text);
            int category = int.Parse(cmbCategory.SelectedValue.ToString());



            values.SpendingTitle = spendingTitle;
            values.SpendingAmount = spendingAmount;
            values.SpendingDate = spendingDate;
            values.CategoryId = category;
            db.SaveChanges();
            MessageBox.Show("Harcama Güncellendi");
            displayData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int removeId = int.Parse(txtSpendingId.Text);
            var removeValue = db.Spendings.Find(removeId);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Harcama silindi");
            displayData();
        }
    }
}
