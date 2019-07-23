using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

/// <summary>
/// 适用于 操作系统 文件树，就是类似 二叉树 或者Unity的Hierarchy面板，层级面板
/// </summary>
namespace _15组合模式
{/// <summary>
///何时 使用组合模式， 需求中是体现部分与整体层次的结构时，
/// 以及 你希望用户可以忽略 组合对象与单个对象的不同，
/// 统一地使用组合模式结构中的所有对象时，就应该考虑用组合模式
/// </summary>
    class Program
    {
        /// <summary>
        /// 用户不用关心底层是处理一个叶节点还是 处理一个组合组件，用不着为定义组合而写一些选择判断语句
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           Composite Root=new Composite("root");
           
           Composite  com=new Composite("leaf1");
           Leaf leaf=new Leaf("叶子1");
           Leaf leaf2=new Leaf("叶子2");
           com.Add2Self(leaf).Add(leaf2);
           Root.Add(com);
           Root.Add2Self(new Leaf("叶子3")).Add2Self(new Leaf("叶子4")).Add(new Leaf("叶子5"));
           Composite com2=new Composite("leaf2");
           com2.Add2Self(new Leaf("叶子6")).Add(new Leaf("叶子7"));
            Root.Add(com2);

            Root.Display(1);

            GDepartment RootCompany=new GDepartment("中国xx公司总部","管理各子公司");
            GDepartment shCompany=new GDepartment("上海xx公司总部","管理行政");
            shCompany.AddCompany(new LeafCompany("上海人力资源行政部","负责上海地区招聘"));
            shCompany.AddCompany(new LeafCompany("上海技术研发中心","负责上海技术研发"));
          RootCompany.AddCompany(shCompany);
          RootCompany.Display(1);
          RootCompany.DoDuty();
        }
    }

    public abstract class Component
    {

        protected string name;

        /// <inheritdoc />
        protected Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
        
    }

    public class Leaf : Component
    {
        /// <inheritdoc />
        public Leaf(string name) : base(name)
        {
        }

        /// <inheritdoc />
        public override void Add(Component c)
        {
           Console.WriteLine("leaf can't not add");
        }

        /// <inheritdoc />
        public override void Remove(Component c)
        {
            Console.WriteLine("leaf can't not remove");
        }

        /// <inheritdoc />
        public override void Display(int depth)
        {
             Console.WriteLine(new string('-',depth)+name);
        }
    }

    public class Composite : Component
    {
        private List<Component> components;
        /// <inheritdoc />
        public Composite(string name) : base(name)
        {
            components=new List<Component>();
        }

        /// <inheritdoc />
        public override void Add(Component c)
        {
           components.Add(c);
        }

        public Composite Add2Self(Component c)
        {
            components.Add(c);
            return this;
        }

        /// <inheritdoc />
        public override void Remove(Component c)
        {
            components.Remove(c);
        }

        /// <inheritdoc />
        public override void Display(int depth)
        {
            foreach (var  c in components)
            {
                c.Display(depth);
            }
        }
    }
}
