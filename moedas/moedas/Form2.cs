using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace moedas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            rtbMoedas.Visible = false;
            rtbTaxadeCambio.Visible = false;
            rtbColecao.Visible = false;

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=127.0.0.1;userid=root;password=root;database=numista";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
                try
                {

                    conn.Open();


                    string query = "SELECT * FROM moeda";


                    MySqlCommand cmd = new MySqlCommand(query, conn);


                    MySqlDataReader reader = cmd.ExecuteReader();


                    string resultado = "";


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            rtbMoedas.Visible = true;
                            resultado += "Nome: " + reader["Nome"].ToString() + "\n" + "ISO: " + reader["ISO"].ToString() + "\n" + "País de origem: " + reader["Pais"].ToString() + "\n" + "Ano de emissão: " + reader["Emissao"].ToString() + "\n" + "Valor da moeda: " + reader["Valor"].ToString() + "\n" + "Data da compra : " + reader["DataAquisicao"].ToString() + "\n" + "Valor da compra: " + reader["ValorAquisicao"].ToString() + "\n"+ "Local da compra: " + reader["LocalAquisicao"].ToString() + "\n" + "Condição da moeda: "+ reader["Condicion"].ToString() + "\n" + "Tipo de metal: " + reader["Metal"].ToString() + "\n" + "Peso da moeda: " + reader["Peso"].ToString() + "\n" + "Diametro da moeda: " + reader["Diametro"].ToString() + "\n" + "Variedades da moeda: " + reader["Variedades"].ToString() + "\n" + "Anverso da moeda: " + reader["Anverso"].ToString() + "\n" + "Verso: " + reader["Verso"].ToString() + "\n" + "Erros na moeda: "  + reader["Erros"].ToString() + "\n" + "Outras informações: "  + reader["Outros"].ToString() + "\n" + Environment.NewLine + "\n";
                            rtbMoedas.Text = resultado;
                        }
                    }
                    else
                    {
                        resultado = "Nenhum dado encontrado.";
                        rtbMoedas.Text = resultado;
                    }



                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
            string connectionString2 = "server=127.0.0.1;userid=root;password=root;database=numista";


            using (MySqlConnection conn = new MySqlConnection(connectionString2))
                try
            {

                conn.Open();


                string query = "SELECT * FROM colecion";


                MySqlCommand cmd = new MySqlCommand(query, conn);


                MySqlDataReader reader = cmd.ExecuteReader();


                string resultado = "";


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rtbColecao.Visible = true;
                        resultado += "Nome: " + reader["nome"].ToString() + "\n" + "ISO: " + reader["CertificadosAu"].ToString() + "\n" + "Informações sobre a coleção: " + reader["Notas"].ToString() + "\n" + "Link de referência: " + reader["Links"].ToString() + Environment.NewLine + "\n";
                        rtbColecao.Text = resultado;
                    }
                }
                else
                {
                    resultado = "Nenhum dado encontrado.";
                    rtbColecao.Text = resultado;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
            }
            string connectionString1 = "server=127.0.0.1;userid=root;password=root;database=numista";


            using (MySqlConnection conn = new MySqlConnection(connectionString1))
                try
            {

                conn.Open();


                string query = "SELECT * FROM variacaopreco";


                MySqlCommand cmd = new MySqlCommand(query, conn);


                MySqlDataReader reader = cmd.ExecuteReader();


                string resultado = "";


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rtbTaxadeCambio.Visible = true;
                        resultado += "Valor de variação: " + reader["Variacion"].ToString() + "\n" + "Data da variação: " + reader["data"].ToString() + Environment.NewLine + "\n";
                        rtbTaxadeCambio.Text = resultado;
                    }
                }
                else
                {
                    resultado = "Nenhum dado encontrado.";
                    rtbTaxadeCambio.Text = resultado;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
        
    

