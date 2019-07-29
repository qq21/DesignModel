using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace _10_观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Observatory observatory=new Observatory();
            GDob oGDob=new GDob(observatory,"广东天气台");
            SHob sHob=new SHob(observatory,"上海天气台");
            observatory.AddObserver(oGDob);
            observatory.AddObserver(sHob);
            observatory.Notify("现在是下雨");
            observatory.WeatherNotify("现在转晴啦");
        }
    }

    public interface ISubject
    {
        void Notify();
        void AddObserver(Observer o);
        void RemoveObserver(Observer o);
        string State { get; set; }
        void AddListner(WeatherNoticeEvent we);
    }
 
    public delegate void WeatherNoticeEvent(string weather);

    /// <summary>
    /// 气象台
    /// </summary>
    public class Observatory : ISubject
    {
        private List<Observer> observers;

        //第二种 实现方式 使用 会比较简单,不需要在外界进行注册  
        private WeatherNoticeEvent WE;  
        //如果经常需要移除 考虑用字典， 否则就 直接用 这个WeatherEvent 
        private Dictionary<string, WeatherNoticeEvent> dic;

        /// <inheritdoc />
        public Observatory()
        {
            observers=new List<Observer>();
        }

        /// <summary>
        /// 这种是 直接加
        /// </summary>
        /// <param name="we"></param>
        public void AddListner(WeatherNoticeEvent we)
        {
           
            if (WE==null)
            {
                WE = we; //首次
            }
            else
            {
                WE += we;
            }
        }

        /// <inheritdoc />
        public void Notify(string context)
        {
            foreach (var o in observers)
            {
                o.Update(context);
            }
        }

        public void WeatherNotify(string weather)
        {
            if (WE!=null)
            {
                WE(weather);
            }
        }

        /// <inheritdoc />
        public void Notify()
        {
            foreach (var o in observers)
            {
                o.Update( );
            }
        }

        /// <inheritdoc />
        public void AddObserver(Observer o)
        {
            if (o!=null)
            {
                observers.Add(o);
            }
        }

        /// <inheritdoc />
        public void RemoveObserver(Observer o)
        {
            if (o!=null)
            {
                observers.Remove(o);
            }
        }

        /// <inheritdoc />
        public string State { get; set; }
    }

    public abstract class Observer
    {
        protected string name;
        protected ISubject subject;
        /// <inheritdoc />
        protected Observer(ISubject subject,string name)
        {
             
            this.subject = subject;
            this.name = name;

            //无法在构造函数里 直接添加观察者 但是 可以 利用委托 做到  
            //   this.subject.AddObserver(this);
            //利用委托
            WeatherNoticeEvent ShWNE = new WeatherNoticeEvent(Update);

            subject.AddListner(ShWNE);
        }

        public virtual void Update(string context)
        {
            Console.WriteLine(name + "提醒:" + context);

        }

        public abstract void Update();
    }

    public  class GDob : Observer
    {
        /// <inheritdoc />
        public GDob(ISubject subject, string name) : base(subject, name)
        {
          
        }

        /// <inheritdoc />
        public override void Update()
        {}
    }

    public class SHob : Observer
    {
        // <inheritdoc/>
        public SHob(ISubject subject, string name) : base(subject, name)
        {
            
        }

        /// <inheritdoc />
        public override void Update()
        {            
        }

    }
}
