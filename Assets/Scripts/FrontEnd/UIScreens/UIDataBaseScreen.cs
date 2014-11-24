using UnityEngine;
using System.Collections;

public class UIDataBaseScreen : UIScreen 
{
	public UIDataBaseScreen(string sName): base(sName) {}

	UIDataBaseView tView = new UIDataBaseView();

	public override void Init()
	{
		tView.Init();
	}

	public override void GUIDisplay()
	{
		tView.GUIDisplay();
	}

}
