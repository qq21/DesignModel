using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13适配器模式
{
    //Adapter   适配器模式 
    //将一个类的接口 转换成客户希望的另外一个接口，Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作
    //参考电源适配器等等...

   //系统的数据和行为都正确 ，但接口不符时，我们应该考虑用适配器，目的是使控制范围之外的一个原有对象与某个接口匹配
   //适配器模式主要应用于希望复用一些现存的类，但是接口又与复用环境要求不一致的情况
    class Program
    {
        static void Main(string[] args)
        { 
             Targer targer=new Adapter();
             targer.Request(); //
             Console.Read();

             Player b=new ForWards("巴蒂尔");
            b.Attack();
            Player m=new Guards("麦克格雷迪");
            b.Defense();
            Player y=new Center("姚明");
            y.Attack();
            //姚明不太会英语，因此教授通过 翻译 告诉姚明进攻
            Player transPlayer=new Translator("姚明的翻译");
            transPlayer.Attack();
            transPlayer.Defense();


            ///.Net中的应用
            /// DataAdapter DataAdapter用作DataSet和数据源之间的适配器以便检索和保存数据.DataAdapter通过映射Fill
            /// (这更改了DataSet中的数据以便与数据源中的数据相匹配)和Update (这更改了数据源中的数据以便与DataSet)

        }

    }
    //类适配器模式和对象适配模式
    public class Targer
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求");
        }
    }

    //何时使用 适配器模式  连个类所作的事情相同或相似，但是具有不同的接口时要使用它
    //在双方都不太容易修改的时候再使用 适配器模式适配
    public class Adaptee
    {
        public void SpecificRequest()
        {
           Console.WriteLine("特殊请求");
        }
    }

    public class Adapter:Targer  //适配 器，适配Target
    {
        private Adaptee adaptee=new Adaptee();

        /// <inheritdoc />
        public override void Request()
        {
            // 根据请求 情况 使用 不同的request方法
            adaptee.SpecificRequest();
        }
    }

    abstract class Player
    {
        protected string name;

        /// <inheritdoc />
        protected Player(string name)
        {
            this.name = name;
        }

        public abstract void Attack();
        public abstract void Defense();
    }

    class ForWards : Player
    {
        /// <inheritdoc />
        public ForWards(string name) : base(name)
        {
        }

        /// <inheritdoc />
        public override void Attack()
        {
             Console.WriteLine($"前锋{name}进攻");
        }

        /// <inheritdoc />
        public override void Defense()
        {
             Console.WriteLine($"前锋{name}防守");

        }
    }

    class Center:Player
    {
        /// <inheritdoc />
        public Center(string name) : base(name)
        {
        }

        /// <inheritdoc />
        public override void Attack()
        {
             Console.WriteLine($"中锋{name}攻击");

        }

        /// <inheritdoc />
        public override void Defense()
        {
             Console.WriteLine($"中锋{name}防守");

        }
    }

    class  ForeignCenter
    {
        public string Name
        {
            get => name;
            set => name = value;
        }

        private string name;

        public  void Attack()
        {
            Console.WriteLine($"外籍中锋{name}攻击");

        }

        /// <inheritdoc />
        public  void Defense()
        {
            Console.WriteLine($"外籍中锋{name}防守");

        }
    }
    //翻译者 适配翻译
    class  Translator:Player
    {
        private ForeignCenter foreignCenter;
        /// <inheritdoc />
        public Translator(string name) : base(name)
        {
            foreignCenter.Name = name; 
        }

        /// <inheritdoc />
        public override void Attack()
        {
             foreignCenter.Attack();
        }

        /// <inheritdoc />
        public override void Defense()
        {
              foreignCenter.Defense(); 
        }
    }

    class  Guards:Player
    {
        /// <inheritdoc />
        public Guards(string name) : base(name)
        {
        }

        /// <inheritdoc />
        public override void Attack()
        {
             Console.WriteLine($"后卫{name}攻击");

        }

        /// <inheritdoc />
        public override void Defense()
        {
             Console.WriteLine($"后卫{name}攻");

        }
    }
}
