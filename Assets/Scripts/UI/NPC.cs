using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public string[] dialogLines; // NPC'nin diyalog satýrlarý
    public GameObject dialogBox; // Diyalog kutusu prefabý
    private Vector3 offset = new Vector3(500, 300, 0);
    public GameObject interactIcon;
    private Vector3 offset2 = new Vector3(470, 155, 0);
    public TextMeshProUGUI dialogText; // Diyalog metni
    private int currentLine = 0; // Mevcut diyalog satýrý
    private bool inRange = false; // Etkileþim menzili
    private bool dialogActive = false; // Diyalog durumu

    void Start()
    {
        dialogBox.SetActive(false); // Diyalog kutusunu baþlangýçta gizle
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

        if (inRange && Input.GetKeyDown(KeyCode.E)) // E tuþu ile etkileþime geç
        {
            dialogActive = true;
            dialogBox.SetActive(true);
            dialogText.gameObject.SetActive(true);
            ShowNextDialog();
        }

        if (dialogActive && Input.GetMouseButtonDown(0)) // Sol týk ile diyalog satýrlarýný ilerlet
        {
            ShowNextDialog();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Karakter NPC'nin etkileþim menziline girdiðinde
        {
            inRange = true;
            interactIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Karakter NPC'nin etkileþim menzilinden çýktýðýnda
        {
            inRange = false;
            dialogActive = false;
            dialogBox.SetActive(false); // Diyalog kutusunu gizle
            currentLine = 0; // Diyalog satýrýný sýfýrla (baþtan baþla)
            interactIcon.SetActive(false);
        }
    }

    void ShowNextDialog()
    {
        if (dialogActive && currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine]; // Diyalog metnini güncelle
            currentLine++; // Bir sonraki diyalog satýrýna geç

            if (currentLine == dialogLines.Length)
            {
                StartCoroutine(CloseDialog()); // Diyalog bittiðinde kutuyu kapat
            }
        }
    }

    IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(3f); // Bir saniye bekleyerek
        dialogBox.SetActive(false); // Diyalog kutusunu gizle
        currentLine = 0; // Diyalog satýrýný sýfýrla (baþtan baþla)
    }
}