using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigman_give : MonoBehaviour
{
    bool happen;
    private void Start()
    {
        happen = false;
    }
    public void click()
    {
        if (!happen)
            numerical.material -= 50;
        happen = true;
    }
}
