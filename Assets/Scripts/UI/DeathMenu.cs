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
        Time.timeScale = 1f; // Oyun zamanýný duraklat
        deathScreenUI.SetActive(true); // Ölüm ekranýný göster
    }

    public void HideDeathScreen()
    {
        Time.timeScale = 1f; // Oyun zamanýný devam ettir
        deathScreenUI.SetActive(false); // Ölüm ekranýný kapat
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyun zamanýný devam ettir
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükle
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f; // Oyun zamanýný devam ettir
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine geri dön
    }
}
