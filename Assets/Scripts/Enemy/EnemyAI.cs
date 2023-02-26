using System.Collections;
using Pathfinding;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum EnemyState {
    Patrol,
    Attack,
    Sleep
}

public class EnemyAI : MonoBehaviour {
    public float health;
    public float maxHealth;
    public float chaseDistance;
    public float startMovingDistance;
    public float startAttack;

    public GameObject dropItem;
    public bool staticBody;

    public AudioSource source;
    public AudioClip[] attackClips;
    public AudioClip[] deadthClip;

    private AudioSource _audioSource;

    public Image healthBar;
    private IAstarAI ai;

    public Spell spell;
    public float cooldownDuration = 1f;


    private void Start() {
        ai = GetComponent<IAstarAI>();
        if (ai != null) ai.onSearchPath += LateUpdate;

        _audioSource = GetComponent<AudioSource>();
        
        InvokeRepeating(nameof(GetTarget),0, 0.5f);
    }

    public void LateUpdate() {
        if (attacking || staticBody) {
            ai.canMove = false;
            return;
        }

        ai.canMove = true;
        if (ai != null && target != (Vector2)ai.destination) ai.destination = target;
    }

    private bool attacking;
    private void GetTarget() {
        var distance = Vector2.Distance(Main.instance.character.transform.position, transform.position);
        if (distance <= startMovingDistance) {
            target = transform.position + new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        } if (distance <= chaseDistance) {
            target = Main.instance.character.transform.position;
        }

        if (distance <= startAttack && !attacking) {
            ai.destination = transform.position;
            target = ai.destination;
            attacking = true;
            Attack();
        }
    }

    public void Attack() {
        if (attackClips.Length == 1) {
            PlaySound(attackClips[0]);    
        }
        else {
            PlaySound(attackClips[Random.Range(0, attackClips.Length)]);
        }
        GetComponent<EnemySpellBase>().StartAttack();
        StartCoroutine(AttackProcess());
    }

    IEnumerator AttackProcess() {
        yield return new WaitForSeconds(cooldownDuration);
        attacking = false;
    }

    private Vector2 target;
    public void ChangeHealth(float _value) {
        health = Mathf.Clamp(health - _value, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
        if (health == 0) {
            Death();
        }
    }

    public void PlaySound(AudioClip clip) {
        _audioSource.PlayOneShot(clip);
    }
    
    public void Death() {
        PlaySound(deadthClip[Random.Range(0, deadthClip.Length)]);
        Debug.Log("I death");
        if (dropItem) {
            var r = Random.Range(0, 100);
            if (r > 50) {
                var drop = Instantiate(dropItem);
                drop.transform.position = transform.position;
            }
        }
        StopAllCoroutines();
        transform.Rotate(0, 0, 90);
        Destroy(gameObject, 1f);
    }

    private void OnDisable() {
        if (ai != null) ai.onSearchPath -= LateUpdate;
    }
}

