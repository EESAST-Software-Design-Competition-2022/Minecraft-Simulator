using UnityEngine;
static public class numerical 
{
    public static int force=50;
    public static int hungry=10;
    public static int material=0;//��������Ϊ������ֵ
    public static int a1=0,a2=0,a3=1,a4=0;//���¼����������0Ϊδ������1Ϊ�Ѿ�������̽��Ҳ��ʾδ��������2Ϊ������ȫ
    public static int a_1, a_2, a_3;//��Ŀǰ����״̬������Թ������ܵ��İ��й�
    public static int a;//����������һ����������ӿڣ�1Ϊ�ɾ�2Ϊ����3Ϊ̽��
    public static int monster = 0;//�������ֵ�������Ϊ1
    public static int b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0, b6 = 0, b7 = 0, b8 = 0;//�ֱ��ʾdevelop�еİ˸��¼�����״����������ɳĮ�����֡�ͼ��ݡ�������Ρ����ס�Ů��
    public static int c2 = 0, c6 = 0, cw = 0, c11 = 0, cd = 0;//���ˡ�����֮�ء�������ڡ�ĩ�سǡ�ĩӰ��
    public static int b_sort = 0;//�ڶ���̽���¼�����˳���¼
    public static int choice;//���ڼ�¼window��ѡ��ť
    public static int win;//��ʾսʤ����
    public static int succeed;
    public static int kind_of_monster=1;//��������
    public static bool scene_happen = false;//ͳ��scene_window��ť�Ƿ����������ֹ�ظ�����¼�
    public static int force_ability=0;//����ֵ�總ħ��ҩ
    public static bool undie = false;//����ͼ��
    public static bool destroy = false;
    public static int random(int a,int b)//����һ���洦���õ��������
    {
        return Random.Range(a, b + 1);
    }
    public static bool fight(int difficulty)//����һ�������Ѷ��ж���Ӯ�ĺ���
    {
        if (undie)//����ͼ��
        {
            undie = false;
            return true;
        }
        if (force+force_ability>= difficulty)
            return true;
        else if (force >= difficulty / 2 + random(0, difficulty / 2))
            return true;
        else
            return false;
    }
    public static int Sort()//̽���¼�����������
    {
        int a = 0, b = 0, c = 0, d = 0;
        a = random(1, 4);
        while (b == 0 || b == a)
            b = random(1, 4);
        while (c == 0 || c == a || c == b)
            c = random(1, 4);
        d = 10 - a - b - c;
        return (1000 * a + 100 * b + 10 * c + d);
    }
}
