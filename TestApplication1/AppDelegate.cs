using AppKit;
using Foundation;
using TestApplication1.src;

namespace TestApplication1
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public async void DidFinishLaunching(NSNotification notification)
        {
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
