using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    float timer = 30;
    // Start is called before the first frame update
    private void Start()
    {
        text = gameObject.GetComponent<TMP_Text>(); 
    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            timer = 30;
            getWave();
            GameManager.instance.StartWave();
        }
    }
    public void getWave()
    {
        GameManager.instance.wave++;
        text.SetText("Wave:{0}", GameManager.instance.wave);
    }

}  