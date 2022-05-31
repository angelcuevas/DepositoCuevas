using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        public void drawRectangle(RectangleArguments args, Action<string> delFuntion = null, Action<string> onClickFunction = null)
        {
            Border border= new Border();

            Grid rectangleGrid = new Grid();
            TextBlock rectangleText = new TextBlock();
            rectangleText.Text = args.text;
            rectangleText.TextAlignment = TextAlignment.Center;
            rectangleText.FontSize = 10;
            rectangleText.VerticalAlignment = VerticalAlignment.Center;

            if (args.isBold)
            {
                rectangleText.FontWeight = FontWeights.Bold;
            }
            
            Rectangle rectangle = new Rectangle();
            rectangleGrid.Children.Add(rectangleText);
            rectangleGrid.Children.Add(rectangle);

            rectangleGrid.Width = args.Width;
            rectangleGrid.Height = args.Height;

            canvas.Children.Add(border);
            border.Child = rectangleGrid;
            Canvas.SetLeft(border, args.Left);
            Canvas.SetTop(border, args.Top);

            if (args.showBorder)
            {
                SolidColorBrush strokeColor = new SolidColorBrush(Color.FromArgb(150, (byte)10, (byte)10, (byte)10));
                rectangle.Stroke = strokeColor;
            }
            else
            {
                border.Background = args.Fill;
            }

            if (args.differentColorOnHover)
            {
                border.Style = getHoverStyle(args);
            }
            else if(args.Fill != null)
            {
                border.Background = args.Fill;
            }

            if (delFuntion != null)
            {
                border.MouseEnter += delegate (object sender, MouseEventArgs e)
                {
                    delFuntion("");
                };
            }

            if (delFuntion != null)
            {
                border.MouseEnter += delegate (object sender, MouseEventArgs e)
                {
                    delFuntion("");
                };
            }

            if (onClickFunction != null)
            {
                border.MouseDown += delegate (object sender, MouseButtonEventArgs e)
                {
                    onClickFunction("");
                };
            }


        }



        public Style getHoverStyle(RectangleArguments args)
        {
            SolidColorBrush hoverColor = new SolidColorBrush(Colors.Red);

            Setter setter = new Setter();
            setter.Property = Border.BackgroundProperty;
            setter.Value = hoverColor;

            Setter bgSetter = new Setter();
            bgSetter.Property = Border.BackgroundProperty;
            bgSetter.Value = args.Fill;

            Setter punteroSetter = new Setter();
            punteroSetter.Property = Border.CursorProperty;
            punteroSetter.Value = Cursors.Hand;


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

            Style myStyle = new Style();
            myStyle.TargetType = typeof(Border);
            myStyle.Setters.Add(bgSetter);
            myStyle.Setters.Add(punteroSetter);
            myStyle.Triggers.Add(trigger);
           

            return myStyle;
        }

        public void WriteText(CanvasTextArguments args)
        {
            TextBlock txt = new TextBlock();
            txt.Text = args.text;

            txt.FontSize = args.size;

            Canvas.SetLeft(txt,args.x);
            Canvas.SetTop(txt,args.y);
            canvas.Children.Add(txt);

            if (args.isBold)
            {
                txt.FontWeight = FontWeights.Bold;
            }
        }

        public void drawImage(ImageArguments args)
        {
            Grid grid = new Grid();
            Image image = new Image();

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(@"/images/" + args.imageName, UriKind.Relative);
            logo.EndInit();


            image.Source = logo;

            if (args.width != -1) {
                grid.Width = args.width;
            }
            if (args.height != -1) {
                grid.Height = args.height;
            }
            image.HorizontalAlignment = HorizontalAlignment.Stretch;
            image.VerticalAlignment = VerticalAlignment.Stretch;
            grid.Children.Add(image);
            

            Canvas.SetLeft(grid, args.x);
            Canvas.SetTop(grid, args.y);
            canvas.Children.Add(grid);
        }



    }
}
