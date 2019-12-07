using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTheSpawner : MonoBehaviour
{
    public static GameObject instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this.gameObject;
    }


}
