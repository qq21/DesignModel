using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14备忘录模式
{
    //要保存的细节 给封装在了 Memento 中，那一天要更改保存的细节 也不用影响客户端

    //适用场景 :
    //比较适用于功能比较复杂的，但需要维护或记录属性历史的类
    //，或者需要保存的属性，只是众多属性中的一小布部分时，Originator 可以根据保存的Memento
    //信息还原到前一状态
    
    //如果在某个系统适用命令模式时，需要实现命令撤销功能，那么命令模式可以
    //使用备忘录模式来存储可撤销操作的状态。
    //使用备忘录可以把复杂的对象内部信息对其他的对象屏蔽器来；

    //当角色的状态改变时，又可能这个状态无效，这时候就可以使用暂时存储起来的备忘录将状态复原；

    //还可以用来 设计  游戏进度备忘
    class Program
    {
        static void Main(string[] args)
        {
            GameRole r1=new GameRole();
             r1.InitState(); 
             r1.ShowState();

             //GameRole backup=new GameRole();
             //备份 --暴露实现细节 不可取
             //backup.RotRoleData.Attack = r1.RotRoleData.Attack;
             //backup.RotRoleData.Defence = r1.RotRoleData.Defence;
             //backup.RotRoleData.Life = r1.RotRoleData.Life;


             //r1.Fright();
             //r1.ShowState();

             //恢复 --暴露实现细节，  不可取
             //r1.RotRoleData.Attack = backup.RotRoleData.Attack;
             //r1.RotRoleData.Defence = backup.RotRoleData.Defence;
             //r1.RotRoleData.Life = backup.RotRoleData.Life;
             //r1.ShowState();

             DataCraretaker dataCraretaker=new DataCraretaker();
             dataCraretaker.AddMemento("战斗前",r1.SetDataMemento());
             r1.Fright();
             r1.ShowState();

             //恢复
             r1.RotRoleData = dataCraretaker.GetMemento("战斗前").RoleData;
             r1.ShowState();

             //备忘录 模式   
             //Memento 
             // 再不破坏封装性的前提下， 捕获一个对象的内部状态，并在该对象之外保存这个状体，这样以后即可将该对象恢复到原先保存的状态 
             MenClient menClient=new MenClient();
             menClient.Start();
        }
    }

    class RoleData
    {
        private int life;
        private int defence;
        private int attack;

        /// <inheritdoc />
        public RoleData(int life, int defence, int attack)
        {
            this.life = life;
            this.defence = defence;
            this.attack = attack;
        }

        public int Life
        {
            get => life;
            set => life = value;
        }

        public int Defence
        {
            get => defence;
            set => defence = value;
        }

        public int Attack
        {
            get => attack;
            set => attack = value;
        }
        public RoleData Clone()
        {
            return  this.MemberwiseClone() as RoleData;
            ;
        }
    }

    class GameRole
    {
        private RoleData rotRoleData;

        public RoleData RotRoleData
        {
            get => rotRoleData;
            set => rotRoleData = value;
        }

        public void ShowState()
        {
            Console.WriteLine("当前角色状态：");
            Console.WriteLine($"生命力:{rotRoleData.Life},防御:{rotRoleData.Defence}，攻击:{rotRoleData.Attack}");
        }

        //设置 初始 状态
        public void  InitState()
        {
            rotRoleData=new RoleData(100,100,100);
        }
        //战斗
        public void Fright()
        {
            rotRoleData.Life = 00;
            rotRoleData.Defence = 00;
            rotRoleData.Attack = 00;
        }

        public DataMemento SetDataMemento()
        {
             return  new DataMemento(this.rotRoleData.Clone());
        }

    }

    class DataMemento
    {
        private RoleData roleData;

        /// <inheritdoc />
        public DataMemento(RoleData roleData)
        {
            this.roleData = roleData;
        }

        public void SetRoleData(RoleData roleData)
        {
            this.roleData = roleData;
        }

        public RoleData RoleData
        {
            get => roleData;
           
        }
    }
    class DataCraretaker
    {
        Dictionary<string, DataMemento> menMementoDic = new Dictionary<string, DataMemento>();

        public DataMemento GetMemento(string key)
        {
            if (menMementoDic.ContainsKey(key))
            {
                return menMementoDic[key];
            }
            throw new Exception($"key:{key}不存在");
        }

        public void AddMemento(string key, DataMemento memento)
        {
            if (menMementoDic.ContainsKey(key))
            {
                menMementoDic[key] = memento; //覆盖数据 处理
            }
            menMementoDic.Add(key, memento);
        }
    }

}
