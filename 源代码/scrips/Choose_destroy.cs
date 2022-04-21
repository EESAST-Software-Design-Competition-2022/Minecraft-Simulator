using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numerical.destroy)
            Destroy(this.gameObject);
    }
}
