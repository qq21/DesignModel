using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 为 子系统中的一组接口提供一个一致的界面， 此模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。
/// </summary>
namespace _08_外观模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //  客服端买股票  股民 
           Stock1 s1=new Stock1(10);
           Stock2 s2=new Stock2(20);
           Stock3 s3=new Stock3(40);

            // 模拟 买 基金
            Fund sFund=new Fund();
            sFund.Buy();
            sFund.Sell();
           //不需要 对 股票进行炒作，  只需要 炒作 基金，  由基金 去操作股票;

            //中介者 模式

            Facade facade=new Facade();
            //    外观模式  会把所有子系统  集合在一起，  然后 封装它们的方法，  外部 只要调用就好了。
            facade.MethodA();
            facade.MethodB();
             

           
        }
    }

    abstract class Stock
    {
        /// <inheritdoc />
        protected Stock(int price)
        {
            this.price = price;
        }

        public abstract void Buy();
        private int price;

        public int Price
        {
            get => price;
            set => price = value;
        }

        public virtual void Sell()
        {
            Console.WriteLine($"以{Price*Math.Round(1.5f)}价格卖出入");

        }
    }

    class Stock1:Stock
    {
        /// <inheritdoc />
        public Stock1(int price) : base(price)
        {
        }

        /// <inheritdoc />
        public override void Buy()
        {
            Console.WriteLine($"以{Price}价格买入");
        }
    }

    class Stock2:Stock
    {
        /// <inheritdoc />
        public Stock2(int price) : base(price)
        {
        }

        /// <inheritdoc />
        public override void Buy()
        {
            Console.WriteLine($"以{Price}价格买入");

        }
    }

    class Stock3:Stock
    {
        /// <inheritdoc />
        public Stock3(int price) : base(price)
        {
        }

        /// <inheritdoc />
        public override void Buy()
        {
            Console.WriteLine($"以{Price}价格买入");

        }
    }

    class  Fund
    {
        private Stock1 s1;
        private Stock2 s2;
        private Stock3 s3;

        /// <inheritdoc />
        public Fund(Stock1 s1, Stock2 s2, Stock3 s3)
        {
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
        }

        /// <inheritdoc />
        public Fund()
        {
            s1 = new Stock1(10);
            s2=new Stock2(20);
            s3=new Stock3(30);
        }

        public void Sell()
        {
            s1.Sell();
            s2.Sell();
            s3.Sell();
        }

        public void Buy()
        {s1.Buy();
        s2.Buy();
        s3.Buy();

        }
    }

    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("方法1");
        }
    }

    class SubSystemTweo
    {
        public void MethodTwo()
        {
            Console.WriteLine("方法2");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("方法3");
        }
    }
    /// <summary>
    /// 知道 哪些 子系统类负责处理请求，将客户的请求代理给适当的子系统对象
    /// </summary>
    class Facade
    {//了解所有子系统 方法 行为 ， 以便外部调用
        
        //子系统类集合，实现子系统的功能，处理Facade 对象指派的任务，注意子类中没有Facde的任何信息，即没有对Facade对象的引用
        private SubSystemOne systemOne;
        private SubSystemTweo systemTweo;
        private SubSystemThree stSystemThree;

         
        /// <inheritdoc />
        public Facade( )
        {
            systemOne =new SubSystemOne();
            systemTweo=new SubSystemTweo();
            stSystemThree=new SubSystemThree();
        }

        /// <inheritdoc />
        public Facade(SubSystemOne systemOne, SubSystemTweo systemTweo, SubSystemThree stSystemThree)
        {
            this.systemOne = systemOne;
            this.systemTweo = systemTweo;
            this.stSystemThree = stSystemThree;
        }

        public void MethodA()
        {
            systemOne.MethodOne();
            stSystemThree.MethodThree();
        }

        public void MethodB()
        {
            systemTweo.MethodTwo();
            stSystemThree.MethodThree();
        }

    }


}
