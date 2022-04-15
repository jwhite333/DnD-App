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
        // Subclass definitions
        public MajorStatsBindings MajorStatIcons { get; set; }

        // Constructor
        public UIBindings(MainWindow window)
        {
            MajorStatIcons = new MajorStatsBindings(window);
        }
    }

    public class UIContext
    {
        public UIBindings Get(MainWindow window)
        {
            return new UIBindings(window);
        }
    }


    //public class TestConverter : IValueConverter
    //{
    //    public Thickness thickness;

    //    public Thickness Thickness
    //    {
    //        get
    //        {
    //            return thickness;
    //        }
    //        set
    //        {
    //            thickness = value;
    //        }
    //    }
    //    public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return thickness;
    //    }
    //    public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return null;
    //    }
    //}
}
