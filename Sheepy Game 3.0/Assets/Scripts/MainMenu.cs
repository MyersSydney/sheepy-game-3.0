using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        GameManager.instance.inGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void replay()
    {
        SceneManager.LoadScene(0);
    }
    public void end()
    {
        Application.Quit();
    }
}
