using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            StrategyA sa=new StrategyA();
            ;
            Context context=new Context();

            context.SetStrategy(sa);
            context.HandleStragy();
        }
        
    }

    public class Context
    {
        private Strategy _strategy;
        public void SetStrategy(Strategy strategy)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   A                            
            _strategy = strategy;
        }

        public void HandleStragy()
        {
            _strategy.AlgorithmInterface();
        }
    }

    public abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    class  StrategyA:Strategy
    {
        /// <inheritdoc />
        public StrategyA()
        {
        }

        /// <inheritdoc />
        public override void AlgorithmInterface()
        {
            Console.WriteLine("a+b");
        }
    }

    class StrategyB:Strategy
    {
        /// <inheritdoc />
        public override void AlgorithmInterface()
        {
            Console.WriteLine("a-b");

        }
    }

    class StrategyC:Strategy
    {
        /// <inheritdoc />
        public override void AlgorithmInterface()
        {
             Console.WriteLine("a*b");
        }
    }


}
