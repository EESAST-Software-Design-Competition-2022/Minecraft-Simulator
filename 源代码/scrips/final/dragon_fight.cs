using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_fight : MonoBehaviour
{
    private void Start()
    {
        if (numerical.fight(500))
            numerical.win = 1;
    }
}
