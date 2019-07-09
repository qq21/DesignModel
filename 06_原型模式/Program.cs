using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            StudentResume resumeA=new StudentResume("小灰","23","喜欢算法和架构");

            StudentResume resumeAb = resumeA.Clone() as StudentResume;
            ;

            Console.WriteLine(resumeA);
            Console.WriteLine(resumeAb);

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

    public abstract class Resume
    {
        private string name;
        private string id;
        private string intro;

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

        public abstract Resume Clone();
    }

    public class  StudentResume:Resume
    {
        /// <inheritdoc />
        public StudentResume(string name, string id, string intro) : base(name, id, intro)
        {
        }

        /// <inheritdoc />
        public override Resume Clone()
        {
            return this.MemberwiseClone() as StudentResume;
        }
    }
}
