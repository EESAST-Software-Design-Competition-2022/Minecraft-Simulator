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
        textshow1.text = ("武力值:" + numerical.force);
        textshow2.text = ("饱食度:" + numerical.hungry);
        textshow3.text = ("材料数:" + numerical.material);
    }
}
