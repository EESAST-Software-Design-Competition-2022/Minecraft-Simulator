using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_window_monster : MonoBehaviour
{
    public int change_to1 = 0, change_to2 = 0;
    //public GameObject eventObj;
    //public GameObject eventObj2;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        numerical.scene_happen = false;
        GameObject.DontDestroyOnLoad(this.gameObject);
        //GameObject.DontDestroyOnLoad(this.eventObj);
        //GameObject.DontDestroyOnLoad(this.eventObj2);//�л�����ʱʹ��������ƻ�
    }

    public void LoadSceneA()
    {
        if (!numerical.scene_happen)
        {
            if (numerical.win == 1)
                StartCoroutine(LoadScene(change_to1));
            else
                StartCoroutine(LoadScene(change_to2));
            numerical.scene_happen = true;
        }
    }


    // Update is called once per frame
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("fadeout", true);
        animator.SetBool("fadein", false);//����bool����
        yield return new WaitForSeconds(1);//�ȴ�һ��հ���
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
        yield return new WaitForSeconds((float)1);
        Destroy(this.gameObject);
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("fadeout", false);
        animator.SetBool("fadein", true);
    }
}
