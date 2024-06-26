using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp.Behaviors;

// Install-Package Microsoft.Xaml.Behaviors.Wpf
class MouseEnterButtonBehavior : Behavior<Button>
{
    public System.Windows.Media.Color HighlightColor { get; set; }

    private System.Windows.Media.Brush _brush;
    protected override void OnAttached()
    {
        Button button = this.AssociatedObject;

        button.MouseEnter += (sender, e) => {
            _brush = button.Background;
            button.Background = new SolidColorBrush(HighlightColor); 
        };

       // button.MouseLeave += (sender, e) => { button.Background = _brush; };

    }
}
