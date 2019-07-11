using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 减少 重复代码， 当要完成在某一细节层次一致的一个过程或一系列步骤，但其个别不走在更详细的层次上的实习可能不同时，通常考虑用模板方法模式处理
/// </summary>
namespace _07_模板方法
{
    abstract class AbstractTemplateMethod
    {
        public abstract void PrimitiveOpertation1();
        public abstract void PrimitiveOpertation2();

        public void TemplateMethod()
        {
            PrimitiveOpertation1();
            PrimitiveOpertation2();
            //给出逻辑的骨架， 推迟到子类实现。
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //同样的 试卷，但是 答案不同，  步骤都是相同的，答题，   细节不同，答案不同.
            // 于此相同的 有 ， 每个人的 一日三餐， 都需要 吃饭， 但是 吃的饭 不一样。  吃早饭，吃午饭。吃晚饭。
            StudentA a=new StudentA();
            a.StartTest();
            StudentB b=new StudentB();
            b.StartTest();
        }
      
    }
    public abstract class TestPaper
    {

        public abstract void AnswerA();
        public abstract void AnswerB();
        public abstract void AnswerC();


        void TestA()
        {
            Console.WriteLine("A1:答案是:");
            AnswerA();
        }
        void TestB()
        {
            Console.WriteLine("A1:答案是:");
            AnswerB();
        }
        void TestC()
        {
            Console.WriteLine("A1:答案是:");
            AnswerC();
        }

        public void StartTest()
        {
            this.TestA();
            this.TestB();
            this.TestC();
        }
    }

    public class StudentA : TestPaper
    {
        /// <inheritdoc />
        public override void AnswerA()
        {
            Console.WriteLine("A");
        }

        /// <inheritdoc />
        public override void AnswerB()
        {
            Console.WriteLine("B");

        }

        /// <inheritdoc />
        public override void AnswerC()
        {
            Console.WriteLine("C");

        }
    }
    public class StudentB : TestPaper
    {
        /// <inheritdoc />
        public override void AnswerA()
        {
            Console.WriteLine("A");
        }

        /// <inheritdoc />
        public override void AnswerB()
        {
            Console.WriteLine("A");

        }

        /// <inheritdoc />
        public override void AnswerC()
        {
            Console.WriteLine("A");

        }
    }
}
