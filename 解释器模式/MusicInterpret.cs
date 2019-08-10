using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 解释器模式
{
    /// <summary>
    /// 音乐解释器
    /// </summary>
    public class MusicInterpret
    {
        public void Start()
        {
            PlayContext context=new PlayContext();

            context.PlayText =
                "O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 N O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 ";
            Expression expression=new Note();  
            try
            {
                while (context.PlayText.Length>0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    switch (str)
                    {
                        case "S":
                            expression = new Scale(); //音阶 根据 第一个 字符实例为 音阶 或者 音符
                            break;
                        case "C":break;
                        case "D":break;

                        case "N":
                            expression=new Note();  //为N时 实例为  音符
                            break;


                    }
                    expression.Interpret(context);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
              
            }

        }
    }
        
    public class PlayContext
    {
        //演奏文本
        private string text;

        public string PlayText
        {
            get { return text; }
            set { text = value; }
        }
    }

   public abstract class Expression
    {
        //解释器
        public void Interpret(PlayContext context)
        {
            if (context.PlayText.Length==0)
            {
                return;
            }
            else
            {
                string playkey = context.PlayText.Substring(0, 1);
                context.PlayText = context.PlayText.Substring(2);

        //        double playValue = Convert.ToDouble(context.PlayText.Substring(0, context.PlayText.IndexOf(" ")));
                
            }
        }

        public abstract void Excute(string key,double value);
    }

   /// <summary>
   /// 音符
   /// </summary>
   public class Note : Expression
   {
       /// <inheritdoc />
       public override void Excute(string key, double value)
       {
           string note = " ";
           switch ( key)
           {
                case "C":
                    note = "1";
                break;
                case "D":
                    note = "2";
                    break;
                case "E":
                    note = "3";
                    break;
                case "F":
                    note = "4";
                    break;
                case "G":
                    note = "5";
                    break;
                case "A":
                    note = "6";
                    break;
                case "B":
                    note = "7";
                    break;
            }
           Console.WriteLine($"{note}");
        }
   }

   public class Scale : Expression
   {
       /// <inheritdoc />
       public override void Excute(string key, double value)
       {
           string scale = "";
           switch (Convert.ToInt32(value))
           {
                case 1:
                    scale = "低音";
                    break;
                case 2:
                    scale = "中音";
                    break;
                case 3:
                    scale = "高音";
                    break;
            }
          Console.WriteLine($"{scale}");
        }
   }
   


}
