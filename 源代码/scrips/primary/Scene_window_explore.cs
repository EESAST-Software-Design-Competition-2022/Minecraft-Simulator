using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_window_explore : MonoBehaviour
{
    //public GameObject eventObj;
    //public GameObject eventObj2;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        numerical.scene_happen = false;
        GameObject.DontDestroyOnLoad(this.gameObject);
        //GameObject.DontDestroyOnLoad(this.eventObj);
        //GameObject.DontDestroyOnLoad(this.eventObj2);//切换场景时使组件不被破坏
    }

    public void LoadSceneA()
    {
        if (!numerical.scene_happen)
        {
            if (numerical.hungry <= 0)
                StartCoroutine(LoadScene(7));
            else if (numerical.a3 == 1)
                StartCoroutine(LoadScene(4));
            else
                StartCoroutine(LoadScene(5));
            numerical.scene_happen=true;
        }
    }


    // Update is called once per frame
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("fadeout", true);
        animator.SetBool("fadein", false);//设置bool参数
        yield return new WaitForSeconds(1);//等待一秒空白期
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("fadeout", false);
        animator.SetBool("fadein", true);
    }
}