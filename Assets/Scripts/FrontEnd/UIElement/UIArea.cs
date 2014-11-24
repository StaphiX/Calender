using UnityEngine;
using System.Collections;

public class UIArea : UIElement 
{
	FSprite tBackground;

	public void SetBackground(Color tBackgroundColor)
	{
        if (tBackground == null)
        {
            tBackground = new FSprite("blank");
            AddSprite(tBackground);
        }

		tBackground.color = tBackgroundColor;
		tBackground.SetDimensions (GetRect ().x, GetRect ().y, GetRect ().width, GetRect ().height);
	}

	public override void Resize()
	{
		if (tBackground != null)
			tBackground.SetDimensions (GetRect ().x, GetRect ().y, GetRect ().width, GetRect ().height);
		base.Resize ();
	}

}
