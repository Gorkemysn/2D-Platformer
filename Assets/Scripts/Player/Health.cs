using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;
    public HealthBar healthBar;
    public DeathMenu deathMenu;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else if (currentHealth <= 0)
        {
            if (!dead)
            {
                DieWithDelay();
            }
        }
    }
    private void DieWithDelay()
    {
        anim.SetTrigger("die");
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;

        Invoke("ShowDeathMenu", 2f); // �l�m men�s�n� 3 saniye sonra g�ster
    }

    private void ShowDeathMenu()
    {
        // �l�m men�s�n� g�ster
        if (deathMenu != null)
        {
            deathMenu.ShowDeathScreen();
        }
    }
}
