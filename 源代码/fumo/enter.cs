using UnityEngine;

public class enter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fumo;
    public GameObject Fumo_button;
    void Start()
    {
        Fumo.SetActive(false);
    }
    public void Setactive()
    {
        Fumo.SetActive(true);
        Fumo_button.SetActive(false);
    }
    public void Setsleep()
    {
        Fumo.SetActive(false);
        Fumo_button.SetActive(true);
    }
    // Update is called once per frame
    
}
