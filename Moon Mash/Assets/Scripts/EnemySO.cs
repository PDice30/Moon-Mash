using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySO : ScriptableObject {

	public int enemyId = 0;
	public string enemyName = "Enemy Name";
	public Sprite enemySprite;
	public int enemyHealth = 1;
	public int enemyGoldValue = 1;

	public abstract void Initialize();
	public abstract void TriggerBehavior();

}
