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
                        linecount1++;//��ȫ��ʾģʽ�ٵ�һ�¶�ȡ��һ��
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//��ȡ
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
    }
}
 