using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_工厂方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodFactory fishFood=new FishFoodFactory(new TunnyFish(18));
            Fish tunnyFish=    fishFood.CreateFood() as Fish;
         
            FoodFactory fruitFoodFactory= new FruitFoodFactoru(new Jackfruit(200));
            fruitFoodFactory.CreateFood();
            
           ILeifengFactory factory=new UndergraduateFactory();

          Leifeng student=  factory.CreateLeifeng();
           
          student.BuyRice();
          student.Wash();
          student.Sweep();
          factory=new VoluteerFactory();
          Leifeng voluteer= factory.CreateLeifeng();
            voluteer.Sweep();
            voluteer.BuyRice();
            voluteer.Wash();
        }
    }

    interface FoodFactory
    {
        IFood CreateFood();
    }

    public class Leifeng
    {
        public void Wash()
        {
            Console.WriteLine("洗衣服");
        }

        public void Sweep()
        {
            Console.WriteLine("扫地");
        }

        public void BuyRice()
        {
            Console.WriteLine("买米");
        }

    }
    //社区志愿者
    class Voluteer:Leifeng
    {
        
    }


    public class StudentA : Leifeng
    {
    }

    class UndergraduateFactory:ILeifengFactory
    {
        /// <inheritdoc />
        public Leifeng CreateLeifeng()
        {
          return  new StudentA();//学雷锋的学生
        }
    }

    class VoluteerFactory : ILeifengFactory
    {
        /// <inheritdoc />
        public Leifeng CreateLeifeng()
        {
            return  new  Voluteer();
        }
    }

    public  interface IFood
    {
        
    }
    public interface ILeifengFactory
    {
        Leifeng CreateLeifeng();
    }
 

    public abstract class Fish:IFood
    {

        public enum FishType
        {
            Amphiprion,//双锯鱼 属
            Osteichthyes,//硬骨鱼纲
            Trichiurus//带鱼属
        }
        protected int price;

        public int Price
        {
            get => price;
            set => price = value;
        }

        protected string name;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Fish()
        {
        }
    }

    
   public class HairtailFish : Fish
   {
       /// <inheritdoc />
       public HairtailFish(int price)
       {
           this.name = "HairtailFish";
           this.price = price;
       }
   }

   public class TunnyFish : Fish
   {
       /// <inheritdoc />
       public TunnyFish(int price)
       {
           this.name = "TunnyFish";
           this.price = price;
       }
   }

   public class FishFoodFactory : FoodFactory
    {
        private Fish fish;

        /// <inheritdoc />
        public FishFoodFactory(Fish fish)
        {
            this.fish = fish;
        }

        /// <inheritdoc />
        public IFood CreateFood(  )
        {
            Console.WriteLine("生成了:" + fish.Name + "...价格:" + fish.Price);

            return fish;
        }
    }

   
   
   public abstract class Fruit : IFood
    {
       public string name;
       public int price;
   }

   public class Jackfruit : Fruit
   {
       /// <inheritdoc />
       public Jackfruit(int price)
       {
           this.name = "Jackfruit";
           this.price = price;
       }
   }

   public class MangoFruit: Fruit
   {
       /// <inheritdoc />
       public MangoFruit(int price)
       {
           name = "Mango";
           this.price = price;
       }
   }

   public class FruitFoodFactoru : FoodFactory
   {
       private Fruit _fruit;

       /// <inheritdoc />
       public FruitFoodFactoru(Fruit fruit)
       {
           _fruit = fruit;
       }

       /// <inheritdoc />
       public IFood CreateFood()
       {
         Console.WriteLine("生产了"+ _fruit.name+"花费了"+_fruit.price);
         return _fruit;
       }
   }
   

}
