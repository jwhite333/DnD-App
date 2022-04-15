using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace DndApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static UIBindings.UIContext context;
        ScaleTransform scaleTransform;
        Point start, origin;
        public MainWindow()
        {
            InitializeComponent();
            context = new UIBindings.UIContext();
            DataContext = context.Get(this);

            scaleTransform = new ScaleTransform();
            WorldMapImage.LayoutTransform = scaleTransform;
        }

        public void SizeChange(object sender, SizeChangedEventArgs e)
        {
            return;
        }

        public void SliderMouseOver(object sender, EventArgs e)
        {
            SliderTooltip.IsOpen = true;
        }
        public void SliderMouseLeave(object sender, EventArgs e)
        {
            SliderTooltip.IsOpen = false;
        }

        // World Map

        public void ZoomSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Console.WriteLine("Trying to change resolution");
            Binding bindX = new Binding();
            bindX.Source = ZoomSlider;
            bindX.Path = new PropertyPath("Value");
            BindingOperations.SetBinding(scaleTransform, ScaleTransform.ScaleXProperty, bindX);
            Binding bindY = new Binding();
            bindY.Source = ZoomSlider;
            bindY.Path = new PropertyPath("Value");
            BindingOperations.SetBinding(scaleTransform, ScaleTransform.ScaleYProperty, bindY);

        }

        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var st = scale_t;
            double zoom = e.Delta > 0 ? 2 : -2;
            st.ScaleX += zoom;
            st.ScaleY += zoom;
            if (st.ScaleX < 1 || st.ScaleY < 1)
            {
                st.ScaleX = 1;
                st.ScaleY = 1;
            }
        }

        public void MapMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            var tt = translate_t;
            start = e.GetPosition(WorldMapBorder);
            origin = new Point(tt.X, tt.Y);
            WorldMapImage.CaptureMouse();
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (WorldMapImage.IsMouseCaptured)
            {
                var tt = translate_t;
                Vector v = start - e.GetPosition(WorldMapBorder);
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
        }

        private void image_release(object sender, MouseButtonEventArgs e)
        {
            WorldMapImage.ReleaseMouseCapture();
        }
    }
}
