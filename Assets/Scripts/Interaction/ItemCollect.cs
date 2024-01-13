using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollect : MonoBehaviour
{
    private int rings = 0;
    [SerializeField] private TextMeshProUGUI ringText;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            audioManager.PlaySFX(audioManager.item);
            Destroy(collision.gameObject);
            rings++;
            ringText.text = (int.Parse(ringText.text) + 1).ToString();
        }
    }
}
