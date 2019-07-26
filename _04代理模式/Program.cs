using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Girl sGirl = new Girl("sx");

            Proxy mm = new Proxy(sGirl);

            mm.GiveChocolate();
            mm.GiveDolls();
            mm.GiveFlowers();

            RealProxy _realProxy = new RealProxy();
            _realProxy.Request();
        }
    }

    public class Pursuit : IGiveGift
    {
        private Girl _girl;

        /// <inheritdoc />
        public Pursuit(Girl girl)
        {
            _girl = girl;
        }

        /// <inheritdoc />
        public void GiveDolls()
        {

            Console.WriteLine("洋娃娃  ");
        }

        /// <inheritdoc />
        public void GiveFlowers()
        {
            Console.WriteLine("花  ");

        }

        /// <inheritdoc />
        public void GiveChocolate()
        {
            Console.WriteLine("巧克力  ");

        }
    }

    public interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();

    }

    public class Proxy : IGiveGift
    {
        private Pursuit boy;

        /// <inheritdoc />
        public Proxy(Girl girl)
        {
            boy = new Pursuit(girl);
        }

        /// <inheritdoc />


        /// <inheritdoc />
        public void GiveDolls()
        {
            Console.Write("GG叫我送你 ");
            boy.GiveDolls();
        }

        /// <inheritdoc />
        public void GiveFlowers()
        {
            Console.Write("GG叫我送你 ");
            boy.GiveFlowers();
        }

        /// <inheritdoc />
        public void GiveChocolate()
        {
            Console.Write("GG叫我送你 ");
            boy.GiveChocolate();
        }
    }
    //被追求者
    public class Girl
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <inheritdoc />
        public Girl(string name)
        {
            this.name = name;
        }
    }

    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        /// <inheritdoc />
        public override void Request()
        {
            Console.WriteLine("请求");
        }
    }

    public class RealProxy : Subject
    {
        private RealSubject _realSubject;
        public RealProxy(RealSubject subject)
        {
            _realSubject = subject;
        }

        public RealProxy()
        {

        }

        /// <inheritdoc />
        public override void Request()
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }

}

