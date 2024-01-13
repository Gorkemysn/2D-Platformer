using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attack;
    [SerializeField] private float playerDamage;
    [SerializeField] private float playerDamage2;
    private Animator anim;
    AudioManager audioManager;
    private PlayerMovement playerMovement;
    private float timer = Mathf.Infinity;
    public float attackRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && timer > attack && playerMovement.canAttack())
        {
            Attack();
        }
        else if (Input.GetMouseButton(1) && timer > attack && playerMovement.canAttack())
        {
            Attack2();
        }

        timer += Time.deltaTime;
    }

    private void Attack()
    {
        audioManager.PlaySFX(audioManager.attack);
        anim.SetTrigger("attack");
        timer = 0;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(playerDamage);
        }
    }

    private void Attack2()
    {
        audioManager.PlaySFX(audioManager.attack);
        anim.SetTrigger("attack2");
        timer = 0;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(playerDamage2);
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
