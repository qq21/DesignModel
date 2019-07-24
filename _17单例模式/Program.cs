using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine(A.Instance.volume);  
          
          
        }
    }
    /// <summary>
    /// 泛型单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleTon<T> where T : new()
    {
        private static  T  m_instance;

        private static object lockObj=new object();
        public static T Instance
        {
            get
            {
                if (m_instance==null)
                {
                    lock (lockObj)
                    {
                        if (m_instance==null)
                        {
                            m_instance =  new T();
                        }
                    }
                }

                return m_instance;
            }
        }

    }

    public class A : SingleTon<A>
    {
        public int volume;
        /// <inheritdoc />
        public A(int volume)
        {
            this.volume = volume;
            Console.WriteLine("Im birth");
        }

        public EventHandler e;
        public void Ctor()
        {
            if (e!=null)
            {  
            }
        }

        public A()
        {
            Ctor();
            Console.WriteLine("Im birth");

        }
    }

    /// <summary>
    /// 在内存里将自己实例化,称之为懒汉式单例  参见SingleTon
    /// </summary>
    public class LazySingleTon
    {
        private  readonly static  LazySingleTon instance=new LazySingleTon();

        /// <inheritdoc />
        public LazySingleTon()
        {
        }

        public static LazySingleTon Instance => instance;
    }

    
}
