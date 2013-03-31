using System;
using OpenTK;
using OpenTK.Input;
using QuickFont;
using TriDevs.TriEngine2D.Audio;
using TriDevs.TriEngine2D.Graphics;
using TriDevs.TriEngine2D.Input;
using TriDevs.TriEngine2D.Text;
using TriDevs.TriEngine2D.UI;

namespace TriDevs.TriEngine2D.EngineTest
{
    public class Window2DTest : GameWindow2D
    {
        private string _activeSong = "unknown1";
        private IControlManager _controlManager;
        private IControl _control;
        private bool _clickToggle;
        private Font _font;
        private TextObject _text;
        private Label _label;
        private LinkLabel _link;

        private Triangle _triangle;
        private Graphics.Rectangle _rectangle;

        [STAThread]
        public static void Main(string[] args)
        {
            using (var test = new Window2DTest())
            {
                test.Run(30.0);
            }
        }

        private Window2DTest() : base(800, 600, "TriEngine2D Test")
        {
            Services.Provide(new InputManager(this), new AudioManager());
            _controlManager = new ControlManager();
            Services.Audio.LoadSong("unknown1", "menu1.ogg");
            Services.Audio.LoadSong("call", "menu2.ogg");
            Services.Audio.LoadSong("pirates", "menu3.ogg").IsLooped = true;
            Services.Audio.LoadSound("test", "test1.wav");
            Services.Audio.LoadSound("test2", "test2.wav");
            //Services.Audio.LoadSong("unknown2", "menu4.ogg");
            _font = Resources.LoadFont("Anon", "Anonymous.ttf", 32);
            _control = new Label
            {
                Rectangle = new Rectangle(100, 100, 250, 250),
                Color = Color.Green,
                Alignment = QFontAlignment.Left,
                Text = "Test"
            };
            ((Label) _control).SetFont(_font);
            _control.Clicked += ControlClicked;
            _controlManager.AddControl(_control);
            _text = new TextObject("Hello, World!", _font, new Point<int>(100, 50), QFontAlignment.Left);
            _label = new Label();
            _label.SetFont(_font);
            _label.Position = new Point<int>(250, 300);
            _label.Text = "Foo Bar Baz";
            _label.Alignment = QFontAlignment.Right;
            _controlManager.AddControl(_label);
            _link = new LinkLabel();
            _link.SetFont(_font);
            _link.Position = new Point<int>(300, 500);
            
            _link.Text = "Go to google";
            _link.Alignment = QFontAlignment.Centre;
            _link.Url = "http://www.google.com/";
            _controlManager.AddControl(_link);

            _triangle = new Triangle(new Point<int>(100, 25), new Point<int>(50, 100), new Point<int>(150, 100));
            _rectangle = new Graphics.Rectangle(new Rectangle(200, 100, 100, 200));
        }

        private void ControlClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Control clicked!");
            if (_clickToggle)
            {
                _control.Color = Color.Green;
                _control.Position = new Point<int>(100, 100);
                _clickToggle = false;
                _label.Text = "Foo Bar Baz";
            }
            else
            {
                _control.Color = Color.Red;
                _control.Position = new Point<int>(200, 200);
                _clickToggle = true;
                _label.Text = "Baz Bar Foo";
            }
        }

        private string GetMemUsageString()
        {
            var mem = (float) GC.GetTotalMemory(false);
            string[] types = {"B", "KB", "MB", "GB"};
            var order = 0;
            while (mem >= 1024 && order + 1 < types.Length)
            {
                order++;
                mem /= 1024;
            }
            return string.Format("{0:0.###} {1}", mem, types[order]);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            Services.Input.Update();

            Title = string.Format("TriEngine2D Test X: {0}; Y: {1}; Mem: {2}", Services.Input.MouseX, Services.Input.MouseY, GetMemUsageString());

            if (!Focused)
                return;

            if (Services.Input.KeyPressed(Key.Number1))
            {
                _activeSong = "unknown1";
                Console.WriteLine("Selected song " + _activeSong);
            }
            else if (Services.Input.KeyPressed(Key.Number2))
            {
                _activeSong = "call";
                Console.WriteLine("Selected song " + _activeSong);
            }
            else if (Services.Input.KeyPressed(Key.Number3))
            {
                _activeSong = "pirates";
                Console.WriteLine("Selected song " + _activeSong);
            }

            var song = Services.Audio.GetSong(_activeSong);

            if (Services.Input.KeyPressed(Key.P))
            {
                Console.WriteLine("Playing " + _activeSong);
                song.Play();
            }
            else if (Services.Input.KeyPressed(Key.S))
            {
                Console.WriteLine("Stopping " + _activeSong);
                song.Stop();
            }
            else if (Services.Input.KeyPressed(Key.U))
            {
                Console.WriteLine("Pausing " + _activeSong);
                song.Pause();
            }
            else if (Services.Input.KeyPressed(Key.R))
            {
                Console.WriteLine("Resuming " + _activeSong);
                song.Resume();
            }
            else if (Services.Input.KeyPressed(Key.L))
            {
                song.IsLooped = !song.IsLooped;
                Console.WriteLine(_activeSong + " is {0} looping", song.IsLooped ? "now" : "no longer");
            }
            else if (Services.Input.KeyPressed(Key.Minus))
            {
                song.Volume -= 0.1f;
                Console.WriteLine("Volume of " + _activeSong + " set to {0}", song.Volume);
            }
            else if (Services.Input.KeyPressed(Key.Plus))
            {
                song.Volume += 0.1f;
                Console.WriteLine("Volume of " + _activeSong + " set to {0}", song.Volume);
            }

            if (Services.Input.KeyPressed(Key.Space))
                Services.Audio.GetSound("test").Play();
            else if (Services.Input.KeyPressed(Key.B))
                Services.Audio.GetSound("test2").Play();

            _controlManager.Update();
        }

        protected override void OnDraw(FrameEventArgs e)
        {
            _controlManager.Draw();

            _text.Draw();

            _triangle.Draw();
            _rectangle.Draw();
        }

        protected override void OnUnload(EventArgs e)
        {
            Console.WriteLine("UNLOAD!");

            Services.Audio.Dispose();

            base.OnUnload(e);
        }
    }
}
