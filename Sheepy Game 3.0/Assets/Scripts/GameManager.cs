using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public bool endGame;
    public int wave = 0;

    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    float timer = 30;
    [SerializeField]
    public bool inGame = false;
    private void Awake()
    {
        MakeSingleton();
    }
    private void Update()
    {
        if(inGame)
        {
            timer = timer - Time.deltaTime;
            if(timer <= 0)
            {
                timer = 30;
                StartWave();
            }
        }
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
        wave++;
            text.SetText("Wave:{0}", wave);


    }
    public void GameOver()
    {
        Debug.Log("gameover");
    }
        }

