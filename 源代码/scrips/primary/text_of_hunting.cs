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
                // 从文件读取并显示行，直到文件的末尾 
                i = 0;
                if (((line = sr.ReadLine()) != null))
                {
                    if (!text_mode)
                        linecount1++;//完全显示模式再点一下读取下一行
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//读取
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
                            texshow1.text = line.Substring(0, i);//逐字显示文案
                            i++;
                            if (i == line.Length)
                            {
                                text_mode = !text_mode;//文案显示完全后，更改文案现处模式为完全显示
                            }
                        }
                    }
                    else
                    {
                        texshow1.text = line;
                    }//在文字还未显示完全时二次点击按钮，显示全文
                t = 0;
            }
        }
        IEnumerator LoadScene(int index)
        {
            animator.SetBool("fadeout", true);
            animator.SetBool("fadein", false);//设置bool参数
            yield return new WaitForSeconds(1);//等待一秒空白期
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