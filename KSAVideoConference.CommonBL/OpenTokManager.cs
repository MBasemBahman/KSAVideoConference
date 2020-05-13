using OpenTokSDK;

namespace KSAVideoConference.CommonBL
{
    public static class OpenTokManager
    {
        private static readonly int API_KEY = 46693282;
        private static readonly string API_SECRET = "1a54c61b9442c382630630024d9d5e352bf9e920";

        public static string CreateSessionId()
        {
            // Set the following constants with the API key and API secret
            // that you receive when you sign up to use the OpenTok API:
            OpenTok opentok = new OpenTok(API_KEY, API_SECRET);

            //Generate a basic session. Or you could use an existing session ID.
            string sessionId = opentok.CreateSession().Id;

            return sessionId;
        }

        public static string GenerateToken(string sessionId)
        {
            OpenTok opentok = new OpenTok(API_KEY, API_SECRET);

            string token = opentok.GenerateToken(sessionId);

            return token;
        }

        public static string GenerateToken(string sessionId, string type)
        {
            OpenTok opentok = new OpenTok(API_KEY, API_SECRET);

            string token = opentok.GenerateToken(sessionId, Role.PUBLISHER, 0, type);

            return token;
        }
    }
}
