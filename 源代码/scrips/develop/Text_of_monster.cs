using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FileApplication
{
    public class Text_of_monster : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1, object2, object3;
        int num = 0;
        string name, line;
        public Animator animator;
        int i = 0, j = 0;
        bool text_mode = false;
        float t = 0;
        private void Start()
        {
            if (numerical.b5 == 0&&numerical.a==3)
            {
                name = "/develop/monster/village_before.txt";
                line0 = 11;
                numerical.b5 = 1;
            }
            else if (numerical.b5 == 0 && numerical.a != 3)
            {
                name = "/develop/monster/else_before.txt";
                line0 = 14;
                numerical.b5 = 1;
            }
            else if (numerical.b5 == 1)
            {
                if (numerical.fight(180))
                {
                    if (numerical.a == 3)
                    {
                        name = "/develop/monster/village_win.txt";
                        line0 = 9;
                        numerical.win = 1;
                        numerical.b5 = 2;
                        numerical.force += 20;
                    }
                    else
                    {
                        name = "/develop/monster/else_win.txt";
                        line0 = 7;
                        numerical.win = 1;
                        numerical.b5 = 2;
                        numerical.force += 20;
                    }
                }
                else
                {
                    name = "/develop/monster/die.txt";
                    line0 = 9;
                    numerical.win = 0;
                    numerical.b5 = 2;
                }
            }
            else if (numerical.b5 == 2 )
            {
                name = "/develop/monster/secondtime_before.txt";
                line0 = 4;
                numerical.b5 = 3;
            }
            else if (numerical.b5 == 3)
            {
                if (numerical.fight(180))
                {
                        name = "/develop/monster/secondtime_win.txt";
                        line0 = 5;
                        numerical.win = 1;
                        numerical.b5 = 2;
                        numerical.force += 20;
                }
                else
                {
                    name = "/develop/monster/die.txt";
                    line0 = 9;
                    numerical.win = 0;
                    numerical.b5 = 2;
                }
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
                    if (linecount1 > line0 && num == 0 && (numerical.b5 == 1||numerical.b5==3))
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b5==2 && numerical.win == 0)
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 > line0 && num == 0 && numerical.b5==2 && numerical.win == 1)
                    {
                        Instantiate(object3, new Vector2(0, 0), Quaternion.identity);
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
