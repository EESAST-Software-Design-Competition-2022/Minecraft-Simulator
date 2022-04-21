using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace FileApplication
{
    public class text_of_die1 : MonoBehaviour
    {
        int line0;
        int linecount1 = 0;
        public Text texshow1;
        int num = 0;
        string name,line;
        public GameObject object1;
        public Animator animator;
        int i = 0, j = 0;
        float t = 0;
        bool text_mode = false;
        private void Start()
        {
            name = "/primary/die1.txt";
            line0 = 4;
        }
        public void text_of_xuzhang()
        {
            using (StreamReader sr = new StreamReader(Application.streamingAssetsPath + name))
            {
                i = 0;
                if (((line = sr.ReadLine()) != null))
                {
                    if (!text_mode)
                        linecount1++;//完全显示模式再点一下读取下一行
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//读取
                    }
                    if (linecount1 > line0 && num == 0)
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
 