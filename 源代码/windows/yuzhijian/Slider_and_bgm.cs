using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_and_bgm : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound;
    public Slider bgm;


    // Update is called once per frame
    void Update()
    {
        sound.volume = bgm.value;
    }
}
