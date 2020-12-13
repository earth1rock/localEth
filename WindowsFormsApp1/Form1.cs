using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nethereum.ABI.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.RPC.Eth;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //запуска geth
            Process process = new Process();

            process.StartInfo.FileName = "cmd";
            //geth --mine --http --http.corsdomain "*" --http.api eth,net,web3,personal,web3 --networkid 15 --datadir /path/to/data/dir --allow-insecure-unlock
            process.StartInfo.Arguments = @"/k geth --mine --http --http.corsdomain ""*"" --http.api eth,net,web3,personal,web3 --networkid 15 --datadir /path/to/data/dir --allow-insecure-unlock";
            //geth attach \\.\pipe\geth.ipc
            process.Start();         
        }

        //api
        static async Task GetAccountBalance()
        {
            //    var web3 = new Nethereum.Web3.Web3();

            //  var balance = await web3.Eth.GetBalance.SendRequestAsync("0x7999f617c4edcdc69d301806e3c62c6f301ce74a");//

            //  MessageBox.Show($"Balance in Wei: {balance.Value}");

            //  var etherAmount = Web3.Convert.FromWei(balance.Value);
            // MessageBox.Show($"Balance in Ether: {etherAmount}");

            //создал какой то аккаунт
            // var newAccount = await web3.Personal.NewAccount.SendRequestAsync("123456");
            // MessageBox.Show(newAccount.ToString());


            //список акканутов
            //var accountList = await web3.Eth.Accounts.SendRequestAsync();
            //string listAccount = String.Join("\n", accountList);
            //MessageBox.Show(listAccount);


            //авторизация и отправка
            var senderAddress = "0x5b21c8cc212f215e29897402a761690f82203637";
            var password = "123456";

            var account = new ManagedAccount(senderAddress, password);
            var web3 = new Web3(account);

            var gasPric = await web3.Eth.GasPrice.SendRequestAsync();
            MessageBox.Show(gasPric.Value.ToString());



            var sendTransactin = web3.Eth.GetEtherTransferService().TransferEtherAndWaitForReceiptAsync("0x200228e4c9d4f1b282ea59f443f201c0e401ad33", 1m);

        }

        //обновление списка аккаунтов при старте программы
        async private void Form1_Load(object sender, EventArgs e)
        {
            var web3 = new Nethereum.Web3.Web3();
            textBox4.Text = "";
            //список акканутов + баланс
            var accountList = await web3.Eth.Accounts.SendRequestAsync();

            int count = 1;
            string result = "";
            for (int i=0;i<accountList.Length;i++)
            {
                var balance = await web3.Eth.GetBalance.SendRequestAsync(accountList[i]);
                result += $"[ {count++} ]    {accountList[i]} = {Math.Round(Web3.Convert.FromWei(balance.Value), 3)} ETH {Environment.NewLine}";
            }
            textBox4.Text = result;
        }

        //открытие формы для регистрации аккаунтов
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 register = new Form2(); 
            register.Show();
        }

        //обновление списка аккаунтов
        private void button4_Click(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }

        //открытие формы для совершения транзакций
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 transaction = new Form3();
            transaction.Show();
        }
    }
}
