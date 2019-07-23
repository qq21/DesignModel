using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 可用在 实现状态机，forerch 迭代机制 等....
/// </summary>
namespace _16迭代器模式
{
    /// <summary>
    /// 当需要对聚集多种方式遍历时，
    /// 迭代器模式 就是分离了集合对象的遍历行为，抽象出一个迭代器类来负责，
    /// 这样可以做到部暴露集合的内部结构，又可让外部代码透明地访问集合内部的数据
    /// </summary>
    class Program
    {
        static void Main(string[] args) 
        {
             
           ConcretedAggregate bus=new ConcretedAggregate();//公交车

           for (int i = 0; i <10; i++)
           {

               bus[i] = "甲";

           } 

            Iterator conductor =new ConcretedIterator(bus); //售票员

           object item= conductor.First();
           while (!conductor.IsDown()) //一个一个收票
           {
               Console.WriteLine(item);
               conductor.Next();
           }

           string temp = "1.1.1.1";
           Console.WriteLine(temp.Replace(".", "[.]")); 
        }
    }

    public  abstract  class Iterator
    {
        public abstract object Next();
        public abstract  object First();
        public abstract object GetCurrent();
        public abstract bool IsDown();
    }


    public abstract class Aggregate
    {
       public abstract Iterator CreateIterator();
    }

    public class  ConcretedIterator:Iterator
    {
        private ConcretedAggregate concretedAggregate;

        private int count=0;

        /// <inheritdoc />
        public ConcretedIterator(ConcretedAggregate concretedAggregate)
        {
            this.concretedAggregate = concretedAggregate;
        }

        /// <inheritdoc />
        public override object Next()
        {
            if (count>=concretedAggregate.Count)
            {
                return false;
            }

            count++;
            return concretedAggregate[count];
        }

        /// <inheritdoc />
        public override object First()
        {
            return concretedAggregate[0];
        }

        /// <inheritdoc />
        public override object GetCurrent()
        {
            return concretedAggregate[count];
        }

        /// <inheritdoc />
        public override bool IsDown()
        {
            return count >= concretedAggregate.Count;
        }
    }

    public  class ConcreteItertatorDesc:Iterator
    {
        private ConcretedAggregate concretedAggregate;
        private int count=0;
        /// <inheritdoc />
        public ConcreteItertatorDesc(ConcretedAggregate concretedAggregate)
        {
            this.concretedAggregate = concretedAggregate;
            this.count = concretedAggregate.Count;
        }

        /// <inheritdoc />
        public override object Next()
        {
            if (count>=0)
            {
                object o=  concretedAggregate[count];
                count--;
                return o;
            }

            return null;
        }

        /// <inheritdoc />
        public override object First()
        {
            return concretedAggregate[0];
        }

        /// <inheritdoc />
        public override object GetCurrent()
        {
            if (count>=0)
            {
                return concretedAggregate[count];
            }

            return null;
        }

        /// <inheritdoc />
        public override bool IsDown()
        {
            return count == -1;
        }
    }

    public class  ConcretedAggregate:Aggregate
    {
        private List<object> items = new List<object>();

        /// <inheritdoc />
        public override Iterator CreateIterator()
        {
             return  new  ConcretedIterator(this);
        }
       
        public object this[int index] {
             get
             {
                 if (index<items.Count)
                 {
                     return items[index];

                }

                 return null;
             }
             set { items.Insert(index,value); }
        }

         public int Count
         {
             get => items.Count;
         }
    }
}
