using Google.Cloud.Firestore;
using System;
using System.IO;

namespace SistemaEscolar.Core.FirebaseConfig
{
    public static class FirestoreDbFactory
    {
        private static FirestoreDb _instance;

        public static FirestoreDb GetDb()
        {
            if (_instance != null)
                return _instance;

            // Pasta onde o executável está rodando (SistemaEscolar.App/bin/Debug)
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Caminho até o JSON dentro do bin
            var credPath = Path.Combine(basePath, "FirebaseConfig", "sistema-escolar-no-sql-firebase-adminsdk-fbsvc-bf9b9afa4d.json");

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credPath);

            // Pegue o Project ID no console do Firebase (ex.: "sistema-escolar-no-sql")
            string projectId = "sistema-escolar-no-sql";

            _instance = FirestoreDb.Create(projectId);
            return _instance;
        }
    }
}


