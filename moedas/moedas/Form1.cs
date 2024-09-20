using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moedas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form3 login = new Form3();
            login.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numista");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT `id_colecion`, `Nome` FROM `colecion`;", conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cbColecao.DataSource = dt;
                cbColecao.DisplayMember = "Nome";
                cbColecao.ValueMember = "id_colecion";
                conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo de errado não esta certo. \n" + erro.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cbNome.DisplayMember = "nome";
                cbNome.ValueMember = "id";
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numista");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT `id`, `Nome` FROM `moeda`;", conn);
                MySqlDataReader drNome = cmd.ExecuteReader();
                DataTable dtNome = new DataTable();
                dtNome.Load(drNome);
                cbNome.DataSource = dtNome;

                conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo de errado não esta certo. \n" + erro.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txbNome.Text != "")
            {
                try
                {
                    if (cbColecao.SelectedValue != null)
                    {
                        int selectedId = Convert.ToInt32(cbColecao.SelectedValue);
                        MessageBox.Show("ID Selecionado: " + selectedId);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum item selecionado.");
                    }
                    MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numista");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `moeda` (`Nome`,`ISO`, `Pais`, `Emissao`, `Valor`, `Metal`, `Peso`, `Diametro`, `Variedades`, `Anverso`, `Verso`, `Erros`, `Outros`, `DataAquisicao`,`ValorAquisicao`, `LocalAquisicao`, `Condicion`, `id_colecion`) VALUES (@nome, @iso, @pais, @emisssao, @valor, @metal, @peso, @diametro, @variedades, @anverso, @verso, @erros, @outros, @data, @valoraquisicao, @local, @condicion, @idcolecion);", conn);
                    cmd.Parameters.AddWithValue("@nome", txbNome.Text);
                    cmd.Parameters.AddWithValue("@iso", txbISO.Text);
                    cmd.Parameters.AddWithValue("@pais", txbPais.Text);
                    cmd.Parameters.AddWithValue("@emisssao", txbEmissao.Text);
                    cmd.Parameters.AddWithValue("@valor", txbValor.Text);
                    cmd.Parameters.AddWithValue("@metal", txbMetal.Text);
                    cmd.Parameters.AddWithValue("@peso", txbPeso.Text);
                    cmd.Parameters.AddWithValue("@diametro", txbDiametro.Text);
                    cmd.Parameters.AddWithValue("@variedades", txbVariavel.Text);
                    cmd.Parameters.AddWithValue("@anverso", txbAnverso.Text);
                    cmd.Parameters.AddWithValue("@verso", txbVerso.Text);
                    cmd.Parameters.AddWithValue("@erros", txbErros.Text);
                    cmd.Parameters.AddWithValue("@outros", txbOutros.Text);
                    cmd.Parameters.AddWithValue("@data", txbData.Text);
                    cmd.Parameters.AddWithValue("@valoraquisicao", txbValorAquisição.Text);
                    cmd.Parameters.AddWithValue("@local", txbLocal.Text);
                    cmd.Parameters.AddWithValue("@condicion", txbCondição.Text);
                    cmd.Parameters.AddWithValue("@idcolecion", cbColecao.SelectedValue);



                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message.ToString());
                }
                finally
                {
                    txbNome.Text = null;
                    txbISO.Text = null;
                    txbPais.Text = null;
                    txbEmissao.Text = null;
                    txbValor.Text = null;
                    txbMetal.Text = null;
                    txbPeso.Text = null;
                    txbDiametro.Text = null;
                    txbVariavel.Text = null;
                    txbAnverso.Text = null;
                    txbVerso.Text = null;
                    txbErros.Text = null;
                    txbData.Text = null;
                    txbValorAquisição.Text = null;
                    txbCondição.Text = null;
                    txbLocal.Text = null;
                    txbOutros.Text = null;

                }
            }
        }

        private void btnCadastrar1_Click(object sender, EventArgs e)
        {
            if (txbNomeColeçao.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numista");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `colecion` (`Nome`, `CertificadosAu`, `Notas`, `Links`) VALUES (@nomecolecao, @certificacao, @notas, @links);", conn);
                    cmd.Parameters.AddWithValue("@nomecolecao", txbNomeColeçao.Text);
                    cmd.Parameters.AddWithValue("@certificacao", txbCertificação.Text);
                    cmd.Parameters.AddWithValue("@notas", txbNotas.Text);
                    cmd.Parameters.AddWithValue("@links", txbReferencias.Text);


                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ta errado brow!");
                    MessageBox.Show(Ex.Message.ToString());
                }
                finally
                {
                    txbNomeColeçao.Text = null;
                    txbCertificação.Text = null;
                    txbNotas.Text = null;
                    txbReferencias.Text = null;

                }
            }
        }

        private void btnCadastrar2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (cbNome.SelectedValue != null)
                    {
                        int selectedId = Convert.ToInt32(cbNome.SelectedValue);
                        MessageBox.Show("ID Selecionado: " + selectedId);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum item selecionado.");
                    }

                    MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numista");
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `variacaopreco` (`id_Moeda`, `Variacion`, `data`) VALUES (@idMoeda, @variacion, @data);", conn);
                    cmd.Parameters.AddWithValue("@idMoeda", cbNome.SelectedValue);
                    cmd.Parameters.AddWithValue("@variacion", txbVariavel.Text);
                    cmd.Parameters.AddWithValue("@data", txbDataVariavel.Text);


                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ta errado brow!");
                    MessageBox.Show(Ex.Message.ToString());
                }
                finally
                {
                    txbVariavel.Text = null;
                    txbDataVariavel = null;

                }
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
