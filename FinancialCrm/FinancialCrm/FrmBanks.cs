using FinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;


namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

         FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        
        private void FrmBanks_Load(object sender, EventArgs e)
        {

            //banka bakiyeleri  
            var ziraatBankBalance = db.Banks.Where(x=> x.BankTitle== "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x=> x.BankTitle== "VakıfBank").Select(y=>y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();


            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() +" ₺";
            lblVakifBankBalance.Text= vakifBankBalance.ToString() + " ₺";
            lblIsBankBalance.Text= isBankBalance.ToString() + " ₺";

            // banka hareketleri

            var bankprocess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankprocess1.Description + " " + bankprocess1.Amount + " " + bankprocess1.ProcessDate;



            var bankprocess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankprocess2.Description + " " + bankprocess2.Amount + " " + bankprocess2.ProcessDate;

            var bankprocess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankprocess3.Description + " " + bankprocess3.Amount + " " + bankprocess3.ProcessDate;


            var bankprocess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankprocess4.Description + " " + bankprocess4.Amount + " " + bankprocess4.ProcessDate;


            var bankprocess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankprocess5.Description + " " + bankprocess5.Amount + " " + bankprocess5.ProcessDate;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling  frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programdan çıkmak istedğinize emin misiniz ?");
        }
    }
}
