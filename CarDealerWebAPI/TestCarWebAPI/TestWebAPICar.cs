using NUnit.Framework;
using System.Net.Http;
using Xunit;

namespace TestCarWebAPI
{
    public class TestWebAPICar
    {
        private HttpClient _client;
        public TestWebAPICar()
        {
            _client = new HttpClient();
        }

        private async HttpResponseMessage getCar(int carId)
        {
               return await _client.GetAsync()
        }

        [Test]
        [TestCase("7")]
        public void GetCarReturnsCarOk(int id)
        {

            


        }

    }
}