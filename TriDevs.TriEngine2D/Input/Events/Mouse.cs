using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Input;

namespace TriDevs.TriEngine2D.Input.Events
{
    /// <summary>
    /// Event handler delegate for the MouseDown event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse button information associated with the event.</param>
    public delegate void MouseDownEventHandler(object sender, MouseButtonEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseUp event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse button information associated with the event.</param>
    public delegate void MouseUpEventHandler(object sender, MouseButtonEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseWheelChanged event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse wheel information associated with the event.</param>
    public delegate void MouseWheelChangedEventHandler(object sender, MouseWheelEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseWheelDown event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse wheel information associated with the event.</param>
    public delegate void MouseWheelDownEventHandler(object sender, MouseWheelEventArgs e);

    /// <summary>
    /// Event handler delegate for the MouseWheelUp event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">Mouse wheel information associated with the event.</param>
    public delegate void MouseWheelUpEventHandler(object sender, MouseWheelEventArgs e);
}
