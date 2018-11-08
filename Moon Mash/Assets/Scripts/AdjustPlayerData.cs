using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPlayerData : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button(new Rect(10, 100, 100, 30), "Scrap Up")) {
			GameController.gameController.playerScrap += 10;
		}
		if (GUI.Button(new Rect(10, 140, 100, 30), "Scrap Down")) {
			GameController.gameController.playerScrap -= 10;
		}

		if (GUI.Button(new Rect(10, 220, 100, 30), "Save")) {
			GameController.gameController.SavePlayerData();
		}
		if (GUI.Button(new Rect(10, 260, 100, 30), "Load")) {
			GameController.gameController.LoadPlayerData();
		}
	}
}
