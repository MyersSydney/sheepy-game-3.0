using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public bool endGame;
    public int wave = 0;

    
   
    [SerializeField]
    public bool inGame = false;
    private void Awake()
    {
        MakeSingleton();
    }
    private void Update()
    {

    }
    private void MakeSingleton() { 
        if(instance != null){
            Destroy(gameObject);

    }
        else{
           instance = this;
            DontDestroyOnLoad (gameObject);
}
}
    public void StartWave()
    {
        ThisTheSpawner.instance.gameObject.GetComponent<Spawners>().updateTheNumWolves();
        ThisTheSpawner.instance.gameObject.GetComponent<Spawners>().SpawnAWolf();

    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
        Debug.Log("gameover");
    }
        }

