using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public string[] dialogLines; // NPC'nin diyalog sat�rlar�
    public GameObject dialogBox; // Diyalog kutusu prefab�
    private Vector3 offset = new Vector3(500, 300, 0);
    public GameObject interactIcon;
    private Vector3 offset2 = new Vector3(470, 155, 0);
    public TextMeshProUGUI dialogText; // Diyalog metni
    private int currentLine = 0; // Mevcut diyalog sat�r�
    private bool inRange = false; // Etkile�im menzili
    private bool dialogActive = false; // Diyalog durumu

    void Start()
    {
        dialogBox.SetActive(false); // Diyalog kutusunu ba�lang��ta gizle
        dialogText.gameObject.SetActive(false);
        interactIcon.SetActive(false);
    }

    void Update()
    {
        if (dialogBox.activeSelf)
        {
            Vector3 dialogPos = transform.position + offset;
            dialogBox.transform.position = dialogPos;
        }
        if (interactIcon.activeSelf)
        {
            Vector3 dialogPos = transform.position + offset2;
            interactIcon.transform.position = dialogPos;
        }

        if (inRange && Input.GetKeyDown(KeyCode.E)) // E tu�u ile etkile�ime ge�
        {
            dialogActive = true;
            dialogBox.SetActive(true);
            dialogText.gameObject.SetActive(true);
            ShowNextDialog();
        }

        if (dialogActive && Input.GetMouseButtonDown(0)) // Sol t�k ile diyalog sat�rlar�n� ilerlet
        {
            ShowNextDialog();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Karakter NPC'nin etkile�im menziline girdi�inde
        {
            inRange = true;
            interactIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Karakter NPC'nin etkile�im menzilinden ��kt���nda
        {
            inRange = false;
            dialogActive = false;
            dialogBox.SetActive(false); // Diyalog kutusunu gizle
            currentLine = 0; // Diyalog sat�r�n� s�f�rla (ba�tan ba�la)
            interactIcon.SetActive(false);
        }
    }

    void ShowNextDialog()
    {
        if (dialogActive && currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine]; // Diyalog metnini g�ncelle
            currentLine++; // Bir sonraki diyalog sat�r�na ge�

            if (currentLine == dialogLines.Length)
            {
                StartCoroutine(CloseDialog()); // Diyalog bitti�inde kutuyu kapat
            }
        }
    }

    IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(3f); // Bir saniye bekleyerek
        dialogBox.SetActive(false); // Diyalog kutusunu gizle
        currentLine = 0; // Diyalog sat�r�n� s�f�rla (ba�tan ba�la)
    }
}