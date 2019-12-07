using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurePower : MonoBehaviour
{
    public static PurePower instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

}
