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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            
        }

        static async Task registerAccount(String password)
        {
            var web3 = new Nethereum.Web3.Web3();

            //создал какой то аккаунт
            var newAccount = await web3.Personal.NewAccount.SendRequestAsync(password);
            MessageBox.Show("Хэш вашего аккаунта - "+newAccount.ToString(),"Успешная регистрация!");
            
        }

            private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "")&&(textBox1.Text.Length > 5))
            {
                registerAccount(textBox1.Text);
                this.Close();
                

            }
            else
            {
                MessageBox.Show("Введите пароль! Пароль должен содержать не менее 6 символов", "Ошибка!");
            }

        }
    }
}
