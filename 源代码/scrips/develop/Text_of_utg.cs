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
        public GameObject object1,object2,object3,object4,object5;//分别为事件内选择窗口、死亡提示窗口、模块解锁窗口和事件外选择窗口
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
                    else if (linecount1 > line0 && num == 0 && numerical.b6 == 2 && numerical.choice == 1 && numerical.win == 1 )//当夜不设定怪物事件
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
