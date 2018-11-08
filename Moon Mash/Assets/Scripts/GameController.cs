using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// This will actually be created in the Pre-load scene:
// It will determine what planet the player is on and spawn that planet
// It will then transition to the menu screen
// If the player hits play from there, they will immediately begin
public class GameController : MonoBehaviour {

	public static GameController gameController;
	
	public int playerScrap; // For testing purposes, to be moved to player controller

	void Awake () {
		if (gameController == null) {
			DontDestroyOnLoad(gameObject);
			gameController = this;
		} else if (gameController != this) {
			Destroy(gameObject);
		}
	}
	void Start () {
		
	}
	
	void Update () {
		
	}

	// For Testing/Debugging, will be canvas
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 30), "Scrap: " + playerScrap);
	}

	// Will check for existing data when complete
	public void SavePlayerData() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

		PlayerData data = new PlayerData();
		data.scrap = playerScrap;

		bf.Serialize(file, data);
		file.Close();
	}

	public void LoadPlayerData() {
		if (File.Exists(Application.persistentDataPath + "/playerData.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();

			playerScrap = data.scrap;
		}
	}
}
