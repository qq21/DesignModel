using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 主要 用于创建一些复杂的对象，这些对象内部构建间的建造顺序通常是稳定的，但内部的构建通常面临复杂的变化
/// </summary>
namespace _09_建造者模式
{  //有点类似模板方法 ， 区别 在于 建造者模式  多了一个建造者,Director  主要引用一个builder，build方法就是 统一它们的流程
    class Program
    {
        static void Main(string[] args)
        {

            IBuild fatBuild=new PersonThinBuilder(09) as  IBuild;

            PersonDirector personDirector=new PersonDirector();
            personDirector.SetBuilder(fatBuild);
            personDirector.BuildPeople();

            Console.WriteLine("_________________________________________");
            personDirector.SetBuilder(new PersonFatBuilder(90));
            personDirector.BuildPeople();


        }
    }
    /// <summary>
    /// 建造者模式是在当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时适用的模式
    /// </summary>
    public abstract class  IBuild
    {
        /// <inheritdoc />
        protected IBuild(int buildId)
        {
            BuildId = buildId;
        }

        public  abstract void BuildHand();
      public abstract void BuildHead();
      public abstract void BuildFoot();
      public abstract void BuildBody();

      private int BuildId;

      public int BuildId1
      {
          get => BuildId;
          set => BuildId = value;
      }
    }
    //具体建造者 实现builder接口 构造和装配各个部件，Product 就是那些具体的小人，产品角色
    public class PersonThinBuilder : IBuild
    {
        /// <inheritdoc />
        public PersonThinBuilder(int buildId) : base(buildId)
        {
        }

        /// <inheritdoc />
        public override void BuildHand()
        {
           Console.WriteLine("Thin hand");
        }

        /// <inheritdoc />
        public override void BuildHead()
        {
            Console.WriteLine("Thin Head");
        }

        /// <inheritdoc />
        public override void BuildFoot()
        {
            Console.WriteLine("Thin Foot");
        }

        /// <inheritdoc />
        public override void BuildBody()
        {
             Console.WriteLine("Thin Body");
        }
    }
    // 比如 建塔， 建房子,建人物
    public class PersonFatBuilder:IBuild
    {
        /// <inheritdoc />
        public PersonFatBuilder(int buildId) : base(buildId)
        {
        }

        /// <inheritdoc />
        public override void BuildHand()
        {
            Console.WriteLine("Fat hand");
        }

        /// <inheritdoc />
        public override void BuildHead()
        {
            Console.WriteLine("Fat head");
          }

        /// <inheritdoc />
        public override void BuildFoot()
        {
            Console.WriteLine("Fat foot");
        }

        /// <inheritdoc />
        public override void BuildBody()
        {
            Console.WriteLine("Fat body");
        }
    }
     //指挥者 用与创建一些复杂的对象，这些对象内部构建间的建造顺序通常是稳定的，但对象内部的构建通常面临着复杂变化
    public class PersonDirector
    {
        private IBuild builder;

        public void SetBuilder(IBuild builder)
        {
            this.builder = builder;
        }

        public void BuildPeople()
        {
            builder.BuildHead();
            builder.BuildBody();
            builder.BuildHand();
            builder.BuildFoot();
        }
    }

}
