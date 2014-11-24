using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIDataBaseView : UIElement {


	List<zEvent> tEvents = null;
	List<string> tValues = null;
	//GUI VARS
	Vector2 vScrollPos = Vector2.zero;

	public override void Init()
	{
		MongoDBUtil.OpenConnection();
		MongoDBUtil.SetCollection();
		tEvents = MongoDBUtil.GetCollectionEntities<zEvent>(100);
		if (tEvents != null)
			tValues = EventUtil.GetValues(tEvents);
	}

	public override void GUIDisplay()
	{
		if (tValues == null)
			return;

		int iNumValues = EventUtil.NUMVALUES;

		float fBaseX = 5;
		float fBaseY = 5;
		float fH = 20;
		float fW = Screen.width / iNumValues;
		float fYPadding = 2;
		Rect tLabelRect = new Rect (fBaseX, fBaseY, fW, fH);

		int iListCount = tValues.Count;

		//Render Static Header

		for(int iEvent = 0; iEvent < iListCount; ++iEvent)
		{
			if(iEvent == iNumValues)
				vScrollPos = GUI.BeginScrollView (new Rect (0, tLabelRect.y + tLabelRect.height, Screen.width, Screen.height),
				                                  vScrollPos, new Rect (0, 0, Screen.width, (fH + fYPadding) * (iListCount+1) + fBaseY));

			string sValue = tValues[iEvent];
			int iColumn = iEvent % iNumValues;
			int iRow = iEvent / iNumValues;
			tLabelRect.x = iColumn * fW + fBaseX;
			tLabelRect.y = iRow * (fH + fYPadding) + fBaseY;
			GUI.Label(tLabelRect, sValue);
		}

		GUI.EndScrollView();
	}

	void RenderTableRow()
	{

	}
}
