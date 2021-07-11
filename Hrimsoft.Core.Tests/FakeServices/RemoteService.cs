using System;
using System.Threading.Tasks;

namespace Hrimsoft.Core.Tests.FakeServices
{
    public class RemoteService
    {
        public async Task<bool> GetAsync(bool fail, int id)
        {
            await Task.Delay(100);
            if (fail)
                throw new ApplicationException($"error in {id}");
            return true;
        } 
    }
}