using UnityEngine;
static public class numerical 
{
    public static int force=50;
    public static int hungry=10;
    public static int material=0;//以上三个为基础数值
    public static int a1=0,a2=0,a3=1,a4=0;//表事件经历情况，0为未经历，1为已经历（在探索也表示未经历），2为经历完全
    public static int a_1, a_2, a_3;//表目前所处状态，与面对怪物逃跑的文案有关
    public static int a;//表明进入下一场景的切入接口，1为采掘2为打猎3为探索
    public static int monster = 0;//怪物入侵当晚发生则为1
    public static int b1 = 0, b2 = 0, b3 = 0, b4 = 0, b5 = 0, b6 = 0, b7 = 0, b8 = 0;//分别表示develop中的八个事件发生状况：基建、沙漠、丛林、图书馆、怪物、地牢、海底、女巫
    public static int c2 = 0, c6 = 0, cw = 0, c11 = 0, cd = 0;//猪人、诡异之地、凋零入口、末地城、末影龙
    public static int b_sort = 0;//第二章探索事件发生顺序记录
    public static int choice;//用于记录window的选择按钮
    public static int win;//表示战胜怪物
    public static int succeed;
    public static int kind_of_monster=1;//怪物种类
    public static bool scene_happen = false;//统筹scene_window按钮是否发生点击，防止重复点击事件
    public static int force_ability=0;//特殊值如附魔炼药
    public static bool undie = false;//不死图腾
    public static bool destroy = false;
    public static int random(int a,int b)//这是一个随处可用的随机函数
    {
        return Random.Range(a, b + 1);
    }
    public static bool fight(int difficulty)//这是一个输入难度判定输赢的函数
    {
        if (undie)//不死图腾
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
    public static int Sort()//探索事件发生排序函数
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
