using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_button : MonoBehaviour
{
    bool happen;
    private void Start()
    {
        happen = false;
    }
    public void Choice1()
    {
        if (!happen)
        {
            numerical.choice = 1;
            happen = !happen;
        }
    }
    public void Choice2()
    {
        if (!happen)
        {
            numerical.choice = 2;
            happen = !happen;
        }
    }
}
