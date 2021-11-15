using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusApi;
using StatusApi.Services;
using Moq;
using Microsoft.Extensions.DependencyInjection;

namespace StatusApiIntegrationTests
{
    public class TestingWebApiFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                //see if ISystemTime service in services collection
                var systemTimeDescriptor = services.SingleOrDefault(d => d.ServiceType ==
                typeof(ISystemTime));
                //if there is, remove it
                if (systemTimeDescriptor != null)
                {
                    services.Remove(systemTimeDescriptor);
                }
                //and add in fake version of it
                var stubbedTimeSystem = new Mock<ISystemTime>();
                stubbedTimeSystem.Setup(s => s.GetCurrent()).Returns(
                    new DateTime(1969, 4, 20, 23, 59, 00));
                services.AddTransient<ISystemTime>(_ => stubbedTimeSystem.Object);

            });
        }
    }
}