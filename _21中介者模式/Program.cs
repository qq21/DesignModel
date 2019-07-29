 using System;
using System.Collections.Generic;
using System.Linq;
 using System.Runtime.Remoting.Contexts;
 using System.Text;
using System.Threading.Tasks;

namespace _21中介者模式
{
    /// <summary>
    /// 中介者很容易在系统中应用，也很容易在系统中吴用，
    /// 当系统出现了 多对多 交互复杂的对象群时，不要急于使用中介者模式，
    /// 要先反思系统在设计上是否合理
    /// 一般应用于一组对象以定义良好但是复杂的方式进行通信的场合。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator=new Mediator();
            ConcreteAColleague concreteA=new ConcreteAColleague(mediator);
            ConcreateBColleague concreateB=new ConcreateBColleague(mediator);
            ConcreateCColleague concreateC=new ConcreateCColleague(mediator);
            concreteA.Send("新人报道，请多多包涵");
            concreateB.Send("你好");
            concreateC.Send("你好");
        }
    }

    public abstract class Colleague
    {
        protected Mediator _mediator;

        /// <inheritdoc />
        protected Colleague(Mediator mediator)
        {
            _mediator = mediator;
            _mediator.AddColleague(this);

        }

        public virtual void Send(string str)
        {
            
             _mediator.Send(str,this);
        }

        public virtual void Notify(string str)
        {
        }
    }

    public class ConcreteAColleague:Colleague
    {
        /// <inheritdoc />
        public ConcreteAColleague(Mediator mediator) : base(mediator)
        {
        }

        /// <inheritdoc />
       
        /// <inheritdoc />
        public override void Notify(string str)
        {
           Console.WriteLine("同事A收到消息："+str);
        }
    }

    public class ConcreateBColleague:Colleague
    {
        /// <inheritdoc />
        public ConcreateBColleague(Mediator mediator) : base(mediator)
        {
        }
       
        /// <inheritdoc />
        public override void Notify(string str)
        {
            Console.WriteLine("同事B收到消息"+str);
        }
    }

    public  class  ConcreateCColleague:Colleague
    {
        /// <inheritdoc />
        public ConcreateCColleague(Mediator mediator) : base(mediator)
        {

        }
        public override void Notify(string str)
        {
            Console.WriteLine("同事C收到消息" + str);
        }

    }

    /// <summary>
    /// 由于ConcreteMediator 控制了集中化，把交互复杂性变成了中介者的交互复杂性
    /// 使得 中介者会比任何一个ConcreteColleague都复杂
    /// </summary>
    public class Mediator
    {
     
        /// <summary>
        /// list
        /// </summary>
        private List<Colleague> _colleagues;

        public void Send(string str,Colleague c)
        {
            foreach (var clg in _colleagues)
            {
                if (clg!=c)
                {
                    clg.Notify(str);
                }
                 
            }
        }

        /// <inheritdoc />
        public Mediator()
        {
           _colleagues=new List<Colleague>();
        }

        public void AddColleague(Colleague C)
        {
            _colleagues.Add(C);
        }

    }




}
