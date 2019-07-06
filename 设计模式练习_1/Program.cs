using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 简单工厂模式 
/// </summary>
namespace 设计模式练习_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //简单工厂模式
            Operation add = OperationFactory.CreateOperation("+");

            add.NumberB = 10;
            add.NumberA = 20;

            Console.WriteLine(add.Result());
        }
    }
}
