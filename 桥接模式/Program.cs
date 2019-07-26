using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
           PhoneBrand m=new PhonM(new PhoneGame());
           m.Run();
           PhoneBrand n=new PhoneN(new PhoneAdress());
           n.Run();
          
           People sourthPeople=new NorthPeople(new Jacket(200,"棉大衣"));
           sourthPeople.Wear();
           People NorthPeople=new NorthPeople(new Trouser(100,"涤纶牛仔裤"));
            NorthPeople.Wear();
        }

    }

    public abstract class PhonSoft
    {
        public abstract void Run();
        public abstract void Exit();
    }

    public class PhoneGame : PhonSoft
    {
        /// <inheritdoc />
        public override void Run()
        {
          Console.WriteLine("游戏启动");
        }

        /// <inheritdoc />
        public override void Exit()
        {
          Console.WriteLine("游戏退出");

        }
    }

    public class PhoneAdress : PhonSoft
    {
        /// <inheritdoc />
        public override void Run()
        {
            Console.WriteLine("通讯录启动");
        }

        /// <inheritdoc />
        public override void Exit()
        {
            Console.WriteLine("通讯录退出");

        }
    }

    public abstract class PhoneBrand
    {
        protected List<PhonSoft> _phonSofts;

     

        /// <inheritdoc />
        protected PhoneBrand(PhonSoft soft)
        {
            _phonSofts = new List<PhonSoft>();

            _phonSofts.Add(soft);
        }

        public virtual void Run()
        {
            if (_phonSofts.Count > 0)
            {
                _phonSofts[0].Run();
            }
        }
    }

    public class PhoneN : PhoneBrand
    {
        /// <inheritdoc />
        public PhoneN(PhonSoft soft) : base(soft)
        {
        }
    }

    public class PhonM : PhoneBrand
    {
        /// <inheritdoc />
        public PhonM(PhonSoft soft) : base(soft)
        {
        }
    }

    public abstract class Implementor
    {
        public abstract void Operation();
    }

    public class ConcreteImplementorA : Implementor
    {
        /// <inheritdoc />
        public override void Operation()
        {
            Console.WriteLine("操作1");
        }
    }
    public class  ConcreteImplementorB:Implementor
    {
        /// <inheritdoc />
        public override void Operation()
        {
            Console.WriteLine("操作B");
        }
    }
    public  class ConcreteImplementorC:Implementor
    {
        /// <inheritdoc />
        public override void Operation()
        {
            Console.WriteLine("操作C");
        }
    }

    public abstract class Abstraction
    {
        protected Implementor _implementor;

        /// <inheritdoc />
        protected Abstraction(Implementor implementor)
        {
            _implementor = implementor;
        }

        public virtual void Operation()
        {
            _implementor.Operation();
        }
    }

    public abstract class RefineAbstraction : Abstraction
    {
        /// <inheritdoc />
        protected RefineAbstraction(Implementor implementor) : base(implementor)
        {
        }
    }
}
