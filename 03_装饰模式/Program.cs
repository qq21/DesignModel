using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _03_装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
             BuildConcreteComponent();
             DecoratePerson();
        }

        public static void DecoratePerson()
        {

            Person son=new Person("son");
             Hat hat=new Hat();
             Briefs briefs=new Briefs();
             Tshit tshit=new Tshit();
             Pants pants=new Pants();

             Finery f=new Finery();
             
              f.Decorate(son); // 服装 装饰son
              briefs.Decorate(f);
              hat.Decorate(briefs); //存的是f的 装扮  
              tshit.Decorate(hat);
               pants.Decorate(tshit);  
                pants.Show();
        }

        public static void BuildConcreteComponent()
        {
            ConcreteComponent concreteComponent = new ConcreteComponent();
            DecoratorA _decoratorA = new DecoratorA();
            DecoratorB _decoratorB = new DecoratorB();

            _decoratorA.SetComponent(concreteComponent);
            _decoratorB.SetComponent(_decoratorA);
            _decoratorB.Operation();

        }
    }


    public abstract class Component
    {
        public abstract void Operation();

    }

    public class ConcreteComponent:Component
    {
        /// <inheritdoc />
        public override void Operation()
        {
           
        }
    }

    public class Decorator :Component
    {
        private Component _component;

        public void SetComponent(Component component)
        {
            this._component = component;
        }
       
        public override void Operation()
        {
            if (_component!=null)
            _component.Operation();
            
        }
    }

    public class DecoratorA : Decorator
    {
        private string _Coffer;
        /// <inheritdoc />
        public override void Operation()
        {
            _Coffer = "摩卡";
            base.Operation();
            Console.WriteLine(_Coffer+ "DecoratorA");
        }
    }

    public class DecoratorB : Decorator
    {
        public void AddBehaviour()
        {

            Console.WriteLine("加奶，加糖");
        }

        /// <inheritdoc />
        public override void Operation()
        {
            base.Operation();
            AddBehaviour();

        }
    }



    public class Person
    {
        private string m_name;

        /// <inheritdoc />
        public Person(string mName)
        {
            m_name = mName;
        }

        /// <inheritdoc />
        public Person()
        {
        }

        public virtual void Show()
        {
        }
    }

    public class Finery : Person
    {
       protected Person _person;

        public void Decorate(Person person)
        {
            this._person = person;
        }

        /// <inheritdoc />
        public override void Show()
        {
            if (_person!=null)
            {
                _person.Show();
            }

        }
    }

    public class Tshit : Finery
    {
        /// <inheritdoc />
        public override void Show()
        {
            Console.WriteLine("T-shit 穿衬衫");

            base.Show();
        }
    }

    public class Hat : Finery
    {
        /// <inheritdoc />
        public override void Show()
        {
            Console.WriteLine("Hat 戴帽子");
            base.Show();
        }
    }

    public class Briefs : Finery
    {
        /// <inheritdoc />
        public override void Show()
        {
            Console.WriteLine("briefs 穿小内内");
            base.Show();
        }
    }

    public class Pants : Finery
    {
        /// <inheritdoc />
        public override void Show()
        {
            Console.WriteLine("Pants 传裤子");
            base.Show();
        }
    }
}
