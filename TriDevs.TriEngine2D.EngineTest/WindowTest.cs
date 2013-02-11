using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using TriDevs.TriEngine2D.Input;

namespace TriDevs.TriEngine2D.EngineTest
{
    public class WindowTest : GameWindow
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (var test = new WindowTest())
            {
                test.Run(30.0);
            }
        }

        public WindowTest() : base(800, 600, GraphicsMode.Default, "TriEngine2D Test")
        {
            VSync = VSyncMode.On;
            Services.Provide(new InputManager(this));
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            Services.Input.Update();

            Title = string.Format("TriEngine2D Test X: {0}; Y: {1}", Services.Input.MouseX, Services.Input.MouseY);

            if (Services.Input.KeyPressed(Key.A))
                Console.WriteLine("Pressed A");
            else if (Services.Input.KeyReleased(Key.A))
                Console.WriteLine("Released A");

            if (Services.Input.ButtonPressed(MouseButton.Left))
                Console.WriteLine("Pressed LMB");
            else if (Services.Input.ButtonReleased(MouseButton.Left))
                Console.WriteLine("Released LMB");
        }
    }
}
