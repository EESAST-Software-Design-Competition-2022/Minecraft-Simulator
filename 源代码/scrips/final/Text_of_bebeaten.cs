using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class Text_of_bebeaten : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1;
        int num = 0;
        string name, line;
        public Animator animator;
        int i = 0, j = 0;
        bool text_mode = false;
        float t = 0;
        private void Start()
        {
            name = "/final/the_end/BADEND7.txt";
            line0 = 5;
        }
        public void Text()
        {
            using (StreamReader sr = new StreamReader(Application.streamingAssetsPath + name))
            {
                // ���ļ���ȡ����ʾ�У�ֱ���ļ���ĩβ 
                i = 0;
                if (((line = sr.ReadLine()) != null))
                {
                    if (!text_mode)
                        linecount1++;
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//��ȡ
                    }
                    if (linecount1 > line0 && num == 0)//ѡ��ս������
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
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
