using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData {
	public int scrap; // Currency used to buy powerups, etc.
	public List<string> inventory; // string to be Item class/struct
	public List<WeaponSO> unlockedWeapons;
	public List<CompanionSO> unlockedCompanions;

	public WeaponSO firstWeaponSelected;
	public WeaponSO secondWeaponSelected;
	public WeaponSO thirdWeaponSelected;

	public CompanionSO firstCompanionSelected;
	public CompanionSO secondCompanionSelected;
	public CompanionSO thirdCompanionSelected;

	public List<int> planetsCompleted; // A list of planetIds maybe
	public List<int> sectorsCompleted; // a list of sectors completed maybe
}
