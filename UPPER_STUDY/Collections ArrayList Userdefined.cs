using System;
using System.Collections;

namespace CollectionApp
{
    class MyComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            // 自定义比较规则
            // 如果x,y都是int，那么按正常流程比较
            // 如果其中一个不是int，那么认为不是int的值小
            // 如果都不是int，那么认为他们相等
            if (x is int)
            {
                if (y is int)
                {
                    if ((int)x < (int)y) return -1;
                    if ((int)x == (int)y) return 0;
                    return 1;
                }
                return 1;
            }
            if (y is int) return -1;
                return 0;
        }
    }

    class Entry
    {
        static void Print(ArrayList l)
        {
            Console.WriteLine("\t大小能力:{0}   实际大小：{1}", l.Capacity, l.Count);
            Console.Write("\t内容:");
            foreach (object obj in l)
            Console.Write("{0} ", obj);
            Console.Write("\r\n");
        }
        static void Main()
        {
            ArrayList l = new ArrayList();
            Console.WriteLine("添加一些不都是Int的数据:");
            l.Add(22);
            l.Add(77);
            l.Add("abc");
            l.Add(33);
            Print(l);
            Console.WriteLine("排序：");
            l.Sort(new MyComparer());
            Print(l);
            Console.ReadKey();
        }
    }
}