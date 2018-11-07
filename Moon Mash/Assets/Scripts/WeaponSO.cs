using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSO : ScriptableObject {

	public int weaponId = 0;
	public string weaponName = "Weapon Name";
	public int weaponDamage = 1;
	public float weaponCooldown = 5.0f;

	public GameObject Object;

}
