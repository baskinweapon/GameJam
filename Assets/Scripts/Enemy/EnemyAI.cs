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

    public Image healthBar;
    private IAstarAI ai;

    public Spell spell;


    private void Start() {
        ai = GetComponent<IAstarAI>();
        if (ai != null) ai.onSearchPath += LateUpdate;
        
        InvokeRepeating(nameof(GetTarget),0, 0.3f);
    }

    public void LateUpdate() {
        if (attacking) return;
        if (ai != null && target != (Vector2)ai.destination) ai.destination = target;
    }

    private bool attacking;
    private void GetTarget() {
        attacking = false;
        var distance = Vector2.Distance(Main.instance.character.transform.position, transform.position);
        if (distance <= startMovingDistance) {
            target = transform.position + new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        } if (distance <= chaseDistance) {
            target = Main.instance.character.transform.position;
        }

        if (distance <= startAttack) {
            ai.destination = transform.position;
            target = ai.destination;
            attacking = true;
            Attack();
        }
    }

    public void Attack() {
        GetComponent<EnemySpellBase>().StartAttack();
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
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        if (ai != null) ai.onSearchPath -= LateUpdate;
    }
}

