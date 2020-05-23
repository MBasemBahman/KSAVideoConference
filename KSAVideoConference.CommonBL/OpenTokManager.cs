using OpenTokCore;
using System.Threading.Tasks;

namespace KSAVideoConference.CommonBL
{
    public static class OpenTokManager
    {
        private static readonly int ApiKey = 46693282;
        private static readonly string ApiSecret = "1a54c61b9442c382630630024d9d5e352bf9e920";

        public static async Task<string> CreateSessionId()
        {
            OpenTok OpenTok = new OpenTok(ApiKey, ApiSecret);

            // Create a session that will attempt to transmit streams directly between clients
            Session session = await OpenTok.CreateSession();
            // Store this sessionId in the database for later use:
            string sessionId = session.Id;

            return sessionId;
        }

        public static string GenerateToken(string sessionId)
        {
            OpenTok OpenTok = new OpenTok(ApiKey, ApiSecret);

            return OpenTok.GenerateToken(sessionId);
        }
    }
}
