// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ARLingo
{
    [Register ("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        UIKit.UISwitch DragOnInfinitePlanesSwitch { get; set; }


        [Outlet]
        UIKit.UISwitch ScaleWithPinchGestureSwitch { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DragOnInfinitePlanesSwitch != null) {
                DragOnInfinitePlanesSwitch.Dispose ();
                DragOnInfinitePlanesSwitch = null;
            }

            if (ScaleWithPinchGestureSwitch != null) {
                ScaleWithPinchGestureSwitch.Dispose ();
                ScaleWithPinchGestureSwitch = null;
            }
        }
    }
}