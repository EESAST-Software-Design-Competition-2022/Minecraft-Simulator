using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class text_of_digging : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1,object2;
        int num = 0;
        string name,line;
        public Animator animator;
        int i=0, j=0;
        bool text_mode = false;
        float t = 0;
        private void Start()
        {
            if (numerical.a1 == 0)
            {
                name = "/primary/digging1.txt";
                line0 = 7;
                numerical.a1 = 1;
            }
            else if(numerical.a1==2)
            {
                name = "/primary/digging4.txt";
                line0 = 12;
            }
            else if (numerical.material <= 18)
            {
                name = "/primary/digging2.txt";
                line0 = 3;
            }
            else if (numerical.material <= 40)
            {
                name = "/primary/digging3.txt";
                line0 = 5;
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
                        linecount1++;
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//读取
                    }
                    if (linecount1 > line0 && num == 0 && numerical.hungry <= 0)
                        StartCoroutine(LoadScene(7));
                    else if (linecount1 > line0 && num == 0 && numerical.a1 == 2)
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.monster == 0 && numerical.material <= 40)
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.monster == 1)
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
            yield return new WaitForSeconds((float)1);
        }
        private void OnLoadedScene(AsyncOperation obj)
        {
            animator.SetBool("fadeout", false);
            animator.SetBool("fadein", true);
        }
    }
}
