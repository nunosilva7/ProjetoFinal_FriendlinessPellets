using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLvl : MonoBehaviour
{
    private FPSController fpsScript;
    
    
    
    private void Start()
    {
        fpsScript = GetComponent<FPSController>();
       

        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(fpsScript.count);
        Debug.Log("enter");
        if (other.CompareTag("End") &&  fpsScript.count==2)
        {
            if (SceneManager.GetActiveScene().name == "level1")
            {
                SceneManager.LoadScene("level2");
            }
            else if(SceneManager.GetActiveScene().name == "level2")
            {
                SceneManager.LoadScene("level3");
            }

            else if (SceneManager.GetActiveScene().name == "level3")
            {
                SceneManager.LoadScene("level4");
            }
            
        }
        else if (other.CompareTag("End") && fpsScript.count == 3)
        {
            if (SceneManager.GetActiveScene().name == "level4")
            {
                SceneManager.LoadScene("level5");
            }
            else if (SceneManager.GetActiveScene().name == "level5")
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("VictoryMenu");
            }
        }
       
    }
}
