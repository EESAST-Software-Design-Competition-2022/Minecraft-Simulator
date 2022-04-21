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
        //GameObject.DontDestroyOnLoad(this.eventObj2);//�л�����ʱʹ��������ƻ�
        btnA.onClick.AddListener(LoadSceneA);//�Զ����÷���
    }

    private void LoadSceneA()
    {
        Debug.Log("aba");
        StartCoroutine(LoadScene(change_to));//��bulidSettings�����ã�unity��
    }


    // Update is called once per frame
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("fadeout", true);
        animator.SetBool("fadein", false);//����bool����
        yield return new WaitForSeconds(1);//�ȴ�һ��հ���
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