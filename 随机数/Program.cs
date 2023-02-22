namespace 随机数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("随机数");
            //Random r = new Random();

            //int i = r.Next(100);

            //定义唐老师信息
    
            Random attack = new Random();

            //int attackTang = attack.Next(8,12) ;


            //定义小怪兽信息
            int defend = 10;
            int hp = 20;


                for (int i = 1; ; i++)
                {
                    Console.Write("唐老师第{0}次攻击小怪兽：", i);
                    int attackTang = attack.Next(8, 13);
                    if (attackTang > defend)
                    {
                        hp = hp - (attackTang - defend);
                        if (hp >= 0)
                        {
                            Console.WriteLine("A唐老师此次攻击为{0}点，小怪兽抵御了{1}点伤害，唐老师给小怪兽造成的实际伤害为{2}点，小怪兽剩余血量为{3}点,剩余防御为0点", attackTang, defend, attackTang - defend, hp);
                            defend = 0;
                        }
                        else
                        {
                        Console.WriteLine("B唐老师此次攻击为{0}点，小怪兽抵御了{1}点伤害，唐老师给小怪兽造成的实际伤害为{2}点，小怪兽剩余血量为0点,剩余防御为0点", attackTang, defend, hp + attackTang);
                            break;

                        }

                    }
                    else
                    {
                        defend = defend - attackTang;
                        Console.WriteLine("C唐老师此次攻击为{0}点，小怪兽抵御了{1}点伤害，唐老师给小怪兽造成的实际伤害为0点，小怪兽剩余血量为{2}点,剩余防御为{3}点", attackTang, attackTang, hp, defend);

                    }

                Console.WriteLine("请按任意键继续");
                Console.ReadKey(true);
                Console.Clear();

                }

            Console.WriteLine("怪物已死亡");
        }
    }
}