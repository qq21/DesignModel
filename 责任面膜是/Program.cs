using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 责任链模式
{
    /// <summary>
    /// 当客户提交一个请求时，请求是沿链传递直到有个符合它的对象，处理它
    /// </summary>
    class Program
    {
        /// <summary>
        /// 使得接收者和发送者都没有对方的明确信息，且链中的对象自己也并不知道链的结构，
        /// 结果是职责链可简化对象相互连接。它们仅仅需要一个指向其后继者的引用，不需保持它所选接受者的引用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
             ConcreteAHandler concreteAHandler=new ConcreteAHandler();
             concreteAHandler.SetSuccessor(new ConCreteBHandler()).SetSuccessor(new ConCreteCHandler()).SetSuccessor(new ConCreteDHandler());

            int[] nums={10,20,30,2,11,22,10,2,33,32};

            foreach (var  n in nums)
            {
                concreteAHandler.handle(n);
            }

            Administrator m=new Manager(new ChiefInspector(new GeneralManager(null,5000),1000 ),500 );

            int[] nums2 = { 10, 20, 30, 2, 11, 22, 10, 2, 33, 32 };

            foreach (var n in nums)
            {
                 m.HandleRequest(n*100);
            }

        }
    }

    public class Request
    {
         
    }

    public abstract class Ihandler
    {
        protected Ihandler _sucessor;
        public abstract void handle(int requestLevel);


        public Ihandler SetSuccessor(Ihandler _ihandler)
        {
            this._sucessor = _ihandler;
            return _sucessor;
        }
    }

    public class ConcreteAHandler:Ihandler
    {
        /// <inheritdoc />
        public override void handle(int requestLevel)
        {
            if (requestLevel>10)
            {
                Console.WriteLine($"{this.GetType().Name}权限不够,转移第二个");
                if (_sucessor != null)
                    _sucessor.handle(requestLevel);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}正在处理");
            }
        }
    }
    public  class  ConCreteBHandler:Ihandler
    {
        /// <inheritdoc />
        public override void handle(int requestLevel)
        {
            if (requestLevel>20)
            {
                Console.WriteLine($"{this.GetType().Name}权限不够,当前是2级");
                if (_sucessor!=null)
                _sucessor.handle(requestLevel);
            }
            else
            {
               Console.WriteLine($"{this.GetType().Name}正在处理");
            }
        }
    }
    public class ConCreteCHandler : Ihandler
    {
        /// <inheritdoc />
        public override void handle(int requestLevel)
        {
            if (requestLevel > 30)
            {
                Console.WriteLine($"{this.GetType().Name}权限不够,当前是3级");
                if (_sucessor!=null)
                {
                _sucessor.handle(requestLevel);

                }
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}正在处理");
            }
        }
    }
    public class ConCreteDHandler : Ihandler
    {
        /// <inheritdoc />
        public override void handle(int requestLevel)
        {
            if (requestLevel > 40)
            {
                Console.WriteLine($"{this.GetType().Name}权限不够,当前是4级");
                if (_sucessor != null)
                {
                    _sucessor.handle(requestLevel);

                }
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name}正在处理");
            }
        }
    }


    public abstract class   Administrator
    {
        protected Administrator _superior;
        /// <summary>
        /// 运算经费
        /// </summary>
        protected int price;
        public Administrator SetSuccessor(Administrator m)
        {
            this._superior = m;
            return _superior;
        }

        /// <inheritdoc />
        protected Administrator(Administrator superior, int price)
        {
            this._superior = superior;
            this.price = price;
        }

        /// <summary>
        /// 处理请求
        /// </summary>
        public virtual void HandleRequest(int money)
        {
            if (money<=price)
            {
                Console.WriteLine(this.GetType().Name+":申请成功");
            }
            else
            {
                _superior.HandleRequest(money);
                Console.WriteLine("向上级申请");
            }
        }

    }

    public  class  Manager:Administrator
    {
        /// <inheritdoc />
        public Manager(Administrator superior, int price) : base(superior, price)
        { 
        }
    }

    public class ChiefInspector:Administrator
    {
        /// <inheritdoc />
        public ChiefInspector(Administrator superior, int price) : base(superior, price)
        { 
        }
    }

    public class GeneralManager : Administrator
    {
        /// <inheritdoc />
        public GeneralManager(Administrator superior, int price) : base(superior, price)
        { 
        }
    }
    
}
