using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moedas
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label3.Text = "Com Gringotes você poderá salvar tudo da sua coleção de moedas. Assim facilitando sua visualização! \n Dentro desse banco é possível salvar diversas informações, desde a coleção até a taxa de câmbio.";


        }

        private void toolStripContainer2_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
               this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Não foi possivel encontrar essa guia");
            }
           
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 tela = new Form2();
                tela.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Não foi possivel encontrar essa guia");
            }
            finally
            {
                this.Close();
            }
        }

      
    }
}
