using UnityEngine;
using UnityEngine.UI;

public class numerical_show : MonoBehaviour
{
    public Text textshow1;
    public Text textshow2;
    public Text textshow3;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        textshow1.text = ("����ֵ:" + numerical.force);
        textshow2.text = ("��ʳ��:" + numerical.hungry);
        textshow3.text = ("������:" + numerical.material);
    }
}
