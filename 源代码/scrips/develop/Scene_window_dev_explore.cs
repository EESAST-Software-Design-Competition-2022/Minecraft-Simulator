using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_window_dev_explore : MonoBehaviour
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
            int change_to = 0;
            if (numerical.hungry <= 0)
                change_to = 7;
            else if (numerical.random(1, 100) > 30)
            {
                if (numerical.a == 3)
                {
                    if (numerical.random(1, 100) <= 20 && numerical.b4 == 0 && numerical.b1 != 0)
                    {
                        change_to = 14;
                        numerical.b4++;
                    }
                    else if (numerical.b_sort % 10 == 1)
                        change_to = 12;
                    else if (numerical.b_sort % 10 == 2)
                        change_to = 15;
                    else if (numerical.b_sort % 10 == 3)
                        change_to = 16;
                    else if (numerical.b_sort % 10 == 4) 
                        change_to = 17;
                    else
                        change_to = 13;
                }
                else
                {
                    if (numerical.b_sort % 10 == 1)
                        change_to = 12;
                    else if (numerical.b_sort % 10 == 2)
                        change_to = 15;
                    else if (numerical.b_sort % 10 == 3) 
                        change_to = 17;
                    else if (numerical.b_sort % 10 == 4) 
                        change_to = 18;
                    else
                        change_to = 13;
                }
                numerical.b_sort /= 10;
            }
            else
                change_to = 11;
            StartCoroutine(LoadScene(change_to));//在bulidSettings中设置（unity）
            numerical.scene_happen = true;
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