using FirebaseAdmin.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSAVideoConference.CommonBL
{
    public static class NotificationManager
    {
        public static FirebaseNotificationModel Notification { get; set; }

        public static async Task<string> SendToTopic(Message message)
        {
            // Send a message to the device corresponding to the provided
            // registration token.
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            // Response is a message ID string.
            return response;
            // [END send_to_token]
        }

        public static async Task<int> SendMulticast(MulticastMessage message)
        {
            BatchResponse response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
            // See the BatchResponse reference documentation
            // for the contents of response.
            return response.SuccessCount;
            // [END send_multicast]
        }

        public static async Task<int> SubscribeToTopic(List<string> registrationTokens, string topic)
        {
            // Subscribe the devices corresponding to the registration tokens to the
            // topic
            TopicManagementResponse response = await FirebaseMessaging.DefaultInstance.SubscribeToTopicAsync(
                registrationTokens, topic);
            // See the TopicManagementResponse reference documentation
            // for the contents of response.
            return response.SuccessCount;
            // [END subscribe_to_topic]
        }

        public static Message CreateMessage(FirebaseNotificationModel Model)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                    {
                      {"NotificationType", Model.NotificationType.ToString()},
                      {"TargetId", Model.TargetId.ToString()},
                      {"ImgUrl", Model.ImgUrl},
                      {"collapse_id", Model.NotificationType.ToString()},
                      {"Title", Model.MessageHeading},
                      {"Body", Model.MessageContent},
                    };

            // [START apns_message]
            Message message = new Message
            {
                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Alert = new ApsAlert()
                        {
                            Title = Model.MessageHeading,
                            Body = Model.MessageContent,
                        }
                    },
                },
                Data = data,
                Topic = Model.Topic
            };
            // [END apns_message]
            return message;
        }

        public static MulticastMessage CreateMulticastMessage(FirebaseNotificationModel Model)
        {
            Dictionary<string, string> data = new Dictionary<string, string>
                    {
                      {"NotificationType", Model.NotificationType.ToString()},
                      {"TargetId", Model.TargetId.ToString()},
                      {"ImgUrl", Model.ImgUrl},
                      {"collapse_id", Model.NotificationType.ToString()},
                      {"Title", Model.MessageHeading},
                      {"Body", Model.MessageContent},
                    };

            // [START apns_message]
            MulticastMessage message = new MulticastMessage
            {
                Tokens = Model.RegistrationTokens,
                Apns = new ApnsConfig()
                {
                    Aps = new Aps()
                    {
                        Alert = new ApsAlert()
                        {
                            Title = Model.MessageHeading,
                            Body = Model.MessageContent,
                        }
                    },
                },
                Data = data,
            };
            // [END apns_message]
            return message;
        }
    }

    public class FirebaseNotificationModel
    {
        public FirebaseNotificationModel()
        {
            RegistrationTokens = new List<string>();
        }

        public KeyValuePair<int, string> NotificationType { get; set; }

        public int TargetId { get; set; }

        public string ImgUrl { get; set; }

        public string MessageHeading { get; set; }

        public string MessageContent { get; set; }

        public List<string> RegistrationTokens { get; set; }

        public string Topic { get; set; } = "all";
    }

    public class NotificationModelTest
    {
        public string RegistrationToken { get; set; }

        public string MessageHeading { get; set; }

        public string MessageContent { get; set; }
    }
}
