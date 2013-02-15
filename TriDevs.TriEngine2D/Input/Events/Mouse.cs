using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Input;

namespace TriDevs.TriEngine2D.Input.Events
{
    public delegate void MouseDownEventHandler(object sender, MouseButtonEventArgs e);

    public delegate void MouseUpEventHandler(object sender, MouseButtonEventArgs e);

    public delegate void MouseWheelChangedEventHandler(object sender, MouseWheelEventArgs e);

    public delegate void MouseWheelDownEventHandler(object sender, MouseWheelEventArgs e);

    public delegate void MouseWheelUpEventHandler(object sender, MouseWheelEventArgs e);
}
