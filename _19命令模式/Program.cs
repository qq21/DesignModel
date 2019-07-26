using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
namespace _19命令模式
{   

    /// <summary>
    /// 敏捷开发原则: 不要为代码添加基于猜测的  实际不需要的功能
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //客户端紧耦合
            //路边烤肉版本
            // Barbecuer boy=new Barbecuer();
            //boy.BackBabyCabbage();// 点了娃娃菜
            //boy.BackChickenWing();
            //boy.BackMutton();
            //boy.BackBabyCabbage();

            
            Barbecuer barbecuer=new Barbecuer();

            BarCommond wingC = new WingCommond(barbecuer);
            BarCommond muttonCommond=new MuttonCommond(barbecuer);
            BarCommond cabbageCommond=new CabbageCommond(barbecuer);

            Waitress barWaitress =new Waitress();

            barWaitress.AddOrder(wingC);
            barWaitress.AddOrder(muttonCommond);
            barWaitress.AddOrder(cabbageCommond);
            barWaitress.AddOrder(wingC);

            barWaitress.Excute();
                        
            Console.ReadKey();
        }
        //码农老矣  尚能码否
    }
    public class Barbecuer

    {
        public void BackMutton()
        {
            Console.WriteLine("烤羊肉串");
        }

        public void BackChickenWing()
        {
            Console.WriteLine("烤鸡翅");
        }

        public void BackBabyCabbage()
        {
            Console.WriteLine("烤娃娃菜");
        }
    }


    ///店面烤肉
    public abstract class BarCommond
    {
         protected Barbecuer barbecuer;

        /// <inheritdoc />
        protected BarCommond(Barbecuer barbecuer)
        {
            this.barbecuer = barbecuer;
        }

        public abstract void Excute();
    }
    /// <summary>
    ///烤鸡翅 命令
    /// </summary>
    public class WingCommond : BarCommond
    {
        /// <inheritdoc />
        public WingCommond(Barbecuer barbecuer) : base(barbecuer)
        {
        }

        /// <inheritdoc />
        public override void Excute()
        {
            barbecuer.BackChickenWing();
        }
    }

    /// <summary>
    /// 烤羊肉命令
    /// </summary>
    public class MuttonCommond : BarCommond
    {
        /// <inheritdoc />
        public MuttonCommond(Barbecuer barbecuer) : base(barbecuer)
        {
        }

        /// <inheritdoc />
        public override void Excute()
        {
           barbecuer.BackMutton();
        }
    }

    /// <summary>
    /// 烤娃娃菜命令
    /// </summary>
    public class CabbageCommond : BarCommond
    {
        /// <inheritdoc />
        public CabbageCommond(Barbecuer barbecuer) : base(barbecuer)
        {
        }

        /// <inheritdoc />
        public override void Excute()
        {
          barbecuer.BackBabyCabbage();
        }
    }

    public class Waitress
    {
        /// <summary>
        /// 线程 安全 队列
        /// </summary>
        //private ConcurrentQueue<BarCommond> barCommondsQueue;

        //private ConcurrentBag<BarCommond> barCommonds;
        private List<BarCommond> barCommonds;
        /// <inheritdoc />
        public Waitress()
        {
              barCommonds = new List<BarCommond>();
             
        }

        public void Excute()
        {

            lock (barCommonds)
            {
                foreach (var c in barCommonds )
                {
                    c.Excute();
                }
            }
             
        }

        public void AddOrder(BarCommond barCommond)
        {

            Console.WriteLine(System.DateTime.Now.ToLocalTime() + "添加命令：" + barCommond.ToString());
            barCommonds.Add(barCommond);
        }

        public void CancelOrder(BarCommond barCommond)
        {
            lock (barCommonds)
            {
                if (barCommonds.Contains(barCommond))
                {
                    barCommonds.Remove(barCommond);
                }
            }
            Console.WriteLine(System.DateTime.Now.ToLocalTime() + "移除命令：" + barCommond.ToString());
        }
    }

    public abstract class ICommond
    {
        private Receiver _receiver;

        /// <inheritdoc />
        protected ICommond( Receiver receiver)
        {
            _receiver = receiver;
        }

        public abstract void Excute();
    }

    public class Receiver
    {
        public void Excute()
        {
          Console.WriteLine("执行请求");
        }
    }

    public class Invoker
    {
        private ICommond _commond;

        public void SetCommond(ICommond cmd )
        {
            this._commond = cmd;
        }

        public void Excute()
        {
            if (this._commond!=null)
            {
                _commond.Excute();
            }
        }
    }



}
