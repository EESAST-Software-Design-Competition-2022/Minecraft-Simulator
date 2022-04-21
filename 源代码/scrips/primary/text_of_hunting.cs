using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class text_of_hunting : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1, object2;
        int num = 0;
        string name, line;
        public Animator animator;
        int i = 0, j = 0;
        float t = 0;
        bool text_mode = false;
        private void Start()
        {
            if (numerical.a2 == 0)
            {
                name = "/primary/hunting1.txt";
                line0 = 16;
                numerical.a2 = 1;
            }
            else if (numerical.a2 == 1)
            {
                name = "/primary/hunting2.txt";
                line0 = 9;
            }
            else if (numerical.a2 == 2)
            {
                name = "/primary/hunting3.txt";
                line0 = 24;
            }
        }

        public void text_of_xuzhang()
        {
            using (StreamReader sr = new StreamReader(Application.streamingAssetsPath + name))
            {
                // ���ļ���ȡ����ʾ�У�ֱ���ļ���ĩβ 
                i = 0;
                if (((line = sr.ReadLine()) != null))
                {
                    if (!text_mode)
                        linecount1++;//��ȫ��ʾģʽ�ٵ�һ�¶�ȡ��һ��
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//��ȡ
                    }
                    if (linecount1 > line0&&text_mode==false && num == 0 && numerical.hungry <= 0)
                        StartCoroutine(LoadScene(7));
                    else if (linecount1 > line0 && text_mode == false && num == 0 && numerical.monster == 0 && (numerical.a2 == 0 || numerical.a2 == 1))
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && text_mode == false && num == 0 && numerical.a2 == 2)
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && text_mode == false && num == 0 && numerical.monster == 1)
                    {
                        StartCoroutine(LoadScene(6));
                        num++;
                    }
                }
                text_mode = !text_mode;
            }
        }
        private void Update()
        {
            t = t + Time.deltaTime;
            if (t > 0.05)
            {
                if (line != null)
                    if (text_mode)
                    {
                        if (i <= line.Length)
                        {
                            texshow1.text = line.Substring(0, i);//������ʾ�İ�
                            i++;
                            if (i == line.Length)
                            {
                                text_mode = !text_mode;//�İ���ʾ��ȫ�󣬸����İ��ִ�ģʽΪ��ȫ��ʾ
                            }
                        }
                    }
                    else
                    {
                        texshow1.text = line;
                    }//�����ֻ�δ��ʾ��ȫʱ���ε����ť����ʾȫ��
                t = 0;
            }
        }
        IEnumerator LoadScene(int index)
        {
            animator.SetBool("fadeout", true);
            animator.SetBool("fadein", false);//����bool����
            yield return new WaitForSeconds(1);//�ȴ�һ��հ���
            AsyncOperation async = SceneManager.LoadSceneAsync(index);
            async.completed += OnLoadedScene;
            yield return new WaitForSeconds(1);
        }
        private void OnLoadedScene(AsyncOperation obj)
        {
            animator.SetBool("fadeout", false);
            animator.SetBool("fadein", true);
        }
    }
}