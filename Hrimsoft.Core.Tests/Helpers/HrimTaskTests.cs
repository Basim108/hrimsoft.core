using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FluentAssertions;
using Hrimsoft.Core.Helpers;
using Hrimsoft.Core.Tests.FakeServices;
using Xunit;

namespace Hrimsoft.Core.Tests.Helpers
{
    public class HrimTaskTests
    {
        private readonly RemoteService _service;

        public HrimTaskTests()
        {
            _service = new RemoteService();
        }

        [Fact]
        public async Task Params_Four_Calls_Should_Take_No_More_Than_150_ms()
        {
            var sw    = Stopwatch.StartNew();
            var task1 = _service.GetAsync(false, 1);
            var task2 = _service.GetAsync(false, 2);
            var task3 = _service.GetAsync(false, 3);
            var task4 = _service.GetAsync(false, 4);
            await HrimTask.WhenAll(task1, task2, task3, task4);
            var elapsed = sw.ElapsedMilliseconds;
            Assert.True(elapsed <= 150);
        }

        [Fact]
        public async Task Array_Four_Calls_Should_Take_No_More_Than_150_ms()
        {
            var sw = Stopwatch.StartNew();
            var arr = new Task[]
                      {
                          _service.GetAsync(false, 1),
                          _service.GetAsync(false, 2),
                          _service.GetAsync(false, 3),
                          _service.GetAsync(false, 4),
                      };
            await HrimTask.WhenAll((IEnumerable<Task>) arr);
            var elapsed = sw.ElapsedMilliseconds;
            Assert.True(elapsed <= 150);
        }

        [Fact]
        public async Task Params_Should_Not_Miss_Errors_From_Two_Fail_Tasks()
        {
            var task1 = _service.GetAsync(false, 1);
            var task2 = _service.GetAsync(true,  2);
            var task3 = _service.GetAsync(true,  3);
            var task4 = _service.GetAsync(false, 4);
            var aggEx = await Assert.ThrowsAsync<AggregateException>(async () => await HrimTask.WhenAll(task1, task2, task3, task4));
            aggEx.InnerExceptions.Count.Should().Be(2);
            task1.IsCompletedSuccessfully.Should().BeTrue();
            task1.Result.Should().BeTrue();
            task2.IsFaulted.Should().BeTrue();
            task3.IsFaulted.Should().BeTrue();
            task4.IsCompletedSuccessfully.Should().BeTrue();
            task4.Result.Should().BeTrue();
        }

        [Fact]
        public async Task Array_Should_Not_Miss_Errors_From_Two_Fail_Tasks()
        {
            var task1 = _service.GetAsync(false, 1);
            var task2 = _service.GetAsync(true,  2);
            var task3 = _service.GetAsync(true,  3);
            var task4 = _service.GetAsync(false, 4);
            var array = new Task[] {task1, task2, task3, task4};
            var aggEx = await Assert.ThrowsAsync<AggregateException>(async () => await HrimTask.WhenAll((IEnumerable<Task>) array));
            aggEx.InnerExceptions.Count.Should().Be(2);
            task1.IsCompletedSuccessfully.Should().BeTrue();
            task1.Result.Should().BeTrue();
            task2.IsFaulted.Should().BeTrue();
            task3.IsFaulted.Should().BeTrue();
            task4.IsCompletedSuccessfully.Should().BeTrue();
            task4.Result.Should().BeTrue();
        }
    }
}