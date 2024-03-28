using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        //activer notre menu pause / l'activer
        pauseMenuUI.SetActive(true);
        // arrêter le temps
        Time.timeScale = 0;
        gameIsPaused = true;
        // changer le statut du jeu
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        //activer notre menu pause / l'activer
        pauseMenuUI.SetActive(false);
        // arrêter le temps
        Time.timeScale = 1;
        gameIsPaused = false;
        // changer le statut du jeu
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);

    }
}