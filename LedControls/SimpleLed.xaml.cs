using Microsoft.Graphics.Canvas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace LedControls
{
    public sealed partial class SimpleLed : UserControl
    {
        public static readonly DependencyProperty OnColorProperty = DependencyProperty.Register("OnColor", typeof(Color), typeof(SimpleLed), new PropertyMetadata(Colors.Lime));
        public static readonly DependencyProperty OffColorProperty = DependencyProperty.Register("OffColor", typeof(Color), typeof(SimpleLed), new PropertyMetadata(Colors.DarkSlateGray));

        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Color), typeof(SimpleLed), new PropertyMetadata(Colors.Black));
        public static readonly DependencyProperty BorderWidthProperty = DependencyProperty.Register("BorderWidth", typeof(double), typeof(SimpleLed), new PropertyMetadata(3.0));

        public static readonly DependencyProperty LedOnProperty = DependencyProperty.Register("LedOn", typeof(bool), typeof(SimpleLed), new PropertyMetadata(false));

        public double BorderWidth
        {
            get
            {
                return (double)GetValue(BorderWidthProperty);
            }

            set
            {
                if (BorderWidth != value)
                {
                    SetValue(BorderWidthProperty, value);

                    led.Invalidate();
                }
            }
        }

        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }

            set
            {
                if (BorderColor != value)
                {
                    SetValue(BorderColorProperty, value);

                    led.Invalidate();
                }
            }
        }

        public Color OnColor
        {
            get
            {
                return (Color)GetValue(OnColorProperty);
            }

            set
            {
                if (OnColor != value)
                {
                    SetValue(OnColorProperty, value);

                    led.Invalidate();
                }
            }
        }

        public Color OffColor
        {
            get
            {
                return (Color)GetValue(OffColorProperty);
            }

            set
            {
                if (OffColor != value)
                {
                    SetValue(OffColorProperty, value);

                    led.Invalidate();
                }
            }
        }

        public bool LedOn
        {
            get
            {
                return (bool)GetValue(LedOnProperty);
            }

            set
            {
                if (LedOn != value)
                {
                    SetValue(LedOnProperty, value);

                    led.Invalidate();
                }
            }
        }

        public string Text
        {
            get
            {
                return txtTitle.Text;
            }

            set
            {
                txtTitle.Text = value;
            }
        }

        public SimpleLed()
        {
            InitializeComponent();
        }

        private void led_Draw(Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs args)
        {
            led.Width = ActualHeight;
            led.Height = ActualHeight;

            using (CanvasDrawingSession canvas = args.DrawingSession)
            {
                // Calculate the centre of the led
                Vector2 centrePoint = new Vector2();

                centrePoint.X = (float)(led.ActualWidth / 2);
                centrePoint.Y = (float)(led.ActualHeight / 2);

                // Calculate the radius of the LED
                float ledRadius = (float)(ActualHeight / 2.0f);

                // Draw the LED
                if (LedOn)
                {
                    canvas.FillCircle(centrePoint, ledRadius, OnColor);
                }
                else
                {
                    canvas.FillCircle(centrePoint, ledRadius, OffColor);
                }

                // Draw the Border of the LED
                float borderRadius = (float)(ledRadius - (BorderWidth / 2));

                canvas.DrawCircle(centrePoint, borderRadius, BorderColor, (float)BorderWidth);
            }
        }
    }
}
