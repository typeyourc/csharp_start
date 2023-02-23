namespace 入门实践
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("入门实践");

            //设置窗口大小
            //下面的这个窗口尺寸太大，超出了范围
            //Console.SetWindowSize(800, 600);
            //Console.SetBufferSize(900, 700);

            //合适的窗口尺寸，宽度和高度
            Console.SetWindowSize(100, 51);
            Console.SetBufferSize(100, 51);

            //全局变量，是否回到开始界面，0表示否，1表示是
            int isBackToStartPage = 0;

            while (true)
            {
                #region 开始界面
                //-----------------开始界面-----------------

                //1.初始设置
                //清屏
                Console.Clear();

                //隐藏光标
                Console.CursorVisible = false;

                //设置光标位置-绘制游戏大标题
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(44, 7);
                Console.WriteLine("唐老师营救公主");

                //设置光标位置-绘制开始游戏
                Console.SetCursorPosition(47, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("开始游戏");

                //设置光标位置-绘制退出游戏
                Console.SetCursorPosition(47, 14);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("退出游戏");

                //使用帮助
                Console.SetCursorPosition(34, 17);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--按w或者s键选择，按回车键选中--");

                //通过设置字体颜色让控制台自动输出的信息不显示
                Console.ForegroundColor = ConsoleColor.Black;

                //2.循环检测检测输入，并变换颜色
                //疑问：如何获取小键盘上的上下箭头，下面的程序只是用了W和s上下移动选择选项

                //默认停留在的选项标志，1表示选中，0表示未选中
                int isStart = 1;
                int isEExit = 0;

                while (true)
                {

                    //char input = Console.ReadKey(true).KeyChar;

                    //获取输入选项，注意enter回车键的获得方法，是通过ASCII码的方式获取
                    char xxInput = Console.ReadKey(true).KeyChar;
                    int xxInputEnter = Convert.ToInt32(xxInput);

                    switch (xxInput)
                    {
                        case 'w':
                        case 'W':
                            //case '↑':
                            Console.SetCursorPosition(47, 11);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("开始游戏");

                            Console.SetCursorPosition(47, 14);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("退出游戏");

                            Console.ForegroundColor = ConsoleColor.Black;

                            isStart = 1;
                            isEExit = 0;

                            break;

                        case 's':
                        case 'S':
                            //case '↓':
                            Console.SetCursorPosition(47, 11);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("开始游戏");

                            Console.SetCursorPosition(47, 14);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("退出游戏");

                            Console.ForegroundColor = ConsoleColor.Black;

                            isStart = 0;
                            isEExit = 1;

                            break;

                            //default:
                            //    break;

                    }

                    if (xxInputEnter == 13)
                    {
                        if (isStart == 1)
                        {
                            Console.Clear();
                            break;
                        }
                        else if (isEExit == 1)
                        {
                            Environment.Exit(0);
                        }
                    }

                 
                    //原先获取enter键输入方法，废弃
                    //ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    //if (keyInfo.Key == ConsoleKey.Enter && (input == 'w' || input == 'W'))
                    //{
                    //    Console.Clear();
                    //    break;
                    //}
                    //else if (keyInfo.Key == ConsoleKey.Enter && (input == 's' || input == 'S'))
                    //{
                    //    Environment.Exit(0);
                    //}


                }

                #endregion

                #region 游戏界面

                //1.绘制城墙
                //包含boss战斗区域和信息输出区域两块
                //备注：小方块■，圆形●,i为行，j为列
                //这个地方设置打印边界的时候注意，行边界(i)要留个5行左右(比设置的窗口行数大小上)，因为控制台自己输出的一些信息可能会导致输出的方框第一行被覆盖出现异常
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorVisible = false;
                for (int i = 0; i <= 45; i++)
                {
                    for (int j = 0; j <= 98; j += 2)
                    {
                        if (i == 0 || i == 40 || i == 45)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write('■');
                        }
                        else
                        {
                            if (j == 0 || j == 98)
                            {
                                Console.SetCursorPosition(j, i);
                                Console.Write('■');
                            }
                        }

                    }
                }
                Console.ForegroundColor = ConsoleColor.Black;

                //2.绘制boss和公主
                //boss坐标设置为(50,27)，公主默认坐标(58,6)，公主标记♀


                Console.SetCursorPosition(50, 27);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("■");

                //将控制台默认输出的信息移动到城堡外面，以免影响游戏显示
                Console.SetCursorPosition(0, 46);


                //定义boss初始血量
                int bossHp = 100;

                //3.绘制会移动的唐老师
                //唐老师初始坐标(2,1),圆形

                int tangXposition = 2;
                int tangYposition = 1;

                Console.SetCursorPosition(tangXposition, tangYposition);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("●");

                //将控制台默认输出的信息移动到城堡外面，以免影响游戏显示
                Console.SetCursorPosition(0, 46);

                //定义boss初始血量
                int tangHp = 100;

                //定义是否战胜boss标志，默认未战胜是0,1表示战胜
                int isSuccess = 0;

                //定义是否营救成功公主标志，默认未营救是0，营救是1
                int isHelpPrincessSuccess = 0;

                //唐老师移动(需要解决城堡边界问题、boss打击碰撞问题）
                //boss周围的4个坐标，左(48,27)/右(52,27)/上(50,26)/下(50,28)
                while (true)
                {
                    char gameInput = Console.ReadKey(true).KeyChar;
                    switch (gameInput)
                    {
                        #region CASE A
                        case 'a':
                        case 'A':
                            //假设移动，移动后光标的新位置
                            tangXposition = tangXposition - 2;
                            tangYposition = tangYposition;

                            //城堡左边界判断,同时判断是否已经打怪成功，并进入完成打怪
                            if (tangXposition >= 2 && isSuccess == 0)
                            {

                                //判断如果下一个位置是boss位置，则无法移动唐老师，并且光标位置归为移动前位置
                                if (tangXposition == 50 && tangYposition == 27)
                                {
                                    tangXposition = tangXposition + 2;
                                    tangYposition = tangYposition;

                                    break;
                                }
                                else
                                {
                                    //打怪位置判断(怪物右边位置)
                                    if ((tangXposition == 52 && tangYposition == 27) || (tangXposition == 50 && tangYposition == 26) || (tangXposition == 50 && tangYposition == 28))
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);

                                    }
                                    //如果离开打怪位置，信息区则无输出
                                    else
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);
                                    }

                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition + 2, tangYposition);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    //tangXposition = tangXposition - 2;
                                    //tangYposition = tangYposition;
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    if ((tangXposition == 52 && tangYposition == 27) || (tangXposition == 50 && tangYposition == 26) || (tangXposition == 50 && tangYposition == 28))
                                    {
                                        //持续打boss
                                        while (true)
                                        {
                                            char beatInput = Console.ReadKey(true).KeyChar;
                                            if (beatInput == 'J' || gameInput == 'j')
                                            {
                                                Random r = new Random();
                                                int attackTang = r.Next(100);
                                                int attackBoss = r.Next(1, 10);
                                                bossHp = bossHp - attackTang;
                                                tangHp = tangHp - attackBoss;
                                                //战斗中
                                                if (bossHp >= 0 && tangHp >= 0)
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("开始和Boss战斗，按J键继续");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你对boss造成{0}点伤害，boss剩余血量为{1}", attackTang, bossHp);
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("boss对你造成{0}点伤害，你的剩余血量{1}", attackBoss, tangHp);
                                                }
                                                //唐老师战斗胜利
                                                else if (bossHp < 0 && tangHp >= 0)
                                                {

                                                    //更新战胜boss标记
                                                    isSuccess = 1;

                                                    //清除boss显示
                                                    Console.SetCursorPosition(50, 27);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("  ");

                                                    //打印战胜boss信息
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("前往公主身边按J键营救公主");

                                                    //除掉第三行原先遗留显示的信息
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    //绘制公主
                                                    Console.SetCursorPosition(58, 6);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("♀");

                                                    break;
                                                }
                                                //唐老师战败显示，目前只能退出游戏
                                                else
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你已战败按J键关闭游戏");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    char closeGame = Console.ReadKey(true).KeyChar;
                                                    if (closeGame == 'j' || closeGame == 'J')
                                                    {
                                                        Environment.Exit(0);

                                                    }

                                                }

                                            }
                                            else
                                            {

                                                break;
                                            }
                                        }
                                    }


                                }

                            }
                            //战胜了boss情况下的移动
                            //公主的位置(58,6)，公主周围坐标，右(60,6)、左(56,6)、上(58,5)、下(58,7)
                            else if (tangXposition >= 2 && isSuccess == 1)
                            {
                                //到达公主旁边的位置
                                if ((tangXposition == 60 && tangYposition == 6) || (tangXposition == 58 && tangYposition == 5) || (tangXposition == 58 && tangYposition == 7))
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition + 2, tangYposition);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你已经达到公主旁边，按J键营救公主");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    //Console.SetCursorPosition(2, 42);
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");

                                    //等待输入J营救公主
                                    char helpPrincess = Console.ReadKey(true).KeyChar;
                                    if (helpPrincess == 'J' || helpPrincess == 'j')
                                    {
                                        isHelpPrincessSuccess = 1;
                                        break;
                                    }
                                }
                                //非公主旁边的位置
                                else
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition + 2, tangYposition);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                }

                            }
                            //到达左侧边界时候，不再往左移动
                            else
                            {
                                tangXposition = tangXposition + 2;
                                tangYposition = tangYposition;
                            }

                            break;
                        #endregion

                        #region CASE D
                        //case 'd':
                        //case 'D':
                        //    tangXposition = tangXposition + 2;
                        //    tangYposition = tangYposition;


                        //    if (tangXposition <= 96)//城堡右边界判断
                        //    {
                        //        if (tangXposition == 50 && tangYposition == 27)
                        //        {
                        //            tangXposition = tangXposition - 2;
                        //            tangYposition = tangYposition;
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            if ((tangXposition == 48 && tangYposition == 27) || (tangXposition == 50 && tangYposition == 26) || (tangXposition == 50 && tangYposition == 28))
                        //            {
                        //                Console.SetCursorPosition(2, 41);
                        //                Console.ForegroundColor = ConsoleColor.White;
                        //                Console.WriteLine("开始和Boss战斗，按J键继续");
                        //                Console.SetCursorPosition(2, 42);
                        //                Console.WriteLine("你的当前血量为：{0}", tangHp);
                        //                Console.SetCursorPosition(2, 43);
                        //                Console.WriteLine("boss的当前血量为：{0}", bossHp);

                        //            }
                        //            else
                        //            {
                        //                Console.SetCursorPosition(2, 41);
                        //                Console.ForegroundColor = ConsoleColor.Black;
                        //                Console.WriteLine("开始和Boss战斗，按J键继续");
                        //                Console.SetCursorPosition(2, 42);
                        //                Console.WriteLine("你的当前血量为：{0}", tangHp);
                        //                Console.SetCursorPosition(2, 43);
                        //                Console.WriteLine("boss的当前血量为：{0}", bossHp);
                        //            }

                        //            Console.ForegroundColor = ConsoleColor.Black;
                        //            Console.SetCursorPosition(tangXposition - 2, tangYposition);
                        //            Console.Write("  ");
                        //            //tangXposition = tangXposition + 2;
                        //            //tangYposition = tangYposition;
                        //            Console.SetCursorPosition(tangXposition, tangYposition);
                        //            Console.ForegroundColor = ConsoleColor.Yellow;
                        //            Console.Write("●");
                        //        }

                        //    }
                        //    else
                        //    {
                        //        tangXposition = tangXposition - 2;
                        //        tangYposition = tangYposition;
                        //    }


                        //    break;
                        #endregion

                        #region CASE DD
                        case 'd':
                        case 'D':
                            //假设移动，移动后光标的新位置
                            tangXposition = tangXposition + 2;
                            tangYposition = tangYposition;

                            //城堡右边界判断,同时判断是否已经打怪成功，并进入完成打怪
                            if (tangXposition <= 96 && isSuccess == 0)
                            {

                                //判断如果下一个位置是boss位置，则无法移动唐老师，并且光标位置归为移动前位置
                                if (tangXposition == 50 && tangYposition == 27)
                                {
                                    tangXposition = tangXposition - 2;
                                    tangYposition = tangYposition;

                                    break;
                                }
                                else
                                {
                                    //打怪位置判断(怪物左边位置)
                                    if ((tangXposition == 48 && tangYposition == 27) || (tangXposition == 50 && tangYposition == 26) || (tangXposition == 50 && tangYposition == 28))
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);

                                    }
                                    //如果离开打怪位置，信息区则无输出
                                    else
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);
                                    }

                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition - 2, tangYposition);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    //tangXposition = tangXposition - 2;
                                    //tangYposition = tangYposition;
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    if ((tangXposition == 48 && tangYposition == 27) || (tangXposition == 50 && tangYposition == 26) || (tangXposition == 50 && tangYposition == 28))
                                    {
                                        //持续打boss
                                        while (true)
                                        {
                                            char beatInput = Console.ReadKey(true).KeyChar;
                                            if (beatInput == 'J' || gameInput == 'j')
                                            {
                                                Random r = new Random();
                                                int attackTang = r.Next(100);
                                                int attackBoss = r.Next(1, 10);
                                                bossHp = bossHp - attackTang;
                                                tangHp = tangHp - attackBoss;
                                                //战斗中
                                                if (bossHp >= 0 && tangHp >= 0)
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("开始和Boss战斗，按J键继续");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你对boss造成{0}点伤害，boss剩余血量为{1}", attackTang, bossHp);
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("boss对你造成{0}点伤害，你的剩余血量{1}", attackBoss, tangHp);
                                                }
                                                //唐老师战斗胜利
                                                else if (bossHp < 0 && tangHp >= 0)
                                                {

                                                    //更新战胜boss标记
                                                    isSuccess = 1;

                                                    //清除boss显示
                                                    Console.SetCursorPosition(50, 27);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("  ");

                                                    //打印战胜boss信息
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("前往公主身边按J键营救公主");

                                                    //除掉第三行原先遗留显示的信息
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    //绘制公主
                                                    Console.SetCursorPosition(58, 6);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("♀");

                                                    break;
                                                }
                                                //唐老师战败显示，目前只能退出游戏
                                                else
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你已战败按J键关闭游戏");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    char closeGame = Console.ReadKey(true).KeyChar;
                                                    if (closeGame == 'j' || closeGame == 'J')
                                                    {
                                                        Environment.Exit(0);

                                                    }

                                                }

                                            }
                                            else
                                            {

                                                break;
                                            }
                                        }
                                    }


                                }

                            }
                            //战胜了boss情况下的移动
                            //公主的位置(58,6)，公主周围坐标，右(60,6)、左(56,6)、上(58,5)、下(58,7)
                            else if (tangXposition >= 2 && isSuccess == 1)
                            {
                                if ((tangXposition == 56 && tangYposition == 6) || (tangXposition == 58 && tangYposition == 5) ||(tangXposition == 58 && tangYposition == 7))
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition - 2, tangYposition);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你已经达到公主旁边，按J键营救公主");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    //Console.SetCursorPosition(2, 42);
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");

                                    //等待输入J营救公主
                                    char helpPrincess = Console.ReadKey(true).KeyChar;
                                    if (helpPrincess == 'J' || helpPrincess == 'j')
                                    {
                                        isHelpPrincessSuccess = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition - 2, tangYposition);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                }

                            }
                            //到达左侧边界时候，不再往左移动
                            else
                            {
                                tangXposition = tangXposition - 2;
                                tangYposition = tangYposition;
                            }

                            break;
                        #endregion

                        #region CASE W
                        //case 'w':
                        //case 'W':
                        //    tangXposition = tangXposition;
                        //    tangYposition = tangYposition - 1;


                        //    if (tangYposition >= 1)//城堡上边界判断
                        //    {
                        //        if (tangXposition == 50 && tangYposition == 27)
                        //        {
                        //            tangXposition = tangXposition;
                        //            tangYposition = tangYposition + 1;
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            if ((tangXposition == 50 && tangYposition == 28) || (tangXposition == 48 && tangYposition == 27) || (tangXposition == 52 && tangYposition == 27))
                        //            {
                        //                Console.ForegroundColor = ConsoleColor.White;
                        //                Console.SetCursorPosition(2, 41);
                        //                Console.WriteLine("开始和Boss战斗，按J键继续");
                        //                Console.SetCursorPosition(2, 42);
                        //                Console.WriteLine("你的当前血量为：{0}", tangHp);
                        //                Console.SetCursorPosition(2, 43);
                        //                Console.WriteLine("boss的当前血量为：{0}", bossHp);

                        //            }
                        //            else
                        //            {
                        //                Console.SetCursorPosition(2, 41);
                        //                Console.ForegroundColor = ConsoleColor.Black;
                        //                Console.WriteLine("开始和Boss战斗，按J键继续");
                        //                Console.SetCursorPosition(2, 42);
                        //                Console.WriteLine("你的当前血量为：{0}", tangHp);
                        //                Console.SetCursorPosition(2, 43);
                        //                Console.WriteLine("boss的当前血量为：{0}", bossHp);
                        //            }

                        //            Console.ForegroundColor = ConsoleColor.Black;
                        //            Console.SetCursorPosition(tangXposition, tangYposition + 1);
                        //            Console.Write("  ");
                        //            //tangXposition = tangXposition;
                        //            //tangYposition = tangYposition - 1;
                        //            Console.SetCursorPosition(tangXposition, tangYposition);
                        //            Console.ForegroundColor = ConsoleColor.Yellow;
                        //            Console.Write("●");
                        //        }
                        //    }
                        //    else
                        //    {
                        //        tangXposition = tangXposition;
                        //        tangYposition = tangYposition + 1;

                        //    }

                        //    break;
                        #endregion

                        #region CASE WW
                        case 'w':
                        case 'W':
                            //假设移动，移动后光标的新位置
                            tangXposition = tangXposition;
                            tangYposition = tangYposition - 1;

                            //城堡上边界判断,同时判断是否已经打怪成功，并进入完成打怪
                            if (tangYposition >= 1 && isSuccess == 0)
                            {

                                //判断如果下一个位置是boss位置，则无法移动唐老师，并且光标位置归为移动前位置
                                if (tangXposition == 50 && tangYposition == 27)
                                {
                                    tangXposition = tangXposition;
                                    tangYposition = tangYposition + 1;

                                    break;
                                }
                                else
                                {
                                    //打怪位置判断(怪物下边位置)
                                    if ((tangXposition == 50 && tangYposition == 28) || (tangXposition == 48 && tangYposition == 27) || (tangXposition == 52 && tangYposition == 27))
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);

                                    }
                                    //如果离开打怪位置，信息区则无输出
                                    else
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);
                                    }

                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition, tangYposition + 1);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    //tangXposition = tangXposition - 2;
                                    //tangYposition = tangYposition;
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    if ((tangXposition == 50 && tangYposition == 28) || (tangXposition == 48 && tangYposition == 27) || (tangXposition == 52 && tangYposition == 27))
                                    {
                                        //持续打boss
                                        while (true)
                                        {
                                            char beatInput = Console.ReadKey(true).KeyChar;
                                            if (beatInput == 'J' || gameInput == 'j')
                                            {
                                                Random r = new Random();
                                                int attackTang = r.Next(100);
                                                int attackBoss = r.Next(1, 10);
                                                bossHp = bossHp - attackTang;
                                                tangHp = tangHp - attackBoss;
                                                //战斗中
                                                if (bossHp >= 0 && tangHp >= 0)
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("开始和Boss战斗，按J键继续");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你对boss造成{0}点伤害，boss剩余血量为{1}", attackTang, bossHp);
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("boss对你造成{0}点伤害，你的剩余血量{1}", attackBoss, tangHp);
                                                }
                                                //唐老师战斗胜利
                                                else if (bossHp < 0 && tangHp >= 0)
                                                {

                                                    //更新战胜boss标记
                                                    isSuccess = 1;

                                                    //清除boss显示
                                                    Console.SetCursorPosition(50, 27);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("  ");

                                                    //打印战胜boss信息
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("前往公主身边按J键营救公主");

                                                    //除掉第三行原先遗留显示的信息
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    //绘制公主
                                                    Console.SetCursorPosition(58, 6);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("♀");

                                                    break;
                                                }
                                                //唐老师战败显示，目前只能退出游戏
                                                else
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你已战败按J键关闭游戏");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    char closeGame = Console.ReadKey(true).KeyChar;
                                                    if (closeGame == 'j' || closeGame == 'J')
                                                    {
                                                        Environment.Exit(0);

                                                    }

                                                }

                                            }
                                            else
                                            {

                                                break;
                                            }
                                        }
                                    }


                                }

                            }
                            //战胜了boss情况下的移动
                            //公主的位置(58,6)，公主周围坐标，右(60,6)、左(56,6)、上(58,5)、下(58,7)
                            else if (tangYposition >= 2 && isSuccess == 1)
                            {
                                if ((tangXposition == 58 && tangYposition == 7) || (tangXposition == 56 && tangYposition == 6) || (tangXposition == 60 && tangYposition == 6))
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition, tangYposition + 1);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你已经达到公主旁边，按J键营救公主");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    //Console.SetCursorPosition(2, 42);
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");

                                    //等待输入J营救公主
                                    char helpPrincess = Console.ReadKey(true).KeyChar;
                                    if (helpPrincess == 'J' || helpPrincess == 'j')
                                    {
                                        isHelpPrincessSuccess = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition, tangYposition + 1);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                }

                            }
                            //到达上侧边界时候，不再往上移动
                            else
                            {
                                tangXposition = tangXposition;
                                tangYposition = tangYposition + 1;
                            }

                            break;

                        #endregion

                        #region CASE S
                        //case 's':
                        //case 'S':
                        //    tangXposition = tangXposition;
                        //    tangYposition = tangYposition + 1;

                        //    if (tangYposition <= 39)//城堡下边界判断
                        //    {
                        //        if (tangXposition == 50 && tangYposition == 27)
                        //        {
                        //            tangXposition = tangXposition;
                        //            tangYposition = tangYposition - 1;
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            if ((tangXposition == 50 && tangYposition == 26) || (tangXposition == 48 && tangYposition == 27) || (tangXposition == 52 && tangYposition == 27))
                        //            {
                        //                Console.SetCursorPosition(2, 41);
                        //                Console.ForegroundColor = ConsoleColor.White;
                        //                Console.WriteLine("开始和Boss战斗，按J键继续");
                        //                Console.SetCursorPosition(2, 42);
                        //                Console.WriteLine("你的当前血量为：{0}", tangHp);
                        //                Console.SetCursorPosition(2, 43);
                        //                Console.WriteLine("boss的当前血量为：{0}", bossHp);

                        //            }
                        //            else
                        //            {
                        //                Console.SetCursorPosition(2, 41);
                        //                Console.ForegroundColor = ConsoleColor.Black;
                        //                Console.WriteLine("开始和Boss战斗，按J键继续");
                        //                Console.SetCursorPosition(2, 42);
                        //                Console.WriteLine("你的当前血量为：{0}", tangHp);
                        //                Console.SetCursorPosition(2, 43);
                        //                Console.WriteLine("boss的当前血量为：{0}", bossHp);
                        //            }

                        //            Console.ForegroundColor = ConsoleColor.Black;
                        //            Console.SetCursorPosition(tangXposition, tangYposition - 1);
                        //            Console.Write("  ");
                        //            //tangXposition = tangXposition;
                        //            //tangYposition = tangYposition + 1;
                        //            Console.SetCursorPosition(tangXposition, tangYposition);
                        //            Console.ForegroundColor = ConsoleColor.Yellow;
                        //            Console.Write("●");
                        //        }

                        //    }
                        //    else
                        //    {
                        //        tangXposition = tangXposition;
                        //        tangYposition = tangYposition - 1;
                        //    }

                        //    break;
                        #endregion

                        #region CASE SS

                        case 's':
                        case 'S':
                            //假设移动，移动后光标的新位置
                            tangXposition = tangXposition;
                            tangYposition = tangYposition + 1;

                            //城堡下边界判断,同时判断是否已经打怪成功，并进入完成打怪
                            if (tangYposition <= 39 && isSuccess == 0)
                            {

                                //判断如果下一个位置是boss位置，则无法移动唐老师，并且光标位置归为移动前位置
                                if (tangXposition == 50 && tangYposition == 27)
                                {
                                    tangXposition = tangXposition;
                                    tangYposition = tangYposition - 1;

                                    break;
                                }
                                else
                                {
                                    //打怪位置判断(怪物上边位置)
                                    if ((tangXposition == 50 && tangYposition == 26) || (tangXposition == 48 && tangYposition == 27) || (tangXposition == 52 && tangYposition == 27))
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("                                       ");
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);

                                    }
                                    //如果离开打怪位置，信息区则无输出
                                    else
                                    {
                                        Console.SetCursorPosition(2, 41);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("开始和Boss战斗，按J键继续");
                                        Console.SetCursorPosition(2, 42);
                                        Console.WriteLine("你的当前血量为：{0}", tangHp);
                                        Console.SetCursorPosition(2, 43);
                                        Console.WriteLine("boss的当前血量为：{0}", bossHp);
                                    }

                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition, tangYposition - 1);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    //tangXposition = tangXposition - 2;
                                    //tangYposition = tangYposition;
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    if ((tangXposition == 50 && tangYposition == 26) || (tangXposition == 48 && tangYposition == 27) || (tangXposition == 52 && tangYposition == 27))
                                    {
                                        //持续打boss
                                        while (true)
                                        {
                                            char beatInput = Console.ReadKey(true).KeyChar;
                                            if (beatInput == 'J' || gameInput == 'j')
                                            {
                                                Random r = new Random();
                                                int attackTang = r.Next(100);
                                                int attackBoss = r.Next(1, 10);
                                                bossHp = bossHp - attackTang;
                                                tangHp = tangHp - attackBoss;
                                                //战斗中
                                                if (bossHp >= 0 && tangHp >= 0)
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("开始和Boss战斗，按J键继续");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你对boss造成{0}点伤害，boss剩余血量为{1}", attackTang, bossHp);
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("boss对你造成{0}点伤害，你的剩余血量{1}", attackBoss, tangHp);
                                                }
                                                //唐老师战斗胜利
                                                else if (bossHp < 0 && tangHp >= 0)
                                                {

                                                    //更新战胜boss标记
                                                    isSuccess = 1;

                                                    //清除boss显示
                                                    Console.SetCursorPosition(50, 27);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("  ");

                                                    //打印战胜boss信息
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("前往公主身边按J键营救公主");

                                                    //除掉第三行原先遗留显示的信息
                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    //绘制公主
                                                    Console.SetCursorPosition(58, 6);
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine("♀");

                                                    break;
                                                }
                                                //唐老师战败显示，目前只能退出游戏
                                                else
                                                {
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");
                                                    Console.SetCursorPosition(2, 41);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("你已战败按J键关闭游戏");

                                                    Console.SetCursorPosition(2, 42);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    Console.SetCursorPosition(2, 43);
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("                                       ");

                                                    char closeGame = Console.ReadKey(true).KeyChar;
                                                    if (closeGame == 'j' || closeGame == 'J')
                                                    {
                                                        Environment.Exit(0);

                                                    }

                                                }

                                            }
                                            else
                                            {

                                                break;
                                            }
                                        }
                                    }


                                }

                            }
                            //战胜了boss情况下的移动
                            //公主的位置(58,6)，公主周围坐标，右(60,6)、左(56,6)、上(58,5)、下(58,7)
                            else if (tangYposition >= 2 && isSuccess == 1)
                            {
                                if ((tangXposition == 58 && tangYposition == 5) || (tangXposition == 56 && tangYposition == 6) || (tangXposition == 60 && tangYposition == 6))
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition, tangYposition - 1);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你已经达到公主旁边，按J键营救公主");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    //Console.SetCursorPosition(2, 42);
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");

                                    //等待输入J营救公主
                                    char helpPrincess = Console.ReadKey(true).KeyChar;
                                    if (helpPrincess == 'J' || helpPrincess == 'j')
                                    {
                                        isHelpPrincessSuccess = 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    //移动前把原先的位置用黑色空格抹除
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(tangXposition, tangYposition - 1);
                                    Console.Write("  ");
                                    //在移动到的新位置打印唐老师圆形
                                    Console.SetCursorPosition(tangXposition, tangYposition);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("●");

                                    //刷新信息输出区战胜boss的信息，以免移动的时候被其他信息干扰显示
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 41);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("你战胜了boss，快去营救公主吧");

                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                    Console.SetCursorPosition(2, 42);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("前往公主身边按J键营救公主");

                                    //除掉第三行原先遗留显示的信息
                                    Console.SetCursorPosition(2, 43);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                       ");
                                }

                            }
                            //到达下侧边界时候，不再往下移动
                            else
                            {
                                tangXposition = tangXposition;
                                tangYposition = tangYposition - 1;
                            }

                            break;

                            #endregion

                    }
                    if (isHelpPrincessSuccess == 1)
                    {
                        break;
                    }

                }

                #endregion

                #region GameOver界面
                //GameOver界面
                //1.初始设置
                //清屏
                Console.Clear();

                //隐藏光标
                Console.CursorVisible = false;

                //设置光标位置-绘制游戏大标题
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(47, 7);
                Console.WriteLine("GameOver");
                Console.SetCursorPosition(47, 8);
                Console.WriteLine("英雄救美");

                //设置光标位置-绘制开始游戏
                Console.SetCursorPosition(45, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("回到开始界面");

                //设置光标位置-绘制退出游戏
                Console.SetCursorPosition(47, 14);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("退出游戏");

                //通过设置字体颜色让控制台自动输出的信息不显示
                Console.ForegroundColor = ConsoleColor.Black;

                //2.循环检测检测输入，并变换颜色
                //疑问：如何获取小键盘上的上下箭头，下面的程序只是用了W和s上下移动选择选项
                
                //默认停留在的选项标志，1表示选中，0表示未选中
                int isBack = 1;
                int isExit = 0;

                while (true)
                {

                    char xInput = Console.ReadKey(true).KeyChar;
                    int xInputEnter = Convert.ToInt32(xInput);

                    switch (xInput)
                    {
                        case 'w':
                        case 'W':
                            //case '↑':
                            Console.SetCursorPosition(45, 11);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("回到开始界面");

                            Console.SetCursorPosition(47, 14);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("退出游戏");

                            Console.ForegroundColor = ConsoleColor.Black;
                            isBack= 1;
                            isExit= 0;
                            break;

                        case 's':
                        case 'S':
                            //case '↓':
                            Console.SetCursorPosition(45, 11);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("回到开始界面");

                            Console.SetCursorPosition(47, 14);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("退出游戏");

                            Console.ForegroundColor = ConsoleColor.Black;
                            isBack = 0;
                            isExit = 1;
                            break;

                            //default:
                            //    break;

                    }

                    if (xInputEnter == 13)
                    {
                        if (isBack == 1)
                        {
                            break;
                        }
                        else if (isExit == 1)
                        {
                            Environment.Exit(0);
                        }
                    }
                    //回车执行进入或者退出游戏

                    //方法一：获取回车键盘

                    //ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    //if (keyInfo.Key == ConsoleKey.Enter && (xInput == 'w' || xInput == 'W'))
                    //{
                    //    isBackToStartPage = 1;
                    //    break;
                    //}
                    //else if (keyInfo.Key == ConsoleKey.Enter && (xInput == 's' || xInput == 'S'))
                    //{
                    //    Environment.Exit(0);
                    //}



                }

                #endregion
            }
//git test delete

        }
    }
}
