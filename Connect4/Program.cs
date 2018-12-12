using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Connect4
{
    class Program
    {
        //static void OnClose(object sender, EventArgs e)
        //{
        //    RenderWindow window = (RenderWindow)(sender);
        //    window.Close();
        //}

        static void Main(string[] args)
        {
            //RenderWindow window = new RenderWindow(new VideoMode(500, 500), "Bitboard Connect4");
            //window.Closed += new EventHandler(OnClose);
            //while (window.IsOpen)
            //{
            //    window.Clear();
            //    window.DispatchEvents();
            //    window.Display();
            //}
            var engine = new ConsoleEngine();
            engine.Run();
        }
    }
}
