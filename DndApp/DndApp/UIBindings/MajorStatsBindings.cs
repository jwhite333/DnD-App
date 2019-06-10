using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DndApp.UIBindings
{
    public partial class UIBindings
    {
        public class MajorStatsBindings
        {
            public MajorStatsBindings(MainWindow window)
            {
                window.Dispatcher.Invoke(() =>
                {
                    var grid = (System.Windows.Controls.Grid)window.FindName("MainWindowGrid");
                    if (grid != null)
                    {
                        var marginRight = grid.ActualWidth / 3.0;
                        Margin = new Thickness(0, 0, marginRight, 0);
                        Size = (Double)grid.ActualHeight / 8.0;
                    }

                    var icon = (System.Windows.Controls.Canvas)window.FindName("IconStrCanvas");
                    if (icon != null)
                    {
                        String output = String.Format("Icon size: {0}x{1}", icon.Width, icon.Height);
                        Console.WriteLine(output);
                        FontSize = Math.Max((Double)icon.ActualHeight / 15, 5);
                        TextMargin = new Thickness(0, icon.ActualHeight / 8.0, 0, 0);
                    }
                });
            }
            public Thickness Margin { get; set; }
            public Double Size { get; set; }
            public Double FontSize { get; set; }
            public Thickness TextMargin { get; set; }
        }
    }
}
