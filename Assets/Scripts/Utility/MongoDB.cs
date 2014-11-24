using UnityEngine;
using Random = UnityEngine.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

public class Entity
{
	public ObjectId Id { get; set; }
	public string Name { get; set; }
}

public class MongoDBUtil
{
	static string sDatabaseName = "test";
	static MongoClient tClient = null;
	static MongoCollection tCollection = null;
	static MongoDatabase tDatabase = null;

	public static void OpenConnection()
	{
		string sConnectionString = "mongodb://localhost";
		tClient = new MongoClient(sConnectionString);
		MongoServer tServer = tClient.GetServer();
		tDatabase = tServer.GetDatabase(sDatabaseName);
	}

	public static List<T> GetCollectionEntities<T>(int iLimit)
	{
		if (tCollection == null)
			return null;

		MongoCursor<T> tCursor = tCollection.FindAllAs<T>();
		if(iLimit != -1)
			tCursor.Limit = iLimit;
		List<T> tList = tCursor.ToList();

		return tList;
	}

	public static void SetCollection()
	{
		tCollection = tDatabase.GetCollection<zEvent>("events");
	}

	public static void InsertRandomEvents()
	{
		tCollection = tDatabase.GetCollection<zEvent>("events");

		for (int iEvent = 0; iEvent < Random.Range(100, 200); ++iEvent) 
		{
			zEvent tEvent = EventUtil.CreateRandomEvent ();
			tCollection.Insert (tEvent);
		}

//		ObjectId tID = tEntity.Id;
//		
//		IMongoQuery tQuery = Query<Entity>.EQ(e => e.Id, tID);
//		tEntity = tCollection.FindOneAs<Entity>(tQuery);
//		
//		tEntity.Name = "Dick";
//		tCollection.Save(tEntity);
//		
//		IMongoUpdate tUpdate = Update<Entity>.Set(e => e.Name, "Harry");
//		tCollection.Update(tQuery, tUpdate);
	}

}
