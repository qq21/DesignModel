using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_访问者模式
{
    public abstract  class IVisitor
    {
        public abstract void Visit(BaseElement baseElement);
    }

    public class DepthVisitor:IVisitor
    {
        private int totalDepth;

        public int TotalDepth
        {
            get => totalDepth;
        }

        private int maxDepth;

        public int MaxDepth
        {
            get => maxDepth;
        }
        BaseElement maxBaseElement;

        public BaseElement MaxBaseElement
        {
            get => maxBaseElement;
        }

        /// <inheritdoc />
        public override void Visit(BaseElement baseElement)
        {
            int temp = MaxDepth;
            maxDepth = Math.Max(baseElement.Depth,maxDepth);
            if (temp!=maxDepth)
            {
                maxBaseElement = baseElement;
            }
            
            totalDepth += baseElement.Depth;

        }
    }

    public abstract class BaseElement
    {
        public abstract void Accept(IVisitor visitor);
        protected int id;

        public int Id
        {
            get => id;
        }

        protected int depth;

        public int Depth
        {
            get => depth;
            set => depth = value;
        }

        /// <inheritdoc />
        protected BaseElement()
        {
            MyObjectStructure.Instance.AddElement(this);
            depth = 0;
        }

        /// <inheritdoc />
        protected BaseElement(int id, int depth)
        {
            this.id = id;
            this.depth = depth;
            MyObjectStructure.Instance.AddElement(this);
        }
    }

    public class UIButton : BaseElement
    {
        /// <inheritdoc />
        public UIButton(int id, int depth) : base(id, depth)
        {
        }

        /// <inheritdoc />
        public UIButton()
        {
            this.Depth = 10;
        }

        /// <inheritdoc />
        public override void Accept(IVisitor visitor)
        {
             visitor.Visit(this);
        }
    }

    public  class  UISprite:BaseElement
    {
        /// <inheritdoc />
        public UISprite()
        {
            this.Depth = 1;
        }

        /// <inheritdoc />
        public UISprite(int id, int depth) : base(id, depth)
        {
        }

        /// <inheritdoc />
        public override void Accept(IVisitor visitor)
        {
             visitor.Visit(this);
        }
    }

    public class  PanelElement:BaseElement
    {
        /// <inheritdoc />
        public PanelElement()
        {
            this.Depth = 2000;
        }

        /// <inheritdoc />
        public PanelElement(int id, int depth) : base(id, depth)
        {
        }

        /// <inheritdoc />
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);    
        }
    }

    public class MyObjectStructure
    {
        private List<BaseElement> emElements;

        public static MyObjectStructure Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance=new MyObjectStructure();
                }

                return _instance;
            }
        }

        /// <inheritdoc />
        public MyObjectStructure()
        {
            emElements = new List<BaseElement>();
          
        }

        private static MyObjectStructure _instance;

        public void AddElement(BaseElement element)
        {
            emElements.Add(element);
        }

        public void RemoveElement(BaseElement element)
        {
            emElements.Remove(element);
        }

        public void VisitAll(IVisitor iVisitor)
        {
            foreach (var  e in emElements )
            {
                e.Accept(iVisitor);
            }
        }
    }
}
