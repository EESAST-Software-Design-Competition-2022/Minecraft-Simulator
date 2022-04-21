using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class Text_of_utg : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1,object2,object3,object4,object5;//�ֱ�Ϊ�¼���ѡ�񴰿ڡ�������ʾ���ڡ�ģ��������ں��¼���ѡ�񴰿�
        int num = 0;
        string name, line;
        public Animator animator;
        int i = 0, j = 0;
        bool text_mode = false;
        float t = 0;
        private void Start()
        {
        if (numerical.b6 == 0)
            {
                name = "/develop/under_the_ground/before.txt";
                line0 = 21;
                numerical.b6 = 1;
            }
        else if (numerical.b6 == 1&&numerical.choice==1)
            {
                if (numerical.fight(220))
                {
                    name = "/develop/under_the_ground/win.txt";
                    line0 = 11;
                    numerical.win = 1;
                    numerical.force += 50;
                    numerical.b6 = 2;
                }
                else
                {
                    name = "/develop/under_the_ground/die.txt";
                    line0 = 9;
                    numerical.win = 0;
                    numerical.b6 = 2;
                }
            }
        else if (numerical.b6 == 1 && numerical.choice == 2)
            {
                name = "/develop/under_the_ground/run.txt";
                line0 = 7;
                numerical.b6 = 2;
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
                    if (linecount1 > line0 && num == 0 && numerical.b6 == 1)
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b6 == 2 && numerical.choice == 1 && numerical.win == 0 ) 
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b6 == 2 && numerical.choice == 1 && numerical.win == 1 )//��ҹ���趨�����¼�
                    {
                        Instantiate(object3, new Vector2(0, 0), Quaternion.identity);
                        Instantiate(object5, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b6 == 2 && numerical.choice == 2&& numerical.monster == 0)
                    {
                        Instantiate(object4, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b6 == 2 && numerical.monster == 1)
                    {
                        StartCoroutine(LoadScene(19));
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
