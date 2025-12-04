using SistemaEscolar.Core.FirebaseConfig;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace SistemaEscolar.Core.Services
{
    public class AuditoriaNoSqlService
    {
        private readonly FirestoreDb _db;

        public AuditoriaNoSqlService()
        {
            _db = FirestoreDbFactory.GetDb();
        }

        public async Task RegistrarAsync(string tabela, string acao, object dados)
        {
            // Serializa o objeto para JSON para evitar problemas de conversão
            string dadosJson = JsonConvert.SerializeObject(
                dados,
                new JsonSerializerSettings
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                });

            var doc = new
            {
                tabela = tabela,
                acao = acao,
                data = DateTime.UtcNow,
                dados = dadosJson // string JSON
            };

            CollectionReference col = _db.Collection("auditoria");
            await col.AddAsync(doc);
        }

    }
}


