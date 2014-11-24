using UnityEngine;
using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;

/*Structure Of System

zEvents are the events created by users and businesses
zBusniess is a type of user specifically for a business
zUser is a basic user

*/

public class zEvent  
{
	public ObjectId Id { get; set; }
	public ObjectId UserID { get; set; }
	public DateTime Date { get; set; }
	public int DurationMins { get; set; }
	public string EventName { get; set; }
	public string Image { get; set; }
	public zLocation Location  { get; set; }
	public string Description  { get; set; }
}

public class zLocation
{
	public double Latitude  { get; set; }
	public double Longitude  { get; set; }
}

public class EventUtil
{
	public static int NUMVALUES = 8;

	private static List<string> tList;
	private static void CreateList()
	{
		if (tList == null)
			tList = new List<string> ();
		else
			tList.Clear ();

		//Add Columns
		tList.Add ("Id");
		tList.Add ("UserID");
		tList.Add ("Date");
		tList.Add ("DurationMins");
		tList.Add ("EventName");
		tList.Add ("Image");
		tList.Add ("Location");
		tList.Add ("Description");
	}

	private static void AddListRow(zEvent tEvent)
	{
		tList.Add (tEvent.Id.ToString());
		tList.Add (tEvent.UserID.ToString());
		tList.Add (tEvent.Date.ToString());
		tList.Add (tEvent.DurationMins.ToString());
		tList.Add (tEvent.EventName.Length > 0 ? tEvent.EventName : "NULL");
		tList.Add (tEvent.Image != null ? tEvent.Image : "NULL");
		tList.Add (tEvent.Location != null ? tEvent.Location.Latitude.ToString("0.000") + "," + tEvent.Location.Longitude.ToString("0.000") : "NULL");
		tList.Add (tEvent.Description.Length > 0 ? tEvent.Description : "NULL");
	}

	public static List<string> GetValues(List<zEvent> tEvents)
	{
		if (tList == null) 
		{
			CreateList ();
			foreach (zEvent tEvent in tEvents) 
			{
				AddListRow (tEvent);
			}
		} 
		return tList;
	}

	public static zEvent CreateRandomEvent()
	{
		return new zEvent
		{
			UserID = ObjectId.GenerateNewId(),
			Date = DateTime.Now.AddDays(Random.Range(0, 1000)),
			EventName = "Test Event" + Random.Range(0, 1000000).ToString(),
			Image = null,
			Location = new zLocation
			{
				Latitude = 51.748436,
				Longitude = -1.239628,
			},
			DurationMins = Random.Range(100, 2000),
			Description = LorumIpsum

		};
	}

public static string LorumIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus in scelerisque nunc, sit amet mattis ipsum. Cras mollis eu purus ut rutrum. Pellentesque sit amet eros libero. Phasellus diam quam, porta eget purus in, auctor varius eros. Fusce vestibulum erat metus, at pellentesque mauris euismod ornare. Vivamus hendrerit lobortis pellentesque. Nulla porttitor nisl tortor, at tincidunt justo pulvinar sit amet.";
}
