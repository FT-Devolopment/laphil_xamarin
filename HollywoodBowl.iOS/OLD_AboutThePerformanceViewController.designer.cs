// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HollywoodBowl.iOS
{
    [Register ("OLD_AboutThePerformanceViewController")]
    partial class OLD_AboutThePerformanceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView Components { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView DescriptionTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SeriesButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SeriesView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Components != null) {
                Components.Dispose ();
                Components = null;
            }

            if (DescriptionTextView != null) {
                DescriptionTextView.Dispose ();
                DescriptionTextView = null;
            }

            if (SeriesButton != null) {
                SeriesButton.Dispose ();
                SeriesButton = null;
            }

            if (SeriesView != null) {
                SeriesView.Dispose ();
                SeriesView = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}