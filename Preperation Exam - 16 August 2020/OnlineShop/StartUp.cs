using System.IO;
using OnlineShop.Core;
using OnlineShop.IO;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop
{
    public class StartUp
    {
        static void Main()
        {
            //var vgu = new VideoCard(1, "NVidia", "2060 Ti", 200, 100, 2);
            //var cpu = new CentralProcessingUnit(2, "Intel", "i7", 200, 100, 2);
            //var motherboard = new Motherboard(3, "nqkvaSiDunnaPlatka", "5", 400, 100, 3);
            //var ram = new RandomAccessMemory(4, "RAM", "45T", 150, 100, 5);

            //var mouse = new Mouse(10, "razer", "deathadder", 120, 20, "wired");
            //var headset = new Headset(20, "razer", "kraken7.1", 140, 17, "bluetooth");

            //var pc = new DesktopComputer(6, "Dell", "Inspiron", 500);
            //pc.AddComponent(vgu);
            //pc.AddComponent(cpu);
            //pc.AddComponent(motherboard);
            //pc.AddComponent(ram);
            //pc.AddPeripheral(mouse);
            //pc.AddPeripheral(headset);

            //System.Console.WriteLine(pc);

            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
