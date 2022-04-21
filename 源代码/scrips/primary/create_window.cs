using UnityEngine;

public class create_window : MonoBehaviour
{
    public GameObject object1;
    // Start is called before the first frame update
    public void click()
    {
        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame

}
