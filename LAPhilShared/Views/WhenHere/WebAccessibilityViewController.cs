using Foundation;
using System;
using UIKit;
using LAPhil.Application;
using LAPhil.Urls;
using LAPhil.Platform;


namespace LAPhil.iOS
{
    public partial class WebAccessibilityViewController : UIViewController
    {
        public static UIActivityIndicatorView activity = new UIActivityIndicatorView();
        LAPhilUrlService urls = ServiceContainer.Resolve<LAPhilUrlService>();

        public WebAccessibilityViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            activity = this.activityIndicator;
            this.NavigationItem.Title = "Accessibility";

            //Harish_A3 this.ConfigureDefaultBackButton();
            this.ConfigureDefaultBackButtonWebView(this.webViewSignUp);
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var urlsAccessibility = urls.WebAccessibility;
            Console.WriteLine("urlsAccessibility : {0}", urlsAccessibility);

            this.webViewSignUp.ScalesPageToFit = true;
            this.webViewSignUp.Delegate = new MyCustomWebViewDelegate();
            this.webViewSignUp.LoadRequest(new NSUrlRequest(new NSUrl(urlsAccessibility)));

        }


        public class MyCustomWebViewDelegate : UIWebViewDelegate
        {
            // get's never called:
            public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
            {
                Console.WriteLine("ShouldStartLoad");
                return true;
            }

            public override void LoadFailed(UIWebView webView, NSError error)
            {
                Console.WriteLine("LoadFailed");
            }


            public override void LoadingFinished(UIWebView webView)
            {
                activity.StopAnimating();
                activity.Hidden = true;
                Console.WriteLine("LoadingFinished");
            }


            public override void LoadStarted(UIWebView webView)
            {
                activity.StartAnimating();
                activity.Hidden = false;
                Console.WriteLine("LoadStarted");

                //Harish_A3
                var JavaScriptForRemoveHeader = "javascript:(function() { " +
                "var head = document.getElementsByTagName('header')[0];"
                + "head.parentNode.removeChild(head);" +
                    "})()";
                webView.EvaluateJavascript(JavaScriptForRemoveHeader);

                var JavaScriptForRemoveGrayColor = "javascript:(function(){"
                    + "document.getElementsByClassName('hero-background phatvideo-bg videobg-id-0')[0].style.height = '60%';"
                    + "})()";

                webView.EvaluateJavascript(JavaScriptForRemoveGrayColor);

            }

        }

    }
}