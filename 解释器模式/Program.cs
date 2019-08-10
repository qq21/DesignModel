using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 抽象解释器模式
/// 通常当有一个语言需要解释执行，并且你可将该语言中的句子表示为一个抽象语法树时，可使用解释器模式
///这种模式被用在 SQL 解析、符号处理引擎等。

/// 好处: 容易 改变扩展文法，比较容易实现文法 易于直接编写
/// </summary>
namespace  解释器模式
{
    class Program
    {
        static void Main(string[] args)
        {   
           Context context =new Context("输出");
           
           List<AbstractExpression> abstractExpressions=new List<AbstractExpression>();

           abstractExpressions.Add(new NonExpression());
           abstractExpressions.Add(new TerminalExpression());
           abstractExpressions.Add(new TerminalExpression());
           //调用 解释操作

           /*foreach (var abs in abstractExpressions )
           {
               abs.Interpret(context);
           }*/
           MusicInterpret music=new MusicInterpret();

           music.Start();         
        }
    }

    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    public   class TerminalExpression:AbstractExpression
    {
        /// <inheritdoc />
        public override void Interpret(Context context)
        {
           Console.WriteLine("终端解释器");
        }
    }

    public class NonExpression : AbstractExpression
    {
        /// <inheritdoc />
        public override void Interpret(Context context)
        {
            Console.WriteLine("非符号解释器");
        }
    }

    public class Context
    {
        string input;

        /// <inheritdoc />
        public Context(string input)
        {
            this.input = input;
        }

        public string Input
        {
            get => input;
            set => input = value;
        }

        private string outPut;

        public string OutPut
        {
            get => outPut;
            set => outPut = value;
        }

    }

}
