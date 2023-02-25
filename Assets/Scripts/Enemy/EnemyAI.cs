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

    public Image healthBar;
    private IAstarAI ai;

    public Spell spell;
    public float cooldownDuration = 1f;


    private void Start() {
        ai = GetComponent<IAstarAI>();
        if (ai != null) ai.onSearchPath += LateUpdate;
        
        InvokeRepeating(nameof(GetTarget),0, 0.5f);
    }

    public void LateUpdate() {
        if (attacking) {
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
    
    public void Death() {
        Debug.Log("I death");
        if (dropItem) {
            var drop = Instantiate(dropItem);
            drop.transform.position = transform.position;
        }
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void OnDisable() {
        if (ai != null) ai.onSearchPath -= LateUpdate;
    }
}

