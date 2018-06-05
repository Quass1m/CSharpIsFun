using System.Threading.Tasks;

namespace CSharpIsFun.Features
{
    public class ValueTask
    {
        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }

        private bool cache = false;
        private int cacheResult;
        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cacheResult = 100;
            cache = true;
            return cacheResult;
        }
    }
}