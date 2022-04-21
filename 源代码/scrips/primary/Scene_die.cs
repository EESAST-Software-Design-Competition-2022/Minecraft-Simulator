using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_die : MonoBehaviour
{
    public int change_to = 0;
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
            StartCoroutine(LoadScene(0));
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
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("fadeout", false);
        animator.SetBool("fadein", true);
    }
}