using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naming
{
    public partial class Form1 : Form
    {
        public List<string> Names;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var logFile = File.ReadAllLines("../../NameSuggestions.txt");
            Names = new List<string>(logFile);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            string str = textBoxName.Text;
            string hint = "";

            if (str != "")
            {
                bool isFirst = true;
                foreach (string name in Names)
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
                Names.Add(textBoxName.Text);
                MessageBox.Show(textBoxName.Text + " Added to Suggestions List");
                textBoxName.Clear();
                textBoxName.Focus();
                lblSuggestions.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            using (TextWriter tw = new StreamWriter("../../NameSuggestions.txt"))
            {
                foreach (String str in Names)
                    tw.WriteLine(str);
            }
        }

    }
}
