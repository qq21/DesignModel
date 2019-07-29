using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_享元模式
{
    class WebFlyWeight
    {

        public void Start()
        {
            WebSiteFactory wf = new WebSiteFactory();
            WebSite w1 = wf.GetWebSite("w1");
            w1.Use( new User("咪咪"));
            WebSite w2 = wf.GetWebSite("w2");
            w2.Use(new User("小白"));
            WebSite w3 = wf.GetWebSite("w3");
            w3.Use(new User("路飞")); 

            WebSite w4 = wf.GetWebSite("w4");
            w4.Use(new User("鸣人"));
            WebSite w5 = wf.GetWebSite("w5");
             w4.Use(new User("六臂神童"));
            WebSite w6 = wf.GetWebSite("w6")
                ;
            w6.Use(new User("后裔"));

            Console.WriteLine($"网站总数:{wf.Count}");
        }

}

    public abstract class WebSite
    {
        public abstract void Use(User user);
    }

    public class User
    {
        private string name;

        /// <inheritdoc />
        public User(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => name;
        }
    }

    public class ConcretaWebSize:WebSite
    {
        private string name;

        public string Name
        {
            get => name;
        }

        /// <inheritdoc />
        public ConcretaWebSize(string name)
        {
            this.name = name;
        }

 

        /// <inheritdoc />
        public override void Use(User user)
        {
            Console.WriteLine("网站分类:" + name+$"用户名：{user.Name}"); 
        }
    }

    public class WebSiteFactory
    {
        private Hashtable flyWeights;

        /// <inheritdoc />
        public WebSiteFactory()
        {
            flyWeights=new Hashtable();
        }

        public WebSite GetWebSite(string key)
        {
            if (!flyWeights.ContainsKey(key))
            {
                flyWeights.Add(key, new ConcretaWebSize(key));
            }
            
                return flyWeights[key] as WebSite;
            
        }

        public int Count => flyWeights.Count;
    }
}
