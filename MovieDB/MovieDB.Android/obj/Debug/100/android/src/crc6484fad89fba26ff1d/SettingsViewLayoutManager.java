package crc6484fad89fba26ff1d;


public class SettingsViewLayoutManager
	extends androidx.recyclerview.widget.LinearLayoutManager
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDecoratedMeasuredHeight:(Landroid/view/View;)I:GetGetDecoratedMeasuredHeight_Landroid_view_View_Handler\n" +
			"n_onLayoutCompleted:(Landroidx/recyclerview/widget/RecyclerView$State;)V:GetOnLayoutCompleted_Landroidx_recyclerview_widget_RecyclerView_State_Handler\n" +
			"";
		mono.android.Runtime.register ("AiForms.Renderers.Droid.SettingsViewLayoutManager, SettingsView.Droid", SettingsViewLayoutManager.class, __md_methods);
	}


	public SettingsViewLayoutManager (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SettingsViewLayoutManager.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SettingsViewLayoutManager, SettingsView.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SettingsViewLayoutManager (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SettingsViewLayoutManager.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SettingsViewLayoutManager, SettingsView.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public SettingsViewLayoutManager (android.content.Context p0, int p1, boolean p2)
	{
		super (p0, p1, p2);
		if (getClass () == SettingsViewLayoutManager.class)
			mono.android.TypeManager.Activate ("AiForms.Renderers.Droid.SettingsViewLayoutManager, SettingsView.Droid", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public int getDecoratedMeasuredHeight (android.view.View p0)
	{
		return n_getDecoratedMeasuredHeight (p0);
	}

	private native int n_getDecoratedMeasuredHeight (android.view.View p0);


	public void onLayoutCompleted (androidx.recyclerview.widget.RecyclerView.State p0)
	{
		n_onLayoutCompleted (p0);
	}

	private native void n_onLayoutCompleted (androidx.recyclerview.widget.RecyclerView.State p0);

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
