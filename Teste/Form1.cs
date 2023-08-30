using Google.Cloud.Firestore;
using Teste.controller;

namespace Teste.Properties
{
    public partial class Form1 : Form
    {
        private Pessoas db;
        private string id;
        private string nome;
        private int idade;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConecta_Click(object sender, EventArgs e)
        {
            try
            {
                FirestoreDb conecta = conect.iniciar("ga31-69723");
                db = new Pessoas(conecta);
                label2.Text = "CONECTADO";
                label2.ForeColor = Color.Green;
                txtIdade.Visible = true;
                txtNome.Visible = true;
                btnCria.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                dataGridView1.Visible = true;
                button2.Visible = true;
            }
            catch
            {
                label2.Text = "Erro";
                label2.ForeColor = Color.Red;
            }
        }

        private async void btnAtualiza_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DocumentSnapshot[] userDocuments = await db.GetAllUsers();
            foreach (DocumentSnapshot document in userDocuments)
            {
                if (document.Exists)
                {
                    Dictionary<string, object> data = document.ToDictionary();
                    dataGridView1.Rows.Add(document.Id, data["Nome"], data["Idade"]);
                }
            }
        }

        private void btnCria_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string idade = txtIdade.Text;
            db.criarUsuario(nome, idade);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            id = selectedRow.Cells[0].Value.ToString()!;
            nome = selectedRow.Cells[1].Value.ToString()!;
            idade = int.Parse(selectedRow.Cells[2].Value.ToString()!);

            Form2 acaoForm = new(id, nome, idade, db);
            acaoForm.ShowDialog();
        }
    }
}
