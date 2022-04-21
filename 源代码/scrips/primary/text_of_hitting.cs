using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace FileApplication
{
    public class text_of_hitting : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        public GameObject object1, object2,object3;//三种窗口分别为选择窗口、战胜与成功逃跑窗口
        int num = 0;
        string name,line;
        public Animator animator;
        int i = 0,j=0;
        bool text_mode = false;//false为文本完全显示模式，true为文本逐字显示模式
        float t=0;
        private void Start()
        {
            numerical.monster = 0;//重置怪物事件的发生
            if (numerical.a4 == 0 && numerical.choice == 0)//初遇
            {
                name = "/primary/hitting1.txt";
                line0 = 11;
                numerical.a4 = 1;
            }
            else if (numerical.a4 == 1 && numerical.choice == 0)//再遇，怪物不同种类
            {
                numerical.kind_of_monster = numerical.random(1, 3);
                if (numerical.kind_of_monster == 1)
                {
                    name = "/primary/hitting2.txt";
                    line0 = 3;
                }
                else if (numerical.kind_of_monster == 2)
                {
                    name = "/primary/hitting3.txt";
                    line0 = 5;
                }
                else if (numerical.kind_of_monster == 3)
                {
                    name = "/primary/hitting4.txt";
                    line0 = 4;
                }
            }
            else if (numerical.choice == 1)//选择去打
            {
                name = "/primary/hitting_win.txt";
                line0 = 5;
            }
            else if (numerical.choice == 2 && numerical.a_1 == 1)//采掘中逃跑
            {
                name = "/primary/hitting_a1.txt";
                line0 = 4;
            }
            else if (numerical.choice == 2 && numerical.a_2 == 1)//打猎时逃跑
            {
                name = "/primary/hitting_a2.txt";
                line0 = 3;
            }
            else if (numerical.choice == 2 && numerical.a_3 == 1)//探索中逃跑
            {
                name = "/primary/hitting_a3.txt";
                line0 = 4;
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
                    if (linecount1 >= line0 && text_mode == false && num == 0 && numerical.choice == 0)//还没选时
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 >= line0 && text_mode == false && num == 0 && numerical.choice == 1 && numerical.win == 1)//判定为赢
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 >= line0 && text_mode == false && num == 0 && numerical.choice == 2) //提桶跑路
                    {
                        Instantiate(object3, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    //判定为输的情况将再window中直接执行切换场景处理，此处不予考虑
                }
                text_mode = !text_mode;//点击一下后逐字显示变为完全显示，完全显示变为逐字显示

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
    }
}