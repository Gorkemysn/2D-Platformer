using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Çarptý");
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("Hasar verdi");
        }
    }
}
