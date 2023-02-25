using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace {
    
    public class Audio : MonoBehaviour {
        public AudioSource source;

        public AudioClip[] backgtoundMusic;
        public AudioClip[] battleMusic;


        public void Start() {
            StartBackgroundMusic();
        }

        public void StartBattleMusic() {
        
        }

        private int counterBG;
        public void StartBackgroundMusic() {
            source.clip = backgtoundMusic[counterBG];
            source.Play();
            StartCoroutine(RepeatMusic());
        }

        IEnumerator RepeatMusic() {
            yield return new WaitForSeconds(source.clip.length);
            counterBG++;
            if (counterBG >= backgtoundMusic.Length) {
                counterBG = 0;
            }
            StartBackgroundMusic();
        }
    }
}