using Google.Cloud.Firestore;

namespace Teste;

internal class conect
{
    public static FirestoreDb iniciar(string id)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"Key.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        return FirestoreDb.Create(id);
    }
}