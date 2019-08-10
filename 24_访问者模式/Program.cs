 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace _24_访问者模式
 {
     //目的是 把处理的操作从 数据结构中分离开来
     
     /// <summary>
     /// 表示一个作用于 某对象结构中的各元素操作，
     /// 使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作
     ///    </summary>
     class Program
     {
        //有 易于变化的算法，又有稳定的数据结构，会比较适合，因为访问者模式把 算法的操作，给抽象出来了
        //比如计算 访问，各个UI元素的深度,找出最小的深度，这个操作，变成一个DethpVisitor  就可以计算访问深度了;
        // 增加一个新的操作，或者算法，就相当于 增加一个新的访问者类
         static void Main(string[] args)
         {
            #region 男人和女人对于不同状态的反应的 例子
            //ObjectStructure o = new ObjectStructure();
            //o.Attach(new Man());
            //o.Attach(new Woman());
            //SuccessAct success = new SuccessAct();
            //o.Display(success);
            ////失败时的反应
            //FailAct fail = new FailAct();
            //o.Display(fail);
            //FallInLove fallInLove = new FallInLove();
            //o.Display(fallInLove);
            //Married married = new Married();
            //o.Display(married);


            #endregion

            #region  访问深度，计算深度的，的例子
            PanelElement plPanelElement = new PanelElement(0, 1000);
            PanelElement p2Element = new PanelElement(1001, 5000);
            UIButton uiButton = new UIButton(10101, 5010);
            UISprite uiSprite = new UISprite(10102, 5011);

            DepthVisitor depthVisitor = new DepthVisitor();
            MyObjectStructure.Instance.VisitAll(depthVisitor);
            Console.WriteLine($"总共深度为:{depthVisitor.TotalDepth}最大深度的Element的Id是{depthVisitor.MaxBaseElement.Id}最大深度为:{depthVisitor.MaxBaseElement.Depth}");
            #endregion

        }
    }
     
     public abstract class Action
     {
         public abstract void GetManConclusion(Man man);
         public abstract void GetWomanConclusion(Woman woman);
     }

     public abstract class Person
     {
         //将具体状态作为参数传递给"人" 类完成一次分派            
         public abstract void Accept(Action vistior);
     }

     public class Man : Person
     {
         /// 双分派技术，首先在客户程序中，将具体状态作为参数传递给"男人" 类完成一次分派
         /// 然后"男人"类 调用作为参数的 具体状态 中的方法"男人反应"，
         /// 同时将自己(this)作为参数传递进去，这便完成了第二次分派
          
         //双分派意味着得到执行的操作决定于请求的种类和两个接收者的类型,

         //将具体状态作为参数传递给"男人" 类完成一次分派
         public override void Accept(Action vistior)
         {
             //同时将自己(this)作为参数传递进去，这便完成了第二次分派
             vistior.GetManConclusion(this);
         }
          
     }

     public class Woman : Person
     {          
         public override void Accept(Action vistior)
         {
             vistior.GetWomanConclusion(this);
         }
     }

    public class SuccessAct : Action
     {        
         public override void GetManConclusion(Man m)
         {
             Console.WriteLine($"{m.GetType().Name}成功时，背后多半有一个伟大的女人。");
         }           
         public override void GetWomanConclusion(Woman woman)
         {
             Console.WriteLine($"{woman.GetType().Name}女人成功时，背后大多有一个不成功的男人。");
         }
     }

     public class FailAct : Action
     {         
         public override void GetManConclusion(Man m)
         {
             Console.WriteLine($"{m.GetType().Name}男人失败时，闷头喝酒，谁也不用劝");
         }
        
         public override void GetWomanConclusion(Woman woman)
         {
             Console.WriteLine($"{woman.GetType().Name}女人失败时，眼泪汪汪，谁也劝不了");
         }
     }

     public class FallInLove : Action
     {         
         public override void GetManConclusion(Man m)
         {
             Console.WriteLine($"{m.GetType().Name}男人恋爱时，凡事不懂也要装懂");
         }
       
        public override void GetWomanConclusion(Woman woman)
         {
             Console.WriteLine($"{woman.GetType().Name}女人恋爱时，遇事懂也要装不懂");
         }
     }

     public class Married:Action
     {       
         public override void GetManConclusion(Man man)
         { 
           Console.WriteLine("恋爱游戏结束时，有妻徒刑 遥无期");
         }
         public override void GetWomanConclusion(Woman woman)
         {
              Console.WriteLine("婚姻保险包平安");
         }
     }

     /// <summary>
     ///对象结构，  因为 男人和女人有很多种不同的状态， 每种状态又有不同的反应，
     /// 因此就 需要一个对象来记录 所有状态，以及得到不同反应 查看
     /// </summary> 一般 这个模式就是基于这个 数据结构比较稳定的系统
     class ObjectStructure
    {
        private IList<Person> elements = new List<Person>();

        //增加
        public void Attach(Person element)
        {
            elements.Add(element);
        }

        //移除
        public void Detach(Person element)
        {
            elements.Remove(element);
        }

        //查看显示
        public void Display(Action vistor)
        {
            foreach (var e in elements)
            {
                e.Accept(vistor);
            }
        }
    }

} 