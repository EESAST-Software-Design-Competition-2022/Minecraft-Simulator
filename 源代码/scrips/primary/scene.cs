using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public int change_to=0;
    //public GameObject eventObj;
    //public GameObject eventObj2;
    public Button btnA;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        //GameObject.DontDestroyOnLoad(this.eventObj);
        //GameObject.DontDestroyOnLoad(this.eventObj2);//切换场景时使组件不被破坏
        btnA.onClick.AddListener(LoadSceneA);//自动设置方法
    }

    private void LoadSceneA()
    {
        Debug.Log("aba");
        StartCoroutine(LoadScene(change_to));//在bulidSettings中设置（unity）
    }


    // Update is called once per frame
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("fadeout", true);
        animator.SetBool("fadein", false);//设置bool参数
        yield return new WaitForSeconds(1);//等待一秒空白期
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("fadeout", false);
        animator.SetBool("fadein", true);
    }

    void Update()
    {

    }
}