using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            Categories category = new Categories();
            category.CategoryName = categoryName;
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı bir şekilde eklendi", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);

            var removeValues = db.Categories.Find(id);
            db.Categories.Remove(removeValues);
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı bir şekilde silindi", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);
            var values = db.Categories.Find(id);
            values.CategoryName = categoryName;
            db.SaveChanges();
            MessageBox.Show("Kategori başarılı bir şekilde sistemde güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var values2 = db.Categories.ToList();
            dataGridView1.DataSource = values2;
        }
    }
}
