using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class material : MonoBehaviour
{

    public Slider Material_slider;
    public Text Material_text;
    public GameObject success_picture;
    public GameObject fail_picture;
    public GameObject success_button;
    public GameObject fail_button;
    void Start()
    {
        success_picture.SetActive(false);
        fail_picture.SetActive(false);
        success_button.SetActive(false);
        fail_button.SetActive(false);
    }

    void Update()
    {
        int Material = (int)(Material_slider.value * 80);
        Material_text.text = Material.ToString();
    }
    public void close_success()
    {
        success_picture.SetActive(false);
        success_button.SetActive(false);
    }
    public void close_fail()
    {
        fail_picture.SetActive(false);
        fail_button.SetActive(false);
    }
    public void Fumo()
    {
        int Material = (int)(Material_slider.value * 80);
        if (Material <= numerical.material)
        {
            numerical.material -= Material;
            //写一下材料值=材料值减去Material；
            Material_slider.value = 0;
            int success = Random.Range(1, 81);
            if (Material >= success)
            {
                int p = Random.Range(1, 100);
                if (p % 3 == 1)
                {
                    numerical.force_ability += 15;
                    //武力值上升15；
                }
                else if (p % 3 == 2)
                {
                    numerical.force_ability += 30;
                    //武力值上升30；
                }
                else if (p % 3 == 0)
                {
                    numerical.force_ability += 45;
                    //武力值上升45;
                }
                success_picture.SetActive(true);
                success_button.SetActive(true);
            }
            else
            {
                fail_picture.SetActive(true);
                fail_button.SetActive(true);
            }
        }
    }
}
