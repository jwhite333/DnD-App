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
        Timer resizeTimer = new Timer(100) { Enabled = false };
        private static UIBindings.UIContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new UIBindings.UIContext();
            DataContext = context.Get(this);
            resizeTimer.Elapsed += new ElapsedEventHandler(ResizingDone);
        }

        void ResizingDone(object sender, ElapsedEventArgs e)
        {
            resizeTimer.Stop();
            MainWindow.DataContext = context.Get(this);
        }

        public void SizeChange(object sender, SizeChangedEventArgs e)
        {
            resizeTimer.Stop();
            resizeTimer.Start();
        }
    }
}
