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
        public GameObject object1, object2,object3;//���ִ��ڷֱ�Ϊѡ�񴰿ڡ�սʤ��ɹ����ܴ���
        int num = 0;
        string name,line;
        public Animator animator;
        int i = 0,j=0;
        bool text_mode = false;//falseΪ�ı���ȫ��ʾģʽ��trueΪ�ı�������ʾģʽ
        float t=0;
        private void Start()
        {
            numerical.monster = 0;//���ù����¼��ķ���
            if (numerical.a4 == 0 && numerical.choice == 0)//����
            {
                name = "/primary/hitting1.txt";
                line0 = 11;
                numerical.a4 = 1;
            }
            else if (numerical.a4 == 1 && numerical.choice == 0)//���������ﲻͬ����
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
            else if (numerical.choice == 1)//ѡ��ȥ��
            {
                name = "/primary/hitting_win.txt";
                line0 = 5;
            }
            else if (numerical.choice == 2 && numerical.a_1 == 1)//�ɾ�������
            {
                name = "/primary/hitting_a1.txt";
                line0 = 4;
            }
            else if (numerical.choice == 2 && numerical.a_2 == 1)//����ʱ����
            {
                name = "/primary/hitting_a2.txt";
                line0 = 3;
            }
            else if (numerical.choice == 2 && numerical.a_3 == 1)//̽��������
            {
                name = "/primary/hitting_a3.txt";
                line0 = 4;
            }
        }
        public void text_of_xuzhang()
        {
            using (StreamReader sr = new StreamReader(Application.streamingAssetsPath + name))
            {
                // ���ļ���ȡ����ʾ�У�ֱ���ļ���ĩβ 
                i = 0;
                if (((line = sr.ReadLine()) != null))
                {
                    if (!text_mode)
                        linecount1++;//��ȫ��ʾģʽ�ٵ�һ�¶�ȡ��һ��
                    for (j = 1; j < linecount1; j++)
                    {
                        line = sr.ReadLine();//��ȡ
                    }
                    if (linecount1 >= line0 && text_mode == false && num == 0 && numerical.choice == 0)//��ûѡʱ
                    {
                        Instantiate(object1, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 >= line0 && text_mode == false && num == 0 && numerical.choice == 1 && numerical.win == 1)//�ж�ΪӮ
                    {
                        Instantiate(object2, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    else if (linecount1 >= line0 && text_mode == false && num == 0 && numerical.choice == 2) //��Ͱ��·
                    {
                        Instantiate(object3, new Vector2(0, 0), Quaternion.identity);
                        num++;
                    }
                    //�ж�Ϊ����������window��ֱ��ִ���л����������˴����迼��
                }
                text_mode = !text_mode;//���һ�º�������ʾ��Ϊ��ȫ��ʾ����ȫ��ʾ��Ϊ������ʾ

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