using UnityEngine;

public class hitting : MonoBehaviour
{
    int happen = 0;
    public void ran()
    {
        if (happen == 0)
        {
            numerical.choice = 2;
            if (numerical.a_1 == 1)
                numerical.material /= 2;
            else if (numerical.a_2 == 1)
                numerical.hungry /= 2;
            happen = 1;
        }
    }
    public void fight()
    {
        if (happen == 0)
        {
            numerical.choice = 1;
            if (numerical.fight(80))
            {
                numerical.win = 1;
                numerical.force += 20;
                numerical.hungry -= 2;
                if (numerical.hungry < 0)
                    numerical.hungry = 0;
            }
            else
                numerical.win = 0;
            happen = 1;
        }
    }
}
