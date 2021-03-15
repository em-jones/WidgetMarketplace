using System;
using System.Linq;
using System.Threading.Tasks;
using Core;
using FluentAssertions;
using LanguageExt.Common;
using Orleans.TestingHost;
using Xunit;

namespace CoreTests
{
    public class WhenImplementingADistributedObject 
    {

        [Fact]
        public async Task Test1()
        {
            var valuesToAdd = new[] {1, 2, 3, 4, 5, 6};
            

            var anticipatedResult = new DistributedState(){ val = valuesToAdd.Sum() };

            var builder = new TestClusterBuilder();
            builder.Options.ServiceId = Guid.NewGuid().ToString();
            var cluster = builder.Build();
            cluster.Deploy();

            var distributedType = cluster.GrainFactory
                .GetGrain<ITestDistributedType>(Guid.NewGuid());

            valuesToAdd.Map(v => new AddValue(v)).ToList().ForEach(async m => await distributedType.Handle(m));
            
            cluster.StopAllSilos();
            
            Result<DistributedState> result = await distributedType.Get();

            // Assert
            result.Should().NotBeNull();

            var _ = result switch
            {
                {IsSuccess: true} => result.IfSucc((resultOfHandleOp) =>
                {
                    resultOfHandleOp.val.Should().Be(20);
                }),
                {IsSuccess: false} => throw new Exception("This test is failing now?")
            };
        }

    }

    
}