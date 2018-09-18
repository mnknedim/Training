package md51cdb23615910cea6d2b13d3e7ae834d2;


public class HtmlFormattedLabelRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.LabelRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Training.Droid.Renderer.HtmlFormattedLabelRenderer, Training.Android", HtmlFormattedLabelRenderer.class, __md_methods);
	}


	public HtmlFormattedLabelRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == HtmlFormattedLabelRenderer.class)
			mono.android.TypeManager.Activate ("Training.Droid.Renderer.HtmlFormattedLabelRenderer, Training.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public HtmlFormattedLabelRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == HtmlFormattedLabelRenderer.class)
			mono.android.TypeManager.Activate ("Training.Droid.Renderer.HtmlFormattedLabelRenderer, Training.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public HtmlFormattedLabelRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == HtmlFormattedLabelRenderer.class)
			mono.android.TypeManager.Activate ("Training.Droid.Renderer.HtmlFormattedLabelRenderer, Training.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

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
