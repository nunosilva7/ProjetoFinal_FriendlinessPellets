using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;

     static bool StopGame = true;
     public static bool gameOver = false;
     

    [SerializeField] GameObject gameOverPanel;
    




    // Update is called once per frame
    void Update()
    {
        
            if (!gameOver)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {


                    if (StopGame)
                    {
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        PauseGame();
                    }
                    else
                    {
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        PlayGame();
                    }
                }
            }
            else
            {
                GameOver();
            }
        
        
       
       


    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        StopGame = false;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        StopGame = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        
    }
    public void Restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   

    
}

