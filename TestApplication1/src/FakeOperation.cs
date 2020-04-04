using System;
using System.Threading.Tasks;

namespace TestApplication1.src
{
    public class FakeOperation
    {
        public FakeOperation()
        {
        }

        public async Task<int> FakeFunc(bool pleaseGiveMeADeadlock)
        {
            if (pleaseGiveMeADeadlock)
            {
                // Equivalent to `.ConfigureAwait(true)`.
                // The current SynchronzsationContext is used and
                // since we call this from a UI thread, this
                // will execute and call back into the UI thread.
                await Task.Delay(100);
            }
            else
            {
                // This will not use the current SynchronzsationContext,
                // so the task will execute and call back into a thread
                // pool thread.
                await Task.Delay(1).ConfigureAwait(false);
            }

            // This will use whatever SynchronzsationContext was used last.
            // Once you doConfigureAwait(false).
            return await Task.FromResult<int>(new Random().Next());
        }
    }
}
