using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15组合模式
{
    public  abstract class Company
    {
        protected string name;
        protected string Duty;
        /// <inheritdoc />
        protected Company(string name)
        {
            this.name = name;
        }

        /// <inheritdoc />
        protected Company(string name, string duty)
        {
            this.name = name;
            Duty = duty;
        }

        public abstract void AddCompany(Company c);
        public abstract void RemoveCompany(Company c);
        public abstract void Display(int depth);
        public abstract void DoDuty();
    }
    public  class  GDepartment:Company
    {
          List<Company> companies;
        /// <inheritdoc  />
        public GDepartment(string name) : base(name)
        {
            companies = new List<Company>();
        }

        /// <inheritdoc />
        public GDepartment(string name, string duty) : base(name, duty)
        {
            companies = new List<Company>();

        }

        /// <inheritdoc />
        public override void AddCompany(Company c)
        {
            companies.Add(c);
        }

        /// <inheritdoc />
        public override void RemoveCompany(Company c)
        {
            companies.Remove(c);
        }

        /// <inheritdoc />
        public override void Display(int depth)
        {
            foreach (var c in companies)
            {
                c.Display(depth);
            }
        }

        /// <inheritdoc />
        public override void DoDuty()
        {
            foreach (var c in companies)
            {
                c.DoDuty();

            }
        }
    }
    public  class LeafCompany :Company
    {
        /// <inheritdoc />
        public LeafCompany(string name) : base(name)
        {
        }

        /// <inheritdoc />
        public LeafCompany(string name, string duty) : base(name, duty)
        {
        }

        /// <inheritdoc />
        public override void AddCompany(Company c)
        {
            Console.WriteLine("cant not add");
        }

        /// <inheritdoc />
        public override void RemoveCompany(Company c)
        {
            Console.WriteLine("cant not remove");

        }

        /// <inheritdoc />
        public override void Display(int depth)
        {
           Console.WriteLine("-"+this.name);
        }

        /// <inheritdoc />
        public override void DoDuty()
        {
         Console.WriteLine(Duty);
        }
    }
}
