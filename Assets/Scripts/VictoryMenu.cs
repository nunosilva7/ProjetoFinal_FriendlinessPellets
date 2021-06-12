using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{

    [SerializeField] AudioSource menuBtn;
    [SerializeField] AudioSource ambience;

    // Start is called before the first frame update
    void Start()
    {
        ambience.Play();
    }
    public void MouseHovering()
    {
        menuBtn.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
