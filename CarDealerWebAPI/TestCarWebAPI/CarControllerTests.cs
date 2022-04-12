using Core.CarDealer.Models;
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
    public class CarControllerTests
    {
        private HttpClient _client;
        public CarControllerTests()
        {
            _client = new HttpClient();
        }

        private async Task<HttpResponseMessage> getCar(int carId)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri("https://localhost:7288/api/cars/Get" + carId.ToString())
            };
            return await _client.SendAsync(request);
        }

        [Test]
        [TestCase("7")]
        [TestCase("9")]
        public async void GetCarReturnsOk(int id)
        {
            HttpResponseMessage response = await getCar(id);
            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        [TestCase("7")]
        [TestCase("8")]
        public async void GetCarReturnsCar(int id)
        {
            HttpResponseMessage response = await getCar(id);
            Assert.IsInstanceOf(typeof(Car), response.Content.GetType());
        }


    }
}
