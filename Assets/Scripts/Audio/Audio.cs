using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace {
    
    public class Audio : Singleton<Audio> {
        public AudioSource source;

        public AudioClip[] backgtoundMusic;
        public AudioClip[] battleMusic;
        public AudioClip[] mainMenuMusic;
        
        public void StartBattleMusic() {
        
        }

        public int counterBG;
        public void StartBackgroundMusic(AudioClip clip) {
            source.clip = clip;
            source.Play();
            StartCoroutine(RepeatMusic(clip));
        }

        IEnumerator RepeatMusic(AudioClip clip) {
            yield return new WaitForSeconds(source.clip.length);
            counterBG++;
            if (counterBG >= backgtoundMusic.Length) {
                counterBG = 0;
            }
            StartBackgroundMusic(clip);
        }
    }
}