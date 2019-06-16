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

        public void MapMouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            return;
        }

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

        
    }
}
