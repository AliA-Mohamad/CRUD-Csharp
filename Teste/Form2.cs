
using Teste.controller;

namespace Teste
{
    public partial class Form2 : Form
    {
        private string id;
        private string nome;
        private int idade;
        private Pessoas db;

        public Form2(string id, string nome, int idade, Pessoas db)
        {
            InitializeComponent();

            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.db = db;

            label4.Text = id;
            textBox2.Text = nome;
            textBox3.Text = idade.ToString();
        }

        private async void btnDeletar_Click(object sender, EventArgs e)
        {
            await db.deletarUsuario(id);
            this.Close();
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            await db.atualizaUsuario(id, textBox2.Text, int.Parse(textBox3.Text));
            this.Close();
        }
    }
}
