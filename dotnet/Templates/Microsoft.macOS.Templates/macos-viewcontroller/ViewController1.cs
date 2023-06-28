using ObjCRuntime;

namespace macOSApp1;

public partial class ViewController1 : NSViewController {
	public ViewController1 () : base (nameof (ViewController1), null)
	{
	}

	protected ViewController1 (NativeHandle handle) : base (handle)
	{
		// This constructor is required if the view controller is loaded from a xib or a storyboard.
		// Do not put any initialization here, use ViewDidLoad instead.
	}

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		// Perform any additional setup after loading the view
		View.WantsLayer = true;
		View.Layer!.BackgroundColor = NSColor.Blue.CGColor;
	}
}
