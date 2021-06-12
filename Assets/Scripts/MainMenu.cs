using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource menuBtn;
    [SerializeField] AudioSource ambience;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject menuPanel;
    
    

    private void Start()
    {
        ambience.Play();
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);

       
    }

    public void StartGame()
    {

        Cursor.visible = false;
        SceneManager.LoadScene("level1");
        

    }

    

    public void MouseHovering()
    {
        menuBtn.Play();
    }

    

    public void SeeCredits()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Return()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
