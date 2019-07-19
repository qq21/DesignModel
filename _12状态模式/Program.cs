using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
/// <summary>
/// 状态模式 适用于  一个对象有多种状态，需要有很多的逻辑判断去 处理转换
/// 将与特定状态相关的行为局部化，并且 将不同状态的行为分离开来
/// 目的是为了消除庞大的条件分支语句
/// </summary>
namespace _12状态模式
{
    class Program
    {
        static void Main(string[] args)
        {
           Context clientContext=new Context(new StateA());

           IState state= clientContext.Request();

            Work work=new Work(new MorningWorkState(), false,7);
            work.Hour = 7;
           // 无线状态机， 每1秒转换一次状态 
            Thread tesThread=new Thread(() =>
            {
                while (true)
                {
                    //clientContext.Request();
                    Thread.Sleep(1000);
                    work.Hour += 1;
                    Console.Write("当前时间："+work.Hour+"  ");
                    work.WritePrograms();

                }
            });
            tesThread.Start();
       
            
        }
    }

   public abstract  class IState
   {
       public abstract IState Handle(Context context);
   }

    //转换 逻辑 A -B-C -A    可以代表， 按下A -再按B-再按C ，或者人物状态等等....
    public class Context
    {
        private IState _state;
        public int ACount;
        public int BCount;
        public int CCount;


        public IState State
        {
            get => _state;
            set => _state = value;
        }

        /// <inheritdoc />
        public Context(IState state)
        {
            this._state = state;
        }

        public IState Request()
        {

            return _state.Handle(this);
        }
    }

    public class StateA : IState
    {

        /// <inheritdoc />
        public override IState Handle(Context context)
        {
            //判断逻辑是 否 达到 转换B的条件

            Console.WriteLine(context.BCount);
            IState s = new StateB();
            context.BCount += 1;
            context.State = s;
            return s;
        }
    }
    public class StateB : IState
    {
        /// <inheritdoc />
        public override IState Handle(Context context)
        {
            //判断逻辑是否达到 转换C的条件
            Console.WriteLine("转换C");
            IState s = new StateC();

            context.CCount += 1;
            context.State = s;
            Console.WriteLine(context.CCount);
            return s;
        }
    }
    public class StateC : IState
    {
        /// <inheritdoc />
        public override IState Handle(Context context)
        {
            //判断逻辑是否是 达到转换A的条件
            Console.WriteLine("转换A"); //中间可以是 计时器判断条件等等.... 也可以用于处理技能连招（操作）
                                      //如果按下 A键-触发技能A 再按下B 触发连招，中间及时器判断，没达到，返回idle....con.
            context.ACount += 1;

            IState s = new StateA();
            context.State = s;
            Console.WriteLine(context.ACount);
            return s;
        }
    }

    public class Work
    {
        private WorkState currentWorkState;

        public void SetState(WorkState workState)
        {
            this.currentWorkState = workState;
        }

        public void WritePrograms()
        {
            if (currentWorkState!=null)
            {
                currentWorkState.WritePrograms(this);
            }
        }

        public bool IsFinshWork
        {
            get => isFinshWork;
            set => isFinshWork = value;
        }

        private bool isFinshWork;

        private int hour;

        /// <inheritdoc />
        public Work(WorkState currentWorkState, bool isFinshWork, int hour)
        {
            this.currentWorkState = currentWorkState;
            this.isFinshWork = isFinshWork;
            this.hour = hour;
        }

        public int Hour
        {
            get => hour;
            set => hour = value;
        }

        /// <inheritdoc />
        public Work()
        {
        }
    }

    public abstract class WorkState
    {
        public abstract WorkState WritePrograms(Work w);
    }

    public class MorningWorkState : WorkState
    {
        /// <inheritdoc />
        public override WorkState WritePrograms(Work w)
        {
            if (w.Hour<12)
            {
               Console.WriteLine("上午精神还不错,输出很多代码.~~__~~ ");
                
               return this;
            }
            else
            {
                WorkState noon= new NoonWorkState();
                w.SetState(noon);
                return noon;
            }

        }
    }

    public class NoonWorkState : WorkState
    {
        /// <inheritdoc />
        public override WorkState WritePrograms(Work w)
        {
            if (w.Hour>12 &&w.Hour<14)
            {
                Console.WriteLine("中午时间到了，吃午餐，睡午觉  zzzZZZ");
                return this;
            }
            else 
            {
             
                WorkState wState=new AterNoonWorkState(); 
                w.SetState(wState);
                return wState;
            }           
        }
    }

    public class AterNoonWorkState : WorkState
    {
        /// <inheritdoc />
        public override WorkState WritePrograms(Work w)
        {
            if (w.Hour>14&&w.Hour<18)
            {
                Console.WriteLine("下午工作时间到到，睡了午觉后，精神好多啦，工作差不多了");
              
                return this;
            }
            else
            {
                WorkState afterNoon=new  EveningWorkState();
                w.SetState(afterNoon);
                return  afterNoon;

            }
        }
    }

    public class EveningWorkState : WorkState
    {
        /// <inheritdoc />
        public override WorkState WritePrograms(Work w)
        {
            if (w.Hour>18&&w.Hour<21)
            {
                if (!w.IsFinshWork)
                {
                    Console.WriteLine(" 工作还没完成需要加班.。。。");
                    w.IsFinshWork = true;
                }
                else
                {
                    Console.WriteLine(" 工作完成了，不需要加班，可以自己学一学");
                }
                
                return this;
            }
            else
            {
                 WorkState wState=new SleepingWorkState();
                w.SetState(wState);
                 return wState;
            }
        }
    }

    public class SleepingWorkState : WorkState
    {
        /// <inheritdoc />
        public override WorkState WritePrograms(Work w)
        {
            if (w.Hour>21&&w.Hour<23)
            {
                if (!w.IsFinshWork)
                {
                    Console.WriteLine("加班加班加班,睡眠状态加班 zzzZZZZ");
                    w.IsFinshWork = true;
                }
                else
                {
                  Console.WriteLine("看一会书就休息了，正常完成工作");
                }

                return this;
            }
            else
            {
                WorkState workState=new RestWorkState();
                w.SetState(workState);
                return workState;
            }
        }
    }
    public  class RestWorkState:WorkState
    {
        /// <inheritdoc />
        public override WorkState WritePrograms(Work w)
        {
            if (w.Hour>23)
            {
               Console.WriteLine("太困了没办法用意念加班了，zzzZZZZ");
               if (w.Hour == 24)
               {
                   w.Hour = 0;
               }
                return this;
            }
            else
            {
                if (w.Hour<6)
                {
                    Console.WriteLine("zzzZZZZ");
                    return this;
                }
                else
                {
                    Console.WriteLine("进入下一天了，每天都是新的一天.~~__~~ ");
                    WorkState workState = new MorningWorkState();
                    w.SetState(workState);
                    return workState;
                }
                    
            }
        }
    }

}
