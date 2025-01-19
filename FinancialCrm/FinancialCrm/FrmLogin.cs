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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var username = txtUser.Text;
            var password = txtPassword.Text;

            using (var db = new FinancialCrmDbEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null)
                {
                    MessageBox.Show("GİRİŞ BAŞARILI");
                   
                }
                else
                {
                    MessageBox.Show("Kullanıcı yok veya bilgiler hatalı...");
                }
            }








        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
