package md5beba9d0b3b6be25bd845487d87ff0070;


public class BookReadingActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Training.Droid.Activities.BookReadingActivity, Training.Android", BookReadingActivity.class, __md_methods);
	}


	public BookReadingActivity ()
	{
		super ();
		if (getClass () == BookReadingActivity.class)
			mono.android.TypeManager.Activate ("Training.Droid.Activities.BookReadingActivity, Training.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
