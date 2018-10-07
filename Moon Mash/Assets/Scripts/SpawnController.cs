using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	EnemySpawnData[] _data;

	// Use this for initialization
	void Start () {
		string path = "Assets/Scripts/EnemyDataInput.json";
		StreamReader reader = new StreamReader(path);
		var json = reader.ReadToEnd();
		reader.Close();
		string fixedJson = fixJson(json);

		_data = JsonHelper.FromJson<EnemySpawnData>(fixedJson);

		Debug.Log(  "sectorId: " + _data[0].sectorId + "\n" +
					"sectorName: " + _data[0].sectorName + "\n" +
					"planetId: " + _data[0].planetId + "\n" +
					"planetName: " + _data[0].planetName + "\n" +
					"round: " + _data[0].round + "\n" +
					"spawn: " + _data[0].spawn + "\n" +
					"enemyId: " + _data[0].enemyId + "\n" +
					"enemyTypeName: " + _data[0].enemyTypeName + "\n" +
					"enemyTypeId: " + _data[0].enemyTypeId + "\n" +
					"enemySubtypeName: " + _data[0].enemySubtypeName + "\n" +
					"enemySubtypeId: " + _data[0].enemySubtypeId + "\n" +
					"enemySpawnLocation: " + _data[0].enemySpawnLocation );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string fixJson(string value) {	
		value = "{\"Items\":" + value + "}";
		return value;
	}
}
