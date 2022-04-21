using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Help_Text : MonoBehaviour
{
    public GameObject button_of_text;
    public GameObject text_help;
    void Start()
    {
        button_of_text.SetActive(false);
        text_help.SetActive(false);
    }
    // Start is called before the first frame update
   
    public void setactive()
    {
        button_of_text.SetActive(true);
        text_help.SetActive(true);
    }
    public void setsleep()
    {
        button_of_text.SetActive(false);
        text_help.SetActive(false);
    }
}
