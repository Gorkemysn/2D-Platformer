using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathScreenUI;

    private void Start()
    {
        HideDeathScreen();
    }

    public void ShowDeathScreen()
    {
        Time.timeScale = 1f; // Oyun zaman�n� duraklat
        deathScreenUI.SetActive(true); // �l�m ekran�n� g�ster
    }

    public void HideDeathScreen()
    {
        Time.timeScale = 1f; // Oyun zaman�n� devam ettir
        deathScreenUI.SetActive(false); // �l�m ekran�n� kapat
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyun zaman�n� devam ettir
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden y�kle
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f; // Oyun zaman�n� devam ettir
        SceneManager.LoadScene("MainMenu"); // Ana men� sahnesine geri d�n
    }
}
