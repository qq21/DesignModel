using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_享元模式
{
    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            
            FlyWeightFactory flyWeightFactory=new FlyWeightFactory();

            FlyWeight fx = flyWeightFactory.GetFlyWeight("x");
            fx.Operation(extrinsicstate);
            FlyWeight ff = flyWeightFactory.GetFlyWeight("f");
            ff.Operation(extrinsicstate);
            FlyWeight fy = flyWeightFactory.GetFlyWeight("y");
            fy.Operation(extrinsicstate);

            WebFlyWeight wfw=new WebFlyWeight();
            wfw.Start();

        }
    }

    public abstract class FlyWeight
    {
        public abstract void Operation(int extrainsicstate);
    }

    public class ConcreteFlyWeight:FlyWeight
    {
        /// <inheritdoc />
        public override void Operation(int extrainsicstate)
        {
         Console.WriteLine("具体FlyWeight"+extrainsicstate);
        }
    }

    public class Concrete2FlyWeight:FlyWeight
    {
        /// <inheritdoc />
        public override void Operation(int extrainsicstate)
        {
            Console.WriteLine("不具体实现的FlyWeiight"+extrainsicstate);
        }
    }

    
    public class FlyWeightFactory
    {
        Hashtable flyweights=new Hashtable();
         
        /// <inheritdoc />
         public FlyWeightFactory()
         {
             flyweights.Add("x",new ConcreteFlyWeight());
             flyweights.Add("f",new Concrete2FlyWeight());
             flyweights.Add("y",new ConcreteFlyWeight());
         }

        public FlyWeight GetFlyWeight(string key)
        {
            return flyweights[key] as FlyWeight;
        }
    }



}
