using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_of_bgm : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bgm;
    public GameObject background;
    public GameObject button0;
    public GameObject image;
    void Start()
    {
        bgm.SetActive(false);
        background.SetActive(false);
        button0.SetActive(false);
        image.SetActive(false);
    }
    public void Bgmactive()
    {
        bgm.SetActive(true);
        background.SetActive(true);
        button0.SetActive(true);
        image.SetActive(true);
    }
    public void Bgmsleep()
    {
        bgm.SetActive(false);
        background.SetActive(false);
        button0.SetActive(false);
        image.SetActive(false);
    }
}
