using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14备忘录模式
{

    public class MenClient
    {
        public void Start()
        {
            Originator o=new Originator();
            o.Data=new IData("版本1");
            o.Show();

            Craretaker craretaker=new Craretaker();
             
           
            craretaker.AddMemento("版本1", o.CreateMemento());
            o.Data.Data = "版本2";
            o.Show();
            
            o.SetData(craretaker.GetMemento("版本1").Data);
            o.Show(); //回到版本1

        }
    }

    class IData
    {
        private string data;

        /// <inheritdoc />
        public IData(string data)
        {
            this.data = data;
        }

        public string Data
        {
            get => data;
            set => data = value;
        }

        public IData Clone()
        {
            return this.MemberwiseClone() as  IData;
            ;
        }
    }

     
    class  Originator
    {
        private IData data;

        public IData Data
        {
            get => data;
            set => data = value;
        }

        public Memento CreateMemento()
        {
             
            return  new Memento(data.Clone()); 
            
        }

        public void SetData(IData data)
        {
            this.data = data;
        }

        public void Show()
        {
            Console.WriteLine(data.Data);
        }
    }
    //备忘录 ， 复制存数据
    class  Memento
    {
        private IData data;
        /// <inheritdoc />
        public Memento(IData data)
        {
            this.data=data;
        }

        public IData Data
        {
            get => data;
             
        }
    }

    class Craretaker
    {
        Dictionary<string,Memento> menMementoDic=new Dictionary<string, Memento>();

        public Memento GetMemento(string key)
        {
            if (menMementoDic.ContainsKey(key))
            {
                return menMementoDic[key];
            }
            throw  new Exception($"key:{key}不存在");
        }

        public void AddMemento(string key, Memento memento)
        {
            if (menMementoDic.ContainsKey(key))
            {
                menMementoDic[key] = memento; //覆盖数据 处理
            }
            menMementoDic.Add(key,memento);
        }
    }

    
}
