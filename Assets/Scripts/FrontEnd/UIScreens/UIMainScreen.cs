using UnityEngine;
using System.Collections;

public class UIMainScreen : UIScreen
{
	public UIMainScreen(string sName): base(sName) {}

	UIArea tHeader = new UIArea();
	UIArea tMainArea = new UIArea();
	UIArea tFooter = new UIArea();

	UIScrollArea tScrollArea = new UIScrollArea();
	const int iNumEntries = 6;
	const int iNumEntriesOnScreen = 4;
    UIListEvent[] tEntries = new UIListEvent[iNumEntries];

	public override void Init ()
	{
		int iHeaderH = 60;
		int iFooterH = 60;

		AddElement(tMainArea, 0.5f, 0.5f, 1.0f, 1.0f);
		tMainArea.SetPixelOffset(0, 0, 0, -(iHeaderH+iFooterH));
		tMainArea.SetBackground(Color.grey);

		AddElement(tHeader, 0.5f, 1.0f, 1.0f, 0.0f);
		tHeader.SetPixelOffset(0, -iHeaderH/2, 0, iHeaderH);
		tHeader.SetBackground(ColourHelper.RED_MAIN);

		AddElement(tFooter, 0.5f, 0.0f, 1.0f, 0.0f);
		tFooter.SetPixelOffset(0, iFooterH/2, 0, iFooterH);
        tFooter.SetBackground(ColourHelper.RED_MAIN);
	
		tMainArea.AddChild (tScrollArea, 0.5f, 0.5f, 1.0f, 1.0f);

		float fEntryGap = 4.0f / tScrollArea.GetHeight();
		float fEntryHeight = 100.0f / tScrollArea.GetHeight();

		for(int iEntry = 0; iEntry < iNumEntries; ++iEntry)
		{
            tEntries[iEntry] = new UIListEvent();
            tEntries[iEntry].SetPixelOffset(0, 0, 0, 100.0f);
			tEntries[iEntry].Init ();       
			tScrollArea.AddChild(tEntries[iEntry], 0.5f, 
			                   1.0f - (iEntry * fEntryHeight + (iEntry+1) * fEntryGap + fEntryHeight/2),
                               1.0f - fEntryGap, 0);
		}

//		AddElement(tButton, 0.5f, 0.5f, 0.0f, 0.0f);
//		tButton.Init ();
//		tButton.SetSprites(new string[] {"20Corner"}, new string[] {"blank"}, null, 20);
//		tButton.SetPixelOffset(0, 0, 40, 40);
//		tButton.SetColour (ColourHelper.RED_MAIN);
	}

	public override void Update()
	{

	}

}
