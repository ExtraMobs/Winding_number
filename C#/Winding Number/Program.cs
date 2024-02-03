using Polygon;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("    Olá, esse programa irá dizer se o seu ponto, está dentro do polígono estabelecido.");
        Console.WriteLine("    Para isso, começaremos digitando o X e o Y dos vértices.");
        Console.WriteLine("    Deixando em branco qualquer um dos dois, terminará a inserção de vértices.\n");
        
        List<float[]> points = new();
        
        float X, Y;
        string command;
        while (true)
        {
            Console.WriteLine(points.Count() + 1 + ".");
            Console.Write("    X ->");
            command = Console.ReadLine();
            if (command == "")
            {
                break;
            }
            X = float.Parse(command);

            Console.Write("    Y ->");
            command = Console.ReadLine();
            if (command == "")
            {
                break;
            }
            Y = float.Parse(command);
            Console.WriteLine("");

            points.Add([X, Y]);
        }

        while (true)
        {
            Console.WriteLine("\n\nInforme qual a posição do seu ponto.");
            Console.Write("    X ->");
            command = Console.ReadLine();
            if (command == "")
            {
                break;
            }
            X = float.Parse(command);
            Console.Write("    Y ->");
            command = Console.ReadLine();
            if (command == "")
            {
                break;
            }
            Y = float.Parse(command);

            if (new Polygon2D(points.ToArray()).CheckPointInside(new Point(X, Y)))
            {
                Console.WriteLine("\n\nSeu ponto está DENTRO do polígono.");
            } else {
                Console.WriteLine("\n\nSeu ponto está FORA do polígono.");
            }
        }
    }
}
