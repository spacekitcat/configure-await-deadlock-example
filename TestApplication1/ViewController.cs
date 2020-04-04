using System;

using AppKit;
using Foundation;
using TestApplication1.src;

namespace TestApplication1
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();

            FakeOperation fakeOperation = new FakeOperation();

            bool pleaseGiveMeADeadlock = true;

            this.View.Window.Title = "LOADING...";
            var task = fakeOperation.FakeFunc(pleaseGiveMeADeadlock);

            // `Result` will just block synchronously until `FakeFunc`
            // completes (unlike `await` which asynchronously unwraps
            // the result of the Task).

            // We've essentially ensured that task.Result will block
            // on the UI thread because it inherits the current
            // SynchronizationContext from ViewDidAppear, which is
            // uses a UI SynchronizationContext.

            // A UI SynchronizationContext will only run tasks on a
            // single thread (the UI thread) at time.

            this.View.Window.Title = "LOADED " + task.Result.ToString();
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }
    }
}
