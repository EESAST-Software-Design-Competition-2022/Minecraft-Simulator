using UnityEngine;

public class Initiaalization : MonoBehaviour
{
    private void Start()
    {
        numerical.destroy = true;
    }
    public void click()
    {
        numerical.destroy = false;
        numerical.force = 50;
        numerical.hungry = 10;
        numerical.material = 0;
        numerical.force_ability = 0;
        numerical.undie = false;
        numerical.a1 = 0;
        numerical.a2 = 0;
        numerical.a3 = 1;
        numerical.a4 = 0;
        numerical.a_1 = 0;
        numerical.a_2 = 0;
        numerical.a_3 = 0;
        numerical.a = 0;
        numerical.monster = 0;
        numerical.choice = 0;
        numerical.win = 0;
        numerical.succeed = 0;
        numerical.kind_of_monster = 1;
        numerical.scene_happen = false;
        numerical.b_sort = numerical.Sort();
        numerical.b1 = 0;
        numerical.b2 = 0;
        numerical.b3 = 0;
        numerical.b4 = 0;
        numerical.b5 = 0;
        numerical.b6 = 0;
        numerical.b7 = 0;
        numerical.b8 = 0;
        numerical.c2 = 0;
        numerical.c6 = 0;
        numerical.cw = 0;
        numerical.cd = 0;
        numerical.c11 = 0;
    }
}
