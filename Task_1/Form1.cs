using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class MainForm : Form
    {
        int counter = 0;
        Random rnd = new Random();
        Doubler newGame;

        List<string> stepList = new List<string>();

        public MainForm()
        {
            InitializeComponent();           
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            newGame = new Doubler(rnd.Next(20, 10001));
            counter = 0;
            lblCounter.Text = String.Empty;
            lblResult.Text = String.Empty;
            lblCurentNumber.ForeColor = Color.Black;
            lblRequiredNumber.Text = newGame.Finish.ToString();
            lblCurentNumber.Text = newGame.Current.ToString();
            btnIncrement.Enabled = true;
            btnDouble.Enabled = true;
            btnReset.Enabled = true;
            btnStartGame.Enabled = false;
            menuStartGame.Enabled = false;
            stepList.Add(newGame.Current.ToString());
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            newGame.Incremention();
            lblCurentNumber.Text = newGame.Current.ToString();
            counter++;
            lblCounter.Text = counter.ToString();
            stepList.Add(newGame.Current.ToString());
            if (counter > 0) btnCancel.Enabled = true; 
            if (int.Parse(lblCurentNumber.Text) == int.Parse(lblRequiredNumber.Text))
            {
                lblCurentNumber.ForeColor = Color.ForestGreen;
                lblResult.ForeColor = Color.ForestGreen;
                lblResult.Text = "Ура! Вы выиграли!";
                btnIncrement.Enabled = false;
                btnDouble.Enabled = false;
                btnReset.Enabled = false;
                btnStartGame.Enabled = true;
                menuStartGame.Enabled = true;
            }
            else if (int.Parse(lblCurentNumber.Text) > int.Parse(lblRequiredNumber.Text))
            {
                lblCurentNumber.ForeColor = Color.Red;
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "Увы! Вы проиграли!";
                btnIncrement.Enabled = false;
                btnDouble.Enabled = false;
                btnReset.Enabled = false;
                btnStartGame.Enabled = true;
                menuStartGame.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            newGame.Reset();
            lblCurentNumber.Text = newGame.Current.ToString();
            counter++;
            lblCounter.Text = counter.ToString();
            if (counter > 0) btnCancel.Enabled = true;
            stepList.Add("Reset");
        }

        private void btnDouble_Click(object sender, EventArgs e)
        {
            newGame.Redouble();
            lblCurentNumber.Text = newGame.Current.ToString();
            counter++;
            lblCounter.Text = counter.ToString();
            stepList.Add(newGame.Current.ToString());
            if(counter > 0) btnCancel.Enabled = true;
            if (int.Parse(lblCurentNumber.Text) == int.Parse(lblRequiredNumber.Text))
            {
                lblCurentNumber.ForeColor = Color.ForestGreen;
                lblResult.Text = "Ура! Вы выиграли!";
                btnIncrement.Enabled = false;
                btnDouble.Enabled = false;
                btnReset.Enabled = false;
                btnStartGame.Enabled = true;
                menuStartGame.Enabled = true;
            }
            else if (int.Parse(lblCurentNumber.Text) > int.Parse(lblRequiredNumber.Text))
            {
                lblCurentNumber.ForeColor = Color.Red;
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "Увы! Вы проиграли!";
                btnIncrement.Enabled = false;
                btnDouble.Enabled = false;
                btnReset.Enabled = false;
                btnStartGame.Enabled = true;
                menuStartGame.Enabled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnIncrement.Enabled = false;
            btnDouble.Enabled = false;
            btnReset.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
                if (counter - 1 != 0)
                {
                    if (stepList[counter - 1] != "Reset")
                    {
                        lblCurentNumber.Text = stepList[counter - 1];
                        newGame.Current = int.Parse(stepList[counter - 1]);
                        stepList[counter] = String.Empty;
                        counter--;
                        lblCounter.Text = counter.ToString();
                        if (!lblResult.Text.Equals(String.Empty))
                    {
                        lblResult.Text = String.Empty;
                        lblCurentNumber.ForeColor = Color.Black;
                        btnIncrement.Enabled = true;
                        btnDouble.Enabled = true;
                        btnReset.Enabled = true;
                    }
                    }
                    else
                    {
                        newGame.Current = 1;
                        stepList[counter] = String.Empty;
                        counter--;
                        lblCurentNumber.Text = "1";
                        lblCounter.Text = counter.ToString();
                    }

                }
                else
                {
                    if (stepList[counter - 1] != "Reset")
                    {
                        lblCurentNumber.Text = stepList[counter - 1];
                        stepList[counter] = String.Empty;
                        lblCounter.Text = String.Empty;
                        btnCancel.Enabled = false;
                }
                    else
                    {
                        newGame.Current = 1;
                        stepList[counter] = String.Empty;
                        lblCounter.Text = String.Empty;
                        btnCancel.Enabled = false;
                    }
                }
        }
    }
}
