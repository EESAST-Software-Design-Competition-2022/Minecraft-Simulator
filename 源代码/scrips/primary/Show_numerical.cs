using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_numerical : MonoBehaviour
{
    public Text textshow1;
    public Text textshow2;
    public Text textshow3;
    public Text textshow4;
    public Text textshow5;
    public Text textshow6;
    public Text textshow7;
    int force0;
    int material0;
    int hungry0;
    float t1 = 0, t2 = 0, t3 = 0;

    // Update is called once per frame
    void Update()
    {
        t1 += Time.deltaTime;
        t2 += Time.deltaTime;
        t3 += Time.deltaTime;
        textshow1.text = ("£º"+numerical.force);
        textshow2.text = ("£º" + numerical.hungry);
        textshow3.text = ("£º" + numerical.material);
        if (numerical.force_ability != 0)
            textshow7.text = ("+ " + numerical.force_ability);
        else
            textshow7.text = ("");
        if (t1 > 2.5)
            if (numerical.force+numerical.force_ability - force0 != 0)
            {
                if (numerical.force+numerical.force_ability - force0 > 0)
                    textshow4.text = ("+ " + (numerical.force+numerical.force_ability - force0));
                else
                    textshow4.text = ("- " + (force0 - numerical.force-numerical.force_ability));
                t1 = 0;
            }
            else
                textshow4.text = ("");
        if (t2 > 2.5)
            if (numerical.hungry - hungry0 != 0)
            {
                if (numerical.hungry - hungry0 > 0)
                    textshow5.text = ("+ " + (numerical.hungry - hungry0));
                else
                    textshow5.text = ("- " + (hungry0- numerical.hungry));
                t2 = 0;
            }
            else
                textshow5.text = ("");
        if (t3 > 2.5)
            if (numerical.material - material0 != 0)
            {
                if (numerical.material- material0 > 0)
                    textshow6.text = ("+ " + (numerical.material - material0));
                else
                    textshow6.text = ("- " + (material0 - numerical.material));
                t3 = 0;
            }
            else
                textshow6.text = ("");
        force0 = numerical.force+numerical.force_ability;
        hungry0 = numerical.hungry;
        material0 = numerical.material;
    }
}
