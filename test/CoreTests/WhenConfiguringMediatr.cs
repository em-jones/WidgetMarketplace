using Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace CoreTests
{
    public class WhenConfiguringMediatr
    {
        [Fact]
        public async void NotifiableColleaguesAreConfiguredInIoc()
        {
            // Arrange
            var services = new ServiceCollection();
            var mockTestedService = new Mock<ITestedService>();
            var testNotification = new TestNotification(200);
            mockTestedService
                .Setup(x => x.Test(It.IsAny<TestNotification>()))
                .Verifiable();
            services.AddSingleton<ITestedService>(mockTestedService.Object);

            var bootstrapper =  ExtensionsModule.MediatorBootstrapper<WhenConfiguringMediatr>(services);

            bootstrapper.Invoke();

            using var ioc = services.BuildServiceProvider();
            var mediator = ioc.GetService<IMediator>();
            
            // Act
            await mediator.Publish(testNotification);
            
            // Assert
            mockTestedService
                .Verify(x => x.Test(testNotification), Times.Once());
            
        }
    }
}