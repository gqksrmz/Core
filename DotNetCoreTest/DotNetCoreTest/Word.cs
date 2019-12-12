using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Aspose.Words;
using Aspose.Words.Tables;

namespace DotNetCoreTest
{
    public class Word
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("aaa");
            Console.WriteLine("aaa");
            Console.WriteLine("aaa");
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
            //开始添加表格
            Table table = builder.StartTable();
            //开始添加第一行，并设置表格行高
            RowFormat rowf = builder.RowFormat;
            rowf.Height = 40;
            //。。。这里rowf可以有很多的设置
            //插入如一个单元格
            builder.InsertCell();
            //设置单元格是否水平合并，None为不合并
            builder.CellFormat.HorizontalMerge = CellMerge.None;
            //设置单元格是否垂直合并，None为不合并
            builder.CellFormat.VerticalMerge = CellMerge.None;
            //设置单元格宽
            builder.CellFormat.Width = 40;
            //单元格垂直对齐方向
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            //单元格水平方向对齐
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            //单元格内文字设为多行（默认为单行，会影响单元格行宽）
            builder.CellFormat.FitText = true;
            //单元格内添加文字
            builder.Write("这里是第一行第一个单元格");
            builder.InsertCell();
            //当不需要规定这个单元格的宽度的时候，设置称成-1，会是自动宽度
            builder.CellFormat.Width = -1;
            builder.Write("这是第一行第二个单元格");
            //结束第一行
            builder.EndRow();
            //结束表格
            builder.EndTable();
            //设置这个表格的上下左右，内部水平，垂直的线为白色（当背景为白色的时候就相当于隐藏边框了）
            table.SetBorder(BorderType.Left,LineStyle.Double,1,Color.White,false);
            table.SetBorder(BorderType.Top,LineStyle.Double,1,Color.White,false);
            table.SetBorder(BorderType.Right,LineStyle.Double,1,Color.White,false);
            table.SetBorder(BorderType.Bottom,LineStyle.Double,1,Color.White,false);
            table.SetBorder(BorderType.Vertical, LineStyle.Double, 1, Color.White, false);

            //横向合并单元格
            builder.CellFormat.HorizontalMerge = CellMerge.None;
            builder.CellFormat.HorizontalMerge = CellMerge.First;
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            //纵向合并单元格
            builder.CellFormat.VerticalMerge = CellMerge.None;
            builder.CellFormat.VerticalMerge = CellMerge.First;
            builder.CellFormat.VerticalMerge = CellMerge.Previous;

            document.Save(@"C:\Users\DELL\Desktop\a.doc");
        }
    }
}
