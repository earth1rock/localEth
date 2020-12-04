using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        static async Task transaction(string senderAddress, string password, string receiver, decimal value)
        {

            var account = new ManagedAccount(senderAddress, password);
            var web3 = new Web3(account);

            var sendTransactin = await web3.Eth.GetEtherTransferService().TransferEtherAndWaitForReceiptAsync(receiver, value);
            MessageBox.Show("123"+sendTransactin.TransactionHash.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "")&&(textBox2.Text != "")&&(textBox3.Text != "")&&(textBox4.Text != ""))
            {
                 transaction(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), Convert.ToDecimal(textBox4.Text.Trim()));
               
            }
            else
            {
                MessageBox.Show("Заполните входные поля!", "Ошибка!");
            }

        }
    }
}
