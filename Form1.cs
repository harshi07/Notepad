using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        bool index = false;
        String path;
        public Form1()
        {
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled-Notepad";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            if (op1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(op1.FileName,RichTextBoxStreamType.PlainText);
            }
            this.Text=op1.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            if (index == false)
            {
                sd.Filter = "Text Document(*.txt)|*.txt";
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                }
                path=sd.FileName;
                this.Text=sd.Filter;
                index=true;
            }
            else
            {
                richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to save?","unsavedfile",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    richTextBox1.Modified = false;
                    saveToolStripMenuItem_Click(sender, e);
                     this.Close();
                }
                else
                {
                    richTextBox1.Modified = false;
                    this.Close();
                }
            }
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cd.Color;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument p = new PrintDocument();
            pageSetupDialog1.Document = p;
            pageSetupDialog1.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Text Document(*.txt)*.txt|All Filter(*.*)";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
            }
            path = sd.FileName;
            this.Text = sd.FileName;
            index = true;

        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = (DateTime.Now).ToString();
        }

      }
}
