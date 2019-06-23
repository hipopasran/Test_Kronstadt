namespace Test_Kronstadt
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            RailRoadData railroadData = null;

            var parser = new Parser();

            try
            {
                Console.WriteLine("Введите путь к файлу с конфигурацией: ");
                var fileName = Console.ReadLine();
                railroadData = parser.ReadAndFill(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            MapManager map = new MapManager(railroadData);

            string result = map.CheckMap();
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
