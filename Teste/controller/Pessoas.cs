using Google.Cloud.Firestore;
using Microsoft.VisualBasic.ApplicationServices;

namespace Teste.controller;

public class Pessoas
{
    private FirestoreDb db;
    private CollectionReference userCollectionRef;


    public Pessoas(FirestoreDb db)
    {
        this.db = db;
        this.userCollectionRef = db.Collection("users");
    }

    public async Task<DocumentSnapshot[]> GetAllUsers()
    {
        QuerySnapshot Pesquisa = await userCollectionRef.GetSnapshotAsync();
        return Pesquisa.Documents.ToArray();
    }

    public async void criarUsuario(string nome, string idade)
    {
        var data = new
        {
            Nome = nome,
            Idade = idade,
        };
        DocumentReference document = await userCollectionRef.AddAsync(data);
    }

    public async Task atualizaUsuario(string id, string nome, int idade)
    {
        DocumentReference usuario = userCollectionRef.Document(id);
        var data = new Dictionary<string, object>
        {
            { "Idade", idade },
            { "Nome", nome}
        };
        await usuario.UpdateAsync(data);
    }

    public async Task deletarUsuario(string id)
    {
        DocumentReference usuario = userCollectionRef.Document(id);
        await usuario.DeleteAsync();
    }
}