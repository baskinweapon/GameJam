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

	public void Start() {
		level = 0;
	}

	public void LevelUp() {
		level += 1;
	}

	public void StartNewGame() {
		
	}
}