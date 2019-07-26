using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class PeopleCloth
    {
    }

    public abstract class People
    {
        protected Clothes c;

        /// <inheritdoc />
        protected People(Clothes c)
        {
            this.c = c;
        }

        public void Wear()
        {
            c.Wear();
        }
    }

    public class SouthPeople:People
    {
        /// <inheritdoc />
        public SouthPeople(Clothes c) : base(c)
        {
        }
    }
    public  class  NorthPeople:People
    {
        /// <inheritdoc />
        public NorthPeople(Clothes c) : base(c)
        {
        }
    }

    public enum ClothesType
    {
        Jacket,
        Trouser,
        Hat,
        Briefs
    }

    public abstract class Clothes
    {
        protected int warm;
        protected string name;
        protected ClothesType _type;  
        public virtual void Wear()
        {
            Console.WriteLine( $"{name}:耐寒度:{warm}");
        }

        /// <inheritdoc />
        protected Clothes(int warm, string name, ClothesType type)
        {
            this.warm = warm;
            this.name = name;
            _type = type;
        }

        /// <inheritdoc />
        protected Clothes(int warm, string name)
        {
            this.warm = warm;
            this.name = name;
        }

    }
    public  class Jacket:Clothes
    {
        /// <inheritdoc />
        public Jacket(int warm, string name, ClothesType type) : base(warm, name, type)
        {
            this.name = "夹克";
            this._type = ClothesType.Jacket;
            this.warm = 100;//基础 耐寒度为100
        }

        /// <inheritdoc />
        public Jacket(int warm, string name) : base(warm, name)
        {
            this._type = ClothesType.Jacket;
        }
    }
    public class  Trouser:Clothes
    {
        /// <inheritdoc />
        public Trouser(int warm, string name, ClothesType type) : base(warm, name, type)
        {
            this.warm = 100;
            this.name = "裤子";
            this._type = ClothesType.Trouser;
        }

        /// <inheritdoc />
        public Trouser(int warm, string name) : base(warm, name)
        {
            this._type = ClothesType.Trouser;
        }
    }
    public class Hat:Clothes
    {
        /// <inheritdoc />
        public Hat(int warm, string name, ClothesType type) : base(warm, name, type)
        {
            this.warm = 20;
            this.name = "帽子";
            this._type = ClothesType.Hat;
        }

        /// <inheritdoc />
        public Hat(int warm, string name) : base(warm, name)
        {
            this._type = ClothesType.Hat;

        }
    }
    public  class  Briefs:Clothes
    {
        /// <inheritdoc />
        public Briefs(int warm, string name, ClothesType type) : base(warm, name, type)
        {
            this.warm = 30;
            this.name = "内裤";
            this._type = ClothesType.Briefs;
        }

        /// <inheritdoc />
        public Briefs(int warm, string name) : base(warm, name)
        {
            this._type = ClothesType.Briefs;
        }
    }
}
