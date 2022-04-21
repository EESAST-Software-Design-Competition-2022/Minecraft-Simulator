using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class Text_of_forest : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1, object2,object3,object4;
        int num = 0;
        string name, line;
        public Animator animator;
        int i = 0, j = 0;
        bool text_mode = false;
        float t = 0;
        private void Start()
        {
            if (numerical.b3 == 2 && numerical.choice == 1)
            {
                numerical.b3 = 3;
                if (numerical.fight(200))
                {
                    name = "/develop/forest/fight_win.txt";
                    line0 = 4;
                    numerical.material += 5;
                    numerical.force += 20;
                    numerical.hungry += 10;
                }
                else
                {
                    name = "/develop/forest/fight_lose.txt";
                    line0 = 6;
                    if (numerical.hungry >= 3)
                        numerical.hungry -= 3;
                    else
                        numerical.hungry = 0;
                    numerical.force -= 20;
                }
            }
            else if (numerical.b3 == 2 && numerical.choice == 2)
            {
                numerical.b3 = 3;
                if (numerical.random(1, 2) == 1)
                {
                    name = "/develop/forest/gowith_succeed.txt";
                    line0 = 2;
                    numerical.material += 3;
                    numerical.force += 15;
                }
                else
                {
                    name = "/develop/forest/gowith_fail.txt";
                    line0 = 2;
                    numerical.force -= 15;
                    if (numerical.hungry >= 2)
                        numerical.hungry -= 2;
                    else
                        numerical.hungry = 0;
                }
            }
            if (numerical.b3 == 0)
            {
                name = "/develop/forest/before.txt";
                line0 = 12;
                numerical.b3 = 1;
            }
            if (numerical.b3 == 1&&numerical.choice==1)
            {
                name = "/develop/forest/fight.txt";
                line0 = 3;
                numerical.b3 = 2;
            }
            if (numerical.b3 == 1&&numerical.choice==2)
            {
                name = "/develop/forest/gowith.txt";
                line0 = 6;
                numerical.b3 = 2;
            }
        }
        public void Text()
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
                    if (linecount1 > line0 && num == 0 && numerical.b3 == 1)
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b3 == 2 && numerical.choice == 1)
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b3 == 2 && numerical.choice == 2)
                    {
                        Instantiate(object3, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b3 == 3 && numerical.monster == 0) 
                    {
                        Instantiate(object4, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.monster == 1)
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