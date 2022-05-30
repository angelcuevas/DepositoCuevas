using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DepositoCuevas.classes
{
    
    public class CanvasHelper
    {
        private Canvas canvas;

        public CanvasHelper(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void drawRectangle(RectangleArguments args, Action<string> delFuntion = null)
        {
            Border border= new Border();
            Rectangle rectangle = new Rectangle();

            rectangle.Width = args.Width;
            rectangle.Height = args.Height;
            //rectangle.Fill = args.Fill;
            
            //border.Width = args.Width;
            //border.Height = args.Height;
            if (args.showBorder)
            {
                SolidColorBrush strokeColor = new SolidColorBrush(Color.FromArgb(150, (byte)10, (byte)10, (byte)10));
                rectangle.Stroke = strokeColor;
                border.Style = getHoverStyle(args);

            }
            else
            {
                //border.Background = args.Fill;
            }
            canvas.Children.Add(border);
            border.Child = rectangle;
            Canvas.SetLeft(border, args.Left);
            Canvas.SetTop(border, args.Top);

            //if(delFuntion != null) {
            //    border.IsMouseDirectlyOverChanged += delegate (object sender, DependencyPropertyChangedEventArgs eventArgs)
            //    {
            //        delFuntion("");
            //    };
            //}
        }



        public Style getHoverStyle(RectangleArguments args)
        {
            SolidColorBrush hoverColor = new SolidColorBrush(Colors.Black);
            SolidColorBrush testColor = new SolidColorBrush(Colors.Red);

            Setter setter = new Setter();
            setter.Property = Border.BackgroundProperty;
            setter.Value = hoverColor;

            Setter bgSetter = new Setter();
            bgSetter.Property = Border.BackgroundProperty;
            bgSetter.Value = testColor;

            Setter widthSetter = new Setter();
            widthSetter.Property = Border.WidthProperty;
            widthSetter.Value = args.Width;

            Setter heightSetter = new Setter();
            heightSetter.Property = Border.HeightProperty;
            heightSetter.Value = args.Height;

            Trigger trigger = new Trigger();
            trigger.Property = Border.IsMouseOverProperty;
            trigger.Value = true;
            trigger.Setters.Add(setter);

            Trigger trigger2 = new Trigger();
            trigger2.Property = Border.IsMouseOverProperty;
            trigger2.Value = false;
            trigger2.Setters.Add(bgSetter);

            Style myStyle = new Style();
            myStyle.TargetType = typeof(Border);
            myStyle.Setters.Add(bgSetter);
            myStyle.Triggers.Add(trigger2);
            myStyle.Triggers.Add(trigger);

            return myStyle;
        }
    }
}
