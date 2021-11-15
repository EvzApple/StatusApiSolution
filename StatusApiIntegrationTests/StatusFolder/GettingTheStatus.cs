using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StatusApiIntegrationTests.StatusFolder
{
    public class GettingTheStatus : IClassFixture<TestingWebApiFactory<Program>>
    {
        private readonly HttpClient _client;

        public GettingTheStatus(TestingWebApiFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetA200StatusResponse()
        {
            var response = await _client.GetAsync("/status");//don't go to this until below returns ok
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task HasCorrectMediaType()
        {
            var response = await _client.GetAsync("/status");
            Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }

        [Fact] 
        public async Task HasCorrectEntity()
        {
            //this is "does it return the right data?"

        }
    }
}
