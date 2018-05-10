using System;
using System.Drawing;
using System.Windows.Forms;

/*Клюшин А. Используя Windows Forms, разработать игру “Угадай число”. Компьютер загадывает число от 1 до 100,
            а человек пытается его угадать за минимальное число попыток. 
            Для ввода данных от человека используется элемент TextBox.*/

namespace Task_2
{
    public partial class MainForm : Form
    {
        Random rnd = new Random();
        int hiddenNumber = 0;
        int counter = 0;
        
        public MainForm()
        {
            InitializeComponent();

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            hiddenNumber = rnd.Next(1, 101);
            btnStartGame.Enabled = false;
            btnCompare.Enabled = true;
            tbEnteredNumber.Enabled = true;
            lblResult.Text = String.Empty;
            lblResult.ForeColor = Color.Blue;
        }

        private void tbEnteredNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (int)e.KeyChar == (int)Keys.Back || (int)e.KeyChar == (int)Keys.Enter))
            {
                e.Handled = true;
            }
            else if((int)e.KeyChar != (int)Keys.Enter && (int)e.KeyChar != (int)Keys.Back && int.Parse(tbEnteredNumber.Text.Insert(tbEnteredNumber.Text.Length, e.KeyChar.ToString())) > 100)
            {
                e.Handled = true;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (hiddenNumber == int.Parse(tbEnteredNumber.Text))
            {
                counter++;
                lblResult.ForeColor = Color.ForestGreen;
                lblResult.Text = $"Вы угадали с {counter} попытки.\nЭто действительно {hiddenNumber}.";
                btnStartGame.Enabled = true;
                btnCompare.Enabled = false;
                tbEnteredNumber.Enabled = false;
            }
            else if (hiddenNumber > int.Parse(tbEnteredNumber.Text))
            {
                lblResult.Text = "Загаданное число больше";
                counter++;
            }
            else
            {
                lblResult.Text = "Загаданное число меньше";
                counter++;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            MessageBox.Show(this, "В данной программе вам необходимо угадать\nчисло от 1 до 100, загаданное компьютером.", "О программе");    
        }

        private void btnCompare_Click(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (hiddenNumber == int.Parse(tbEnteredNumber.Text))
                {
                    counter++;
                    lblResult.ForeColor = Color.ForestGreen;
                    lblResult.Text = $"Вы угадали с {counter} попытки.\nЭто действительно {hiddenNumber}.";
                    btnStartGame.Enabled = true;
                    btnCompare.Enabled = false;
                    tbEnteredNumber.Enabled = false;
                }
                else if (hiddenNumber > int.Parse(tbEnteredNumber.Text))
                {
                    lblResult.Text = "Загаданное число больше";
                    counter++;
                }
                else
                {
                    lblResult.Text = "Загаданное число меньше";
                    counter++;
                }
            }
        }
    }
}
