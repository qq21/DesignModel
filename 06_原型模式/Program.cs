using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 数据集 对象 DataSet 也使用了原型模式， 通过Clone() 和Copy方法，区分 浅复制和深复制
/// Clone 方法用来复制 Dataset 的数据结构，但不复制它的数据，实现 原型模式的浅复制， Copy方法，不但复制结构也复制数据。
/// </summary>
namespace _06_原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteProtoType1 c1=new ConcreteProtoType1(2);
            c1.b = "1234";
            ConcreteProtoType1 c2=c1.Clone() as ConcreteProtoType1;
            c1.b = "12345";
            Console.WriteLine(c1.Id+c1.b);
            Console.WriteLine(c2.Id+c2.b);

            /*StudentResume resumeA=new StudentResume("小灰","23","喜欢算法和架构");

            StudentResume resumeAb = resumeA.Clone() as StudentResume;
            ;

            Console.WriteLine(resumeA);
            Console.WriteLine(resumeAb);
*/

        }
    }

    abstract class ProtoType
    {
        private int id;

        public int Id
        {
            get => id;
        }

        /// <inheritdoc />
        protected ProtoType(int id)
        {
            this.id = id;
        }

       public abstract ProtoType Clone();

    }

    class ConcreteProtoType1:ProtoType
    {
        public string b = "";
        /// <inheritdoc />
        public ConcreteProtoType1(int id) : base(id)
        {
        }

        /// <inheritdoc />
        public override ProtoType Clone()
        {
            return (ProtoType) this.MemberwiseClone();
        }
    }

    interface IClonable
    {
        object Clone();
     
    }
    //这个就类 需要继承  Iconable, 否则 ，在使用mebershipClone 方法时，会造成，修改引用类型时 会影响原对象， 
    public class WorkExperience:IClonable  // 参考深度复制 和 浅度复制
    {
        private string workData;

        public string WorkData
        {
            get => workData;
            set => workData = value;
        }

        private string company;

        public string Company
        {
            get => company;
            set => company = value;
        }

        /// <inheritdoc />
        public object Clone()
        {
            return this.MemberwiseClone();
        }

     
    }
    public class Resume:IClonable
    {
        private string name;
        private string id;
        private string intro;

        private WorkExperience workExp;

        public void SetWorkExperience(string workData,string Company)
        {
            workExp.Company = Company;
            workExp.WorkData = workData;

        }

        public void Display()
        {
            Console.WriteLine($"name:{name}+intro:{intro}");
            Console.WriteLine($"company:{workExp.Company}_data:{workExp.WorkData}");
        }

        public string Name
        {
            get => name;
             
        }

        public string Id
        {
            get => id;
             
        }

        public string Intro
        {
            get => intro;
             
        }

        private Resume(WorkExperience work)
        {   //提供Clone方法调用 的私有 构造函数，以便Clone
            this.workExp=work.Clone() as WorkExperience;
            ;
        }

        /// <inheritdoc />
        protected Resume(string name, string id, string intro)
        {
            this.name = name;
            this.id = id;
            this.intro = intro;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return  this.Name + this.intro;
        }

        public object Clone()
        {
            Resume obj=new Resume(this.workExp);
            obj.name = this.Name;
            obj.id = this.id;
            obj.intro = this.intro;
            return workExp.Clone();
        }
    }

    public class  StudentResume:Resume
    {
        /// <inheritdoc />
        public StudentResume(string name, string id, string intro) : base(name, id, intro)
        {
        }

        /// <inheritdoc />
    }
}
