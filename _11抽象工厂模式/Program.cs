using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _11抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
                IFactory sqlFactory=new SqlUserFactory();

                Department dp=new Department(10,"开发部");

                User user=new User(8,"小米");
                IUser iu=new AccessUser();
                iu.Insert(user);

                SqlDepartment sd= sqlFactory.CreDepartment() as SqlDepartment;
                sd.Insert(new Department(1,"行政部"));
                sd.GetDepartment(1);


                #region   依赖注入

                IUser user2 = Assembly.Load("_11抽象工厂模式").CreateInstance("_11抽象工厂模式.SqlserverUser") as IUser;
                //加载程序集 取得命名空间下的类名

                
                #endregion
        }
    }

    public class User
    {
        private int id;

        /// <inheritdoc />
        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        private string name;

    }

    public interface IUser
    {
        void Insert(User u);
        User GetUser(int id);
    }

    public class SqlserverUser : IUser
    {
        /// <inheritdoc />
        public void Insert(User u)
        {
            Console.WriteLine("在Sql server中 插入一条 记录");
        }

        /// <inheritdoc />
        public User GetUser(int id)
        {
            Console.WriteLine("在SQL server 中根据 id得到 User表的一条记录");
            return null;
        }
    }

    public class AccessUser : IUser
    {
        /// <inheritdoc />
        public void Insert(User u)
        {
            Console.WriteLine("在AccessUser   中 插入一条 记录");
        }

        /// <inheritdoc />
        public User GetUser(int id)
        {
            Console.WriteLine("在AccessUser 中根据 id得到 User表的一条记录");
            return null;
        }
    }

    public interface IFactory
    {
        IUser CreateUser();
        IDepartment CreDepartment();
    }

    public class SqlUserFactory : IFactory
    {
        /// <inheritdoc />
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }

        /// <inheritdoc />
        public IDepartment CreDepartment()
        {
            return new SqlDepartment();
        }
    }

    public class AccessUserFactory : IFactory
    {
        /// <inheritdoc />
        public IUser CreateUser()
        {
            return new AccessUser();
        }

        /// <inheritdoc />
        public IDepartment CreDepartment()
        {
            return new AssetDepartment();
        }
    }

    public class Department
    {
        private int _id;
        private string DepartmentName;

        /// <inheritdoc />
        public Department(int id, string departmentName)
        {
            _id = id;
            DepartmentName = departmentName;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string DepartmentName1
        {
            get => DepartmentName;
            set => DepartmentName = value;
        }
    }
    public interface IDepartment
    {
        void Insert(Department d);
        Department GetDepartment(int id);
    }

    public class SqlDepartment : IDepartment
    {
        /// <inheritdoc />
        public void Insert(Department d)
        {
            Console.WriteLine("在SqlDepartment 中 插入一条 记录");
        }

        /// <inheritdoc />
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在SqlDepartment 中根据 id得到 User表的一条记录");
            return null;
        }
    }

    public class AssetDepartment : IDepartment
    {   
        /// <inheritdoc />
        public void Insert(Department d)
        {
            Console.WriteLine("在AssetDepartment 中 插入一条 记录");
        }

        /// <inheritdoc />
        public Department GetDepartment(int id)
        {
            Console.WriteLine("在AssetDepartment 中根据 id得到 User表的一条记录");
            return null;
        }
    }

  ///抽象工厂 需要添加太多抽象类不台适用，
  /// 改进方法 是结合简单工厂 用一个DataAssest类 来代替，3个工厂类，sqlUserFactory AccessUserFactory
  /// 结合简单工厂 可以 利用配置表;
  public class DataClass
  {
      public static string db="SqlServer";
      //  assert
      public static IUser CreateUserFactory()
      {
          IUser u;
          switch (db)
          {
                case "SqlServer":
                    SqlUserFactory sqlUserFactory=new SqlUserFactory();
                    u= sqlUserFactory.CreateUser();
                    return u;
                    
                   
                case "asset":
                    AccessUserFactory accessUserFactory=new AccessUserFactory();
                    u = accessUserFactory.CreateUser();
                    return u;
                    
          }

          return null;
      }

      public static IDepartment CreateDepartment()
      {
          IDepartment department;
          switch (db)
          {
              
              case "SqlServer":
                    department=  new SqlDepartment();
                    return department;
                    break;
                   
              case "asset":
                  department= new AssetDepartment();
                  return department;
                  break;
                
            }

          return null;
      }

      public static void CrreateDepatmentFactory()
      {
          switch (db)
          {
              case "sever": break;
              case "asset": break;
          }
        }

  }

  public class DataAccess
  {
      public static readonly string AssemblyName = "抽象工厂模式";
      public static readonly string db = "Sqlserver"; //这里可以用读取  的方式

      public static IUser CreateUser()
      {
          string className = AssemblyName + "." + db + "User";
          return Assembly.Load(AssemblyName).CreateInstance(className) as IUser;
      }

      public static IDepartment CreateDepartment()
      {
          string className = AssemblyName + "." + db + "Department";
          return Assembly.Load(AssemblyName).CreateInstance(className) as IDepartment;
      }

  }


}


