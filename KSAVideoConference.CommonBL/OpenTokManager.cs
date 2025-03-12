using OpenTokCore;
using System.Threading.Tasks;

namespace KSAVideoConference.CommonBL
{
    public static class OpenTokManager
    {
        private static readonly int ApiKey ;
        private static readonly string ApiSecret ;

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
