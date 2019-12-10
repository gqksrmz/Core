using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Words;

namespace DotNetCoreTest
{
    public class Word
    {
        public static void Main(string[] args)
        {
            Document document=new Document();//新建一个空白文档
            //这里面的`builder`相当于一个画笔，提前给他规定样式，
            //然后他就能根据你的要求画出你想画的Word。这里的画笔使用的是就近原则，
            //当上面没有定义了builder的时候，会使用默认的格式，当上面定义了某个格式的时候，
            //使用最近的一个（即最后一个改变的样式）
            DocumentBuilder builder =new DocumentBuilder(document);
            builder.PageSetup.PaperSize = PaperSize.A4;//A4纸
            builder.PageSetup.Orientation = Orientation.Portrait;//方向
            builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;//垂直对准
            builder.PageSetup.LeftMargin = 42;//页面左边距
            builder.PageSetup.RightMargin = 42;//页面右边距
            //获取PargraphFormat对象，关于行的样式基本都在这里
            var ph = builder.ParagraphFormat;
            //文字对齐方式
            ph.Alignment = ParagraphAlignment.Center;
            //单行间距=12，1.5倍=18
            ph.LineSpacing = 12;
            //获取font对象，关于文字大小，颜色，字体等等基本都在这个里面
            Font font = builder.Font;
            //字体大小
            font.Size = 22;
            //是否粗体
            font.Bold = false;
            //下划线样式，None为无下划线
            font.Underline = Underline.None;
            //字体颜色
            font.Color=Color.Black;
            font.Color = Color.FromName("#3b3131");//自定义颜色
            //设置字体
            font.NameFarEast = "宋体";
            //添加文字
            builder.Write("添加的文字");
            //添加回车
            builder .Writeln();
            //添加文字后回车
            builder.Writeln("添加文字后回车");

            document.Save(@"C:\Users\DELL\Desktop\a.doc");
        }
    }
}
