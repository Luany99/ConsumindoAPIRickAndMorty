using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const string apiUrl = "https://rickandmortyapi.com/api/character";

        public Form1()
        {
            InitializeComponent();
            buscar.Click += Buscar_Click;
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    string json = await response.Content.ReadAsStringAsync();

                    // Faz o parse do JSON para um objeto CharacterResponse
                    CharacterResponse characterResponse = JsonConvert.DeserializeObject<CharacterResponse>(json);

                    // Define os personagens no DataGridView
                    dataGridView1.DataSource = characterResponse.results;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao carregar os personagens: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buscar_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    // Classes para armazenar os dados dos personagens
    public class CharacterResponse
    {
        public Character[] results { get; set; }
    }

    public class Character
    {
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
    }
}
