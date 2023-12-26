using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float destroyDelay;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else if (currentHealth <= 0)
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<EnemyDamage>().enabled = false;
                dead = true;
            }
            StartCoroutine(DestroyAfterDelay());
        }
    }
    IEnumerator DestroyAfterDelay()
    {
        // Belirtilen süre kadar bekleyip sonra düþmaný yok et
        yield return new WaitForSeconds(destroyDelay);

        // Ölüm animasyonu ve beklenen süre tamamlandýktan sonra düþmaný yok et
        Destroy(gameObject);
    }
}

