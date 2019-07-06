using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式练习_1
{
  public  class Operation
    {
        private double _numberA;
        private double _numberB;

        /// <inheritdoc />
        public Operation(double numberA, double numberB)
        {
            _numberA = numberA;
            _numberB = numberB;
        }

        public Operation()
        {
        }

        public double NumberA
        {
            get => _numberA;
             set => _numberA = value;
        }

        public double NumberB
        {
            get => _numberB;
            set => _numberB = value;
        }

        public virtual double Result()
        {
            double res = 0;

            return res;
        }

        /*public virtual double Res => 0;*/

    }

    class OperationAdd : Operation
    {
         
        /// <inheritdoc />
        public OperationAdd(double numberA, double numberB) : base(numberA, numberB)
        {
        }

        public OperationAdd()
        {
        }

        /// <inheritdoc />
        public override double Result()
        {
            return NumberA + NumberB;
        }
    }

    class  OperationMin:Operation
    {
        /// <inheritdoc />
        public OperationMin()
        {
        }

        /// <inheritdoc />
        public OperationMin(double numberA, double numberB) : base(numberA, numberB)
        {
        }
        
        /// <inheritdoc />
        public override double Result()
        {
            return NumberA - NumberB;
        }
    }

    class  OperationMul:Operation
    {
        /// <inheritdoc />
        public OperationMul(double numberA, double numberB) : base(numberA, numberB)
        {
        }

        /// <inheritdoc />
        public OperationMul()
        {
        }

        /// <inheritdoc />
        public override double Result()
        {
            return NumberA * NumberB;
        }
    }

    class  OperationDiv:Operation
    {
        /// <inheritdoc />
        public OperationDiv(double numberA, double numberB) : base(numberA, numberB)
        {
        }

        /// <inheritdoc />
        public OperationDiv()
        {
        }

        /// <inheritdoc />
        public override double Result()
        {
            if (base.NumberB==0)
            {
                throw  new Exception("被除数不能为0");
            }

            return base.NumberA / NumberB;
        }
    }

    public class OperationFactory
    {
        public static Operation CreateOperation(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    ;
                    break
                     ;
                case "-":break;
                    oper=new OperationMin()
                    ;
                case "*":break;
                    oper = new OperationMul();
                    ;
                case "/":break;
                    oper = new OperationDiv()
                    ;
            }

            return oper;
        }
    }

}
