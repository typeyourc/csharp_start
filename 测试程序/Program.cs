namespace 测试程序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.CursorVisible = false;
            int xxInput = Console.ReadKey(true).KeyChar;
            //Console.Write(xxInput);
            Console.WriteLine(Convert.ToInt32(xxInput));

            //Console.WriteLine(Convert.ToInt32(Console.ReadKey(true).KeyChar));


            //Console.WriteLine("测试程序");
            //合适的窗口尺寸，宽度和高度
            //Console.SetWindowSize(100, 51);
            //Console.SetBufferSize(100, 51);


            //////ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //////Console.WriteLine(keyInfo.Key);

            ////Environment.Exit(0);
            //Console.Clear();
            ////Console.ForegroundColor = ConsoleColor.Red;
            ////Console.CursorVisible = false;
            ////for (int i = 0; i <= 45; i++)
            ////{
            ////    for (int j = 0; j <= 98; j += 2)
            ////    {
            ////        if (i == 0 || i == 40 || i == 45)
            ////        {
            ////            Console.SetCursorPosition(j, i);
            ////            Console.Write('■');
            ////        }
            ////        else
            ////        {
            ////            if (j == 0 || j == 98) 
            ////            {
            ////                Console.SetCursorPosition(j, i);
            ////                Console.Write('■');
            ////            }
            ////        }

            ////    }
            ////}


            ////int a = Console.Read();
            //Console.CursorVisible = false;
            //Console.WriteLine(Convert.ToInt32(Console.ReadKey(true).KeyChar));
        }
    }
}