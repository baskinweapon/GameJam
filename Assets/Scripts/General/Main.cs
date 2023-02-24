using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : Singleton<Main> {

	public int firstSceneID;
	
	public MainCharacter character;
	
	public float playerHP;
	public float playerMP;

	public float maxHP;
	public float maxMP;
	
	public int level;
	
	private void Start() {
		SceneManager.LoadScene(firstSceneID);
	}

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

