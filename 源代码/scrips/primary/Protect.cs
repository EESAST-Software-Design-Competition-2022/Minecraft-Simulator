using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect : MonoBehaviour
{
    public GameObject object1;
    void Start()
    {
        DontDestroyOnLoad(object1);
    }
}
