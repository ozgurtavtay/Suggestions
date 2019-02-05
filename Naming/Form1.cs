using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naming
{
    public partial class Form1 : Form
    {
        Suggestions s = new Suggestions();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            string str = textBoxName.Text;
            string hint = "";

            if (str != "")
            {
                bool isFirst = true;
                foreach (string name in s.Names)
                {
                    if (name.ToLower().IndexOf(str) == 0)
                    {
                        if (isFirst)
                        {
                            hint += name;
                            isFirst = false;
                        }
                        else
                        {
                            hint += " --- " + name;
                        }
                    }
                }

                if (hint == "")
                {
                    hint = "No Suggestions";
                }

            }

            lblSuggestions.Text = hint;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                s.Names.Add(textBoxName.Text);
                MessageBox.Show(textBoxName.Text + " Added to Suggestions List");
                textBoxName.Clear();
                textBoxName.Focus();
                lblSuggestions.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
