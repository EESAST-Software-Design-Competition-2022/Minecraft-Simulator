using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class Text_of_dragon : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1, object2, object3,object4,object5;//��ս���ڡ�ԭ�´��ڡ���ԭ�µĶ�ս���ڡ�goodend2��normalend2
        int num = 0;
        string name, line;
        public Animator animator;
        int i = 0, j = 0;
        bool text_mode = false;
        float t = 0;
        private void Start()
        {
            if (numerical.cd==0)
            {
                numerical.cd = 1;
                numerical.win = 0;
                numerical.choice = 0;
                if (numerical.c6 == 1)
                {
                    name = "/final/the_end/c14.txt";
                    line0 = 23;
                }
                else
                {
                    name = "/final/the_end/c12.txt";
                    line0 = 15;
                }
            }
            else if (numerical.cd == 1)
            {
                numerical.cd = 2;
                if (numerical.c6 == 1)
                {
                    if (numerical.choice == 1)
                    {
                        name = "/final/the_end/GOODEND2.txt";
                        line0 = 17;
                    }
                    if (numerical.choice == 2)
                    {
                        name = "/final/the_end/c15.txt";
                        line0 = 11;
                    }
                }
                else if (numerical.c6 == 0)
                {
                    name = "/final/the_end/NORMALEND2.txt";
                    line0 = 12;
                }
            }
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
                    if (linecount1 > line0 && num == 0 && numerical.cd == 1 && numerical.c6 == 0)
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.cd == 1 && numerical.c6 == 1)
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.cd == 2 && numerical.c6 == 1 && numerical.choice == 2)  
                    {
                        Instantiate(object3, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.cd == 2 && numerical.c6 == 1 && numerical.choice == 1)
                    {
                        Instantiate(object4, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.cd == 2 && numerical.c6 == 0)
                    {
                        Instantiate(object5, new Vector2(0, 0), Quaternion.identity);
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
