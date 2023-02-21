using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : Singleton<Main> {

	public float playerHP;
	public float playerMP;

	public float maxHP;
	public float maxMP;

	public int level;

	public void ChangeHP(float value) {
		playerHP = Mathf.Clamp(playerHP - value, 0, maxHP);
	}
	
	public void ChangeMP(float value) {
		playerMP = Mathf.Clamp(playerMP - value, 0, maxMP);
	}
	
	public void LevelUp() {
		level += 1;
	}

	public void StartNewGame() {
		
	}
}

