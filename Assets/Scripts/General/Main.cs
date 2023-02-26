using System;
using System.Collections;
using General;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Main : Singleton<Main> {
	public int firstSceneID;
	
	public MainCharacter character;
	public SettingsAsset settings;

	public AudioSource spellCastSource;
	public AudioClip gameOverSound;

	public PlayerInfo playerInfo;
	public static Action OnChangeSpell;
	public static Action OnChangeMana;
	public static Action OnChangeHp;

	protected override void Awake() {
		base.Awake();
		settings.LoadFromFile();
		playerInfo = settings.s.player;
		if (playerInfo.CurrentSpells.Length == 0) {
			SetBaseSpells();
		}
		if (settings.s.isStartGame) {
			
		}
		
		SceneManager.LoadScene(settings.s.currentSceneId);
		StartCoroutine(PermanentResp());
	}
	
	private WaitForSeconds sec = new WaitForSeconds(1);
	IEnumerator PermanentResp() {
		while (true) {
			yield return sec;
			if (playerInfo.currentHP < playerInfo.maxHp)
				playerInfo.currentHP += 1;
			if (playerInfo.currentMP < playerInfo.maxMP)
				playerInfo.currentMP += 1;
		}
	}

	public void minusHP(float value) {
		playerInfo.currentHP  = Mathf.Clamp(playerInfo.currentHP - value, 0, playerInfo.maxHp);
		OnChangeHp?.Invoke();
		if (playerInfo.currentHP == 0) {
			if (isDeath) return;
			Death();
		}
	}
	
	public void plusHP(float value) {
		playerInfo.currentHP  = Mathf.Clamp(playerInfo.currentHP + value, 0, playerInfo.maxHp);
	}

	public void SetBaseSpells() {
		playerInfo.CurrentSpells = new Spell[4];
		settings.s.currentSpellId = settings.s.currentSpellId >= 4 ? settings.s.currentSpellId - 4
																	: settings.s.currentSpellId;
		for (int i = settings.s.currentSpellId; i < playerInfo.CurrentSpells.Length; i++) {
			playerInfo.CurrentSpells[i] = settings.s.spells[i];
			settings.s.currentSpellId = playerInfo.CurrentSpells[i].id;
			settings.s.currentSpellId++;
		}
	}

	public void ChangeCurrentSpell(int _id, Spell spell) {
		playerInfo.CurrentSpells[_id] = spell;
		OnChangeSpell?.Invoke();
	}
	
	public void ChangeMP(float value) {
		playerInfo.currentMP= Mathf.Clamp(playerInfo.currentMP - value, 0, playerInfo.maxMP);
		OnChangeMana?.Invoke();
	}
	
	public void LevelUp() {
		playerInfo.level += 1;
	}

	public bool isDeath;
	public void Death() {
		isDeath = true;
		character.animator.SetTrigger("Death");
		spellCastSource.PlayOneShot(gameOverSound);
		CanvasMain.instance.OpenDeadthPanel();
	}

	//start new game
	public void StartNewGame() {
		isDeath = false;
		SetBaseSpells();
		playerInfo.currentHP = playerInfo.maxHp;
		playerInfo.currentMP = playerInfo.maxMP;
		CanvasMain.instance.CloseAllWindow();
		SceneManager.LoadScene(1);
	}

	public void PlayCastSound(Spell spell) {
		if (spell.audioClip.Length == 0) return;
		spellCastSource.PlayOneShot(spell.audioClip[Random.Range(0, spell.audioClip.Length - 1)]);
	}

	private void OnApplicationQuit() {
		settings.s.player = playerInfo;
		settings.SaveToFile();
	}
}

