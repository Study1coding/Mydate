//c#cdoding 框架如下
using System;
namespace shangji2
{
    class Mydate
    {
        private int month;
        private int day;
        private int year;
        public Mydate()
        {

            month = DateTime.Now.Month;
            day = DateTime.Now.Day;
            year = DateTime.Now.Year;
        }
        public void Display()
        {
            Console.WriteLine($"Now is {month}/{day}/{year}");
        }
        public void Setdate()
        {
            Console.WriteLine("please enter year: ");
           bool a = Int32.TryParse(Console.ReadLine(),out year); 
            Console.WriteLine("please enter month: ");
            bool b = Int32.TryParse(Console.ReadLine(), out month);
            Console.WriteLine("please enter day: ");
            bool c = Int32.TryParse(Console.ReadLine(), out day);
            if (!(c&&b&&c))
            {
                Console.WriteLine("input error!");
                Environment.Exit(0);
            }
            Test01();
            Test02();
            Test03();
        }
        public void Test01()//先限制在1-31
        {
            if (month < 1 || month > 12 || day< 1 || day > 31 || year < 1)//假设从公元后开始算起
            {
                Console.WriteLine("input error!");
                Environment.Exit(0);
            }
        }
        //小月超过30
        public void Test02()
        {
            if ((month == 2)||( month == 4 )||( month == 6 )||( month == 9)||(month==11))
            {
                if (day>30)
                {
                    Console.WriteLine("input error:not xiaoyue!");
                    Environment.Exit(0);
                }
            }
        }
        ////已判断为2月 只需判断闰年月
        public void Test03()
        { //再判断是否为29号、
            if (day==29) //若是继续下去
            { //调用闰年函数
                if (!((year % 4 == 0 && year % 100 != 0) || year % 400 == 0))
                {
                    Console.WriteLine("input error!");
                    Environment.Exit(0);
                }
                                        //若不为闰年 则error！ 
            }
        }
    }

    /*dataset框架：
    */
class Dateset
    {
       
        public Dateset()
        {    }
        public void Choose()
        {
            Console.WriteLine("Please select the feature to test: (just press the number before the option) ");
            Console.WriteLine("\t1: test\n\t2: quit");
            int i = 1;
            bool a = int.TryParse(Console.ReadLine(),out i);
            if (!a)
            {
                Console.WriteLine("input error!");
                Environment.Exit(0);
            }
            //假设Parse成功 往下进行 随后再补缺漏
         /*改成留下两个按钮
          * 测试or quit
          */
            switch (i)
            {
                case 1 :   Test();break; 
                case 2:     Environment.Exit(0);break;
                default: Console.WriteLine("input error!");break;

            }
            void Test()
            {   Mydate mydate=new Mydate ();
                mydate.Display();
                mydate.Setdate();
                mydate.Test01();
                mydate.Test02();
                mydate.Test03();
                Console.WriteLine("succeed!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            /*Main函数的框架是
             是否申请测试
                是实例化测试类对象 调Choose函数
            */
            Dateset dateset = new Dateset();
            while(true)
            {
                dateset.Choose();
            }
         
            //oneDate.Display();
            //Console.Read();
            Mydate oneDate = new Mydate();
            Console.WriteLine(oneDate);
            Console.ReadKey();
        }
    }
}
