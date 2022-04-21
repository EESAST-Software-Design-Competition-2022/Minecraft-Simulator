using UnityEngine;

public class Choice : MonoBehaviour//统筹数值变换、怪物事件与特殊事件的发生、怪物事件choice、win等初始化
{
    bool happen = false;
public void Digging()
    {
        if (!happen)
        {
            numerical.material = numerical.material + 4 + numerical.random(0, 2);
            if (numerical.hungry >= 2)
                numerical.hungry = numerical.hungry - 2;
            else
                numerical.hungry = 0;
            numerical.force += numerical.random(0, 10);
            int b = numerical.random(1, 10);
            if (b <= 2&&numerical.material<=40)
                numerical.monster = 1;
            if(numerical.material>40)
            {
                numerical.material -= 30;
                numerical.force += 20;
                numerical.a = 1;
                numerical.a1 = 2;
            }
            numerical.a_1 = 1;
            numerical.a_2 = 0;
            numerical.a_3 = 0;
            numerical.win = 0;
            numerical.choice = 0;
            happen = !happen;
        }
    }
public void Exploring()
    {
        if (!happen) {
            int a = numerical.random(1, 10);
            if (a <= 2)
            {
                numerical.a3 = 2;
                numerical.material = numerical.material + 20;
                numerical.force = numerical.force + 50;
                numerical.a = 3;
            }
            if (numerical.hungry >= 2)
                numerical.hungry = numerical.hungry - 2;
            else
                numerical.hungry = 0;
            int b = numerical.random(1, 100);
            if (b <= 10&&numerical.a3!=2)
                numerical.monster = 1;
            numerical.a_1 = 0;
            numerical.a_2 = 0;
            numerical.a_3 = 1;
            numerical.win = 0;
            numerical.choice = 0;
            happen = !happen;
        }
    }
public void Hunting()
    {
        if (!happen)
        {
            int a = numerical.random(1, 100);
            if (a <= 5)
            {
                numerical.a2 = 2;
                numerical.force += 50;
            }
            numerical.hungry = numerical.hungry + 4 + numerical.random(0, 2);
            int b = numerical.random(1, 10);
            if (b <= 2&&numerical.a2!=2)
                numerical.monster = 1;
            if (numerical.a2 == 2)
                numerical.a = 2;
            numerical.a_1 = 0;
            numerical.a_2 = 1;
            numerical.a_3 = 0;
            numerical.win = 0;
            numerical.choice = 0;
            happen = !happen;
        }
    }
}
