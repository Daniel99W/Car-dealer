using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestCarWebAPI
{
    [TestFixture]
    public  class MessageControllerTests
    {
        private HttpClient _client;

        public MessageControllerTests()
        {
            _client = new HttpClient();
        }


        private async Task<HttpResponseMessage> sendMessage(
            string message,
            int senderId,
            int receiverId,
            string subject)
        {
            var values = new Dictionary<string, object>();
            values.Add("message", message);
            values.Add("senderId", senderId);
            values.Add("receiverId", receiverId);
            values.Add("subject", subject);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri("https://localhost:7288/api/Messages/SendMessage"),
                Content = new StringContent(values.ToString(), Encoding.UTF8, "application/json")
            };
            return await _client.SendAsync(request);
        }

        [Test]
        [TestCase("Salut!",1,2,"Despre anuntul postat de tine")]
        public async void SendMessageReturnsOk(string message,int senderId,int receiverId,string subject)
        {
            HttpResponseMessage response = await sendMessage(message, senderId, receiverId, subject);
            Assert.Equals(HttpStatusCode.OK, response.IsSuccessStatusCode);
        }
    }
}
