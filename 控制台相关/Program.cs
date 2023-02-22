namespace 控制台相关
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("控制台");

            // Console.Clear();

            //Console.BackgroundColor = ConsoleColor.White;

            //Console.SetWindowSize(100, 50);
            //Console.SetBufferSize(1000, 500);

            //Console.SetCursorPosition(10, 5);
            //Console.WriteLine("123");

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("123");


            //初始设定窗口和缓冲区大小
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(200, 100);

            //初始设置光标不可见
            Console.CursorVisible = false;

            //初始设置光标位置
            int xPosition = 0;
            int yPosition = 0;
            Console.SetCursorPosition(xPosition, yPosition);

            //初始设置缓冲区背景红色
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();

            //初始设置输入颜色黄色
            Console.ForegroundColor = ConsoleColor.Yellow;

            //设置初始黄色方块

            //1.背景切换成黄色
            Console.BackgroundColor = ConsoleColor.Yellow;


            //2.初始黄色方块打印
            Console.Write('A');
            Console.Write('A');

            //测试输入黄色
            //string iputTest = Console.ReadLine();
            //Console.Write(" ");
            //while (true)
            //{
            //    //背景变换测试
            //    Console.BackgroundColor = ConsoleColor.Yellow;

            //    //获得输入的字符并且不显示
            //    char input = Console.ReadKey(true).KeyChar;
            //    Console.Write(input);

            //}




            //方块移动模块
            while (true)
            {

                //背景变换测试
                Console.BackgroundColor = ConsoleColor.Yellow;

                //获得输入的字符并且不显示
                char input = Console.ReadKey(true).KeyChar;

                switch (input)
                {
                    case 'a':
                        if (xPosition <= 1)
                        {
                            //Console.WriteLine("已经到达左方边界");
                        }
                        else
                        {
                            //设置缓冲区背景红色
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();

                            //设置输入颜色黄色
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //背景变换成黄色测试
                            Console.BackgroundColor = ConsoleColor.Yellow;



                            xPosition = xPosition - 2;
                            yPosition = yPosition;
                            Console.SetCursorPosition(xPosition, yPosition);
                            Console.Write(input);
                            Console.Write(input);
                        }

                        break;
                    case 's':
                        if (yPosition >= 99)
                        {
                            //Console.WriteLine("已经到达下方边界");
                        }
                        else
                        {
                            //设置缓冲区背景红色
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();

                            //设置输入颜色黄色
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //背景变换成黄色测试
                            Console.BackgroundColor = ConsoleColor.Yellow;


                            yPosition = yPosition + 1;
                            xPosition = xPosition;
                            Console.SetCursorPosition(xPosition, yPosition);
                            Console.Write(input);
                            Console.Write(input);

                        }

                        break;
                    case 'd':
                        if (xPosition >= 197)
                        {
                            //Console.WriteLine("已经到达右方边界");
                        }
                        else
                        {
                            //设置缓冲区背景红色
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();

                            //设置输入颜色黄色
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //背景变换成黄色测试
                            Console.BackgroundColor = ConsoleColor.Yellow;



                            xPosition = xPosition + 2;
                            yPosition = yPosition;
                            Console.SetCursorPosition(xPosition, yPosition);
                            Console.Write(input);
                            Console.Write(input);

                        }

                        break;
                    case 'w':
                        if (yPosition <= 0)
                        {
                            //Console.WriteLine("已经到达上方边界");
                        }
                        else
                        {
                            //设置缓冲区背景红色
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();

                            //设置输入颜色黄色
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //背景变换成黄色测试
                            Console.BackgroundColor = ConsoleColor.Yellow;


                            yPosition = yPosition - 1;
                            xPosition = xPosition;
                            Console.SetCursorPosition(xPosition, yPosition);
                            Console.Write(input);
                            Console.Write(input);

                        }

                        break;
                    default: break;
                }



            }
        }
    }
}