using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CoreTests
{
    public class TestNotificationColleague : INotificationHandler<TestNotification>
    {
        private readonly ITestedService testHandler;

        public TestNotificationColleague(ITestedService testHandler)
        {
            this.testHandler = testHandler;
        }

        public Task Handle(TestNotification notification, CancellationToken cancellationToken)
        {
            testHandler.Test(notification);
            return Task.Run(() =>{ });
        }
    }

    public interface ITestedService
    {
        void Test(TestNotification notification);
    }

    class TestedService : ITestedService
    {
        public void Test(TestNotification notification)
        {
            
        }
    }


    public record TestNotification(int value = 0) : INotification;
}