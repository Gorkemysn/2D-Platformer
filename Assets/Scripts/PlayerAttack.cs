using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attack;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float timer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
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
        anim.SetTrigger("attack");
        timer = 0;
    }
    private void Attack2()
    {
        anim.SetTrigger("attack2");
        timer = 0;
    }
}
