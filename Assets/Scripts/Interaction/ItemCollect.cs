using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollect : MonoBehaviour
{
    private int rings = 0;
    [SerializeField] private TextMeshProUGUI ringText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            Destroy(collision.gameObject);
            rings++;
            ringText.text = (int.Parse(ringText.text) + 1).ToString();
        }
    }
}
