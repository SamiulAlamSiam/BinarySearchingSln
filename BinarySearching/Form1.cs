using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySearching
{
    public enum StepEnum
    {
        Start = 1,
        Select = 2,
        Compair = 3,
        Success = 4,
        Failure = 5
    }

    public partial class Form1 : Form
    {
        private int search;
        public Form1()
        {
            InitializeComponent();
        }

        List<Button> allButtons = new List<Button>();
        private StepEnum currentStep;
        private int i = -1, j = -1,selectedIndex=0;
        private Button btnCompare;

        private void Form1_Load(object sender, EventArgs e)
        {
            allButtons.Add(button1);
            allButtons.Add(button2);
            allButtons.Add(button3);
            allButtons.Add(button4);
            allButtons.Add(button5);
            allButtons.Add(button6);
            allButtons.Add(button7);
            currentStep = StepEnum.Start;

            txtSeach.Text = allButtons.Count.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtSeach.Text == "")
            {
                MessageBox.Show("Please Insert First");
                txtSeach.Focus();
                txtSeach.Text = "";
                return;
            }

            if (!Int32.TryParse(txtSeach.Text, out search))
            {
                MessageBox.Show("Please Insert Right First");
                txtSeach.Focus();
                txtSeach.Text = "";
                return;
            }

            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < allButtons.Count; k++)
            {
                allButtons[k].BackColor = Color.DarkCyan;
            }

            if (currentStep == StepEnum.Start)
            {
                Start();
            }
            else if (currentStep == StepEnum.Select)
            {
                Selection();
            }
            else if (currentStep == StepEnum.Compair)
            {
                Comparie();
            }
            else if (currentStep == StepEnum.Success)
            {
                MessageBox.Show("matched");
            }
            else if (currentStep == StepEnum.Failure)
            {
                Failure();
            }
        }

        private void Failure()
        {
            int btnNumber = Int32.Parse(btnCompare.Text);
            int txtNumber = Int32.Parse(txtSeach.Text);

            var delButtons = new List<Button>();

            if (btnNumber > txtNumber)
            {
                for (int k = selectedIndex; k < allButtons.Count; k++)
                {
                    delButtons.Add(allButtons[k]);
                }
            }
            else if (btnNumber < txtNumber)
            {
                for (int k = 0; k <=selectedIndex; k++)
                {
                    delButtons.Add(allButtons[k]);
                }
            }

            foreach (var delButton in delButtons)
            {
                allButtons.Remove(delButton);
                delButton.Dispose();
            }

            currentStep = StepEnum.Select;
        }

        private void Comparie()
        {
            if (btnCompare.Text == txtSeach.Text)
            {
                btnCompare.BackColor = Color.DarkGreen;
                currentStep = StepEnum.Success;
            }
            else
            {
                btnCompare.BackColor = Color.DarkRed;
                currentStep = StepEnum.Failure;
            }
        }

        private void Selection()
        {
            i = allButtons.Count / 2;
            selectedIndex = i;
            allButtons[i].BackColor = Color.DarkBlue;
            btnCompare = allButtons[i];

            currentStep = StepEnum.Compair;
        }

        private void Start()
        {
            currentStep = StepEnum.Select;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
