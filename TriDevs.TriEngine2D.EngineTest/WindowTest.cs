using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using TriDevs.TriEngine2D.Audio;
using TriDevs.TriEngine2D.Input;

namespace TriDevs.TriEngine2D.EngineTest
{
    public class WindowTest : GameWindow
    {
        private string _activeSong = "unknown1";

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
            Services.Provide(new InputManager(this), new AudioManager());
            Services.Audio.LoadSong("unknown1", "menu1.ogg");
            Services.Audio.LoadSong("call", "menu2.ogg");
            Services.Audio.LoadSong("pirates", "menu3.ogg").IsLooped = true;
            Services.Audio.LoadSound("test", "test1.wav");
            Services.Audio.LoadSound("test2", "test2.wav");
            //Services.Audio.LoadSong("unknown2", "menu4.ogg");
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

            if (Services.Input.KeyPressed(Key.Number1))
                _activeSong = "unknown1";
            else if (Services.Input.KeyPressed(Key.Number2))
                _activeSong = "call";
            else if (Services.Input.KeyPressed(Key.Number3))
                _activeSong = "pirates";

            var song = Services.Audio.GetSong(_activeSong);

            if (Services.Input.KeyPressed(Key.P))
                song.Play();
            else if (Services.Input.KeyPressed(Key.S))
                song.Stop();
            else if (Services.Input.KeyPressed(Key.U))
                song.Pause();
            else if (Services.Input.KeyPressed(Key.R))
                song.Resume();
            else if (Services.Input.KeyPressed(Key.L))
                song.IsLooped = !song.IsLooped;

            if (Services.Input.KeyPressed(Key.Space))
                Services.Audio.GetSound("test").Play();
            else if (Services.Input.KeyPressed(Key.B))
                Services.Audio.GetSound("test2").Play();
        }

        protected override void OnUnload(EventArgs e)
        {
            Services.Audio.Dispose();

            base.OnUnload(e);
        }
    }
}
