using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_develop : MonoBehaviour
{
    bool happen;
    private void Start()
    {
        happen = false;
    }
    public void construct()
    {
        if (!happen)
        {
            numerical.material += 6 + numerical.random(0, 4);
            numerical.hungry += 10 + numerical.random(0, 10);
            if (numerical.force > 0)
                numerical.force -= numerical.random(0,10);
            if (numerical.random(1, 10) <= 2 && numerical.a != 2)
                numerical.monster = 1;
            numerical.choice = 0;
            numerical.win = 0;
            numerical.succeed = 0;
            happen = !happen;
        }
    }
    public void explore()
    {
        if (!happen)
        {
            if (numerical.hungry >= 3)
                numerical.hungry -= 3;
            else
                numerical.hungry = 0;
            if (numerical.random(1, 10) <= 2 && numerical.a != 2)
                numerical.monster = 1;
            numerical.choice = 0;
            numerical.win = 0;
            numerical.succeed = 0;
            happen = !happen;
        }
    }
}
