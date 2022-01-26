using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.Follow.Steps.Model;

namespace ICSharpCode.Demo
{
    public partial class DemoStepDialog : Form
    {
        public DemoStepDialog()
        {
            InitializeComponent();

            EventHandler cond_delegate = delegate(object sender,EventArgs e){
                Button btn = sender as Button;
                Next = (StepOut)Enum.Parse(typeof(StepOut), btn.Text);
                
                Close();
            };
            button1.Click += cond_delegate;
            button2.Click += cond_delegate;
            button3.Click += cond_delegate;
            button4.Click += cond_delegate;
            button5.Click += cond_delegate;
            button6.Click += cond_delegate;
        }
        public StepOut Next { get; set; }
        public string Args {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
    }
}
