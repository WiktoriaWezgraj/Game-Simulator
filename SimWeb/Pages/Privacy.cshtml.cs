using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
namespace SimWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        public SimulationHistory GenerateSimulationHistory()
        {
            Map map = new BigBounceMap(8, 6);

            // Lista obiektów poruszających się po mapie
            List<IMappable> creatures = new()
            {
                new Elf("Elandor"),
                new Orc("Gorbag"),
                new Animals { Description = "Rabbits", Size = 2 },
                new Birds { Description = "Ostriches", Size = 1, CanFly = false },
                new Birds { Description = "Eagles", Size = 1, CanFly = true }
            };

            // Początkowe pozycje obiektów
            List<Point> positions = new()
            {
                new Point(1, 2),
                new Point(2, 5),
                new Point(3, 1),
                new Point(4, 5),
                new Point(0, 0)
            };

            // Ciąg ruchów
            string moves = "dlrludluddlrulrdlurl";

            Simulation sim = new(map, creatures, positions, moves);
            return new SimulationHistory(sim);
        }

        public string GenerateGridHTML(SimulationHistory history, int turn)
        {
            string output = "";
            for (int i = 0; i < history.SizeY; i++)
            {
                for (int j = 0; j < history.SizeX; j++)
                {
                    string symbol = history.TurnLogs[turn].Symbols.ContainsKey(new Point(j, i))
                        ? history.TurnLogs[turn].Symbols[new Point(j, i)].ToString()
                        : "";

                    symbol = symbol switch
                    {
                        "b" => "Bnielot",
                        "B" => "Blot",
                        "" => "Blank",
                        _ => symbol
                    };

                    string image = $"<img src=\"/css/{symbol}.png\">";
                    output += $"<div class=\"grid-item\">{image}</div>";
                }
            }
            return output;
        }

        public string GridHTML { get; private set; } = "";
        public SimulationHistory? SimHistory { get; private set; }
        public int Turn { get; private set; }
        public string Info { get; private set; } = "";

        public void OnGet()
        {
            // Pobierz obecny numer tury z sesji
            Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
            SimHistory = GenerateSimulationHistory();

            // Generuj HTML siatki
            GridHTML = GenerateGridHTML(SimHistory, Turn);
            HttpContext.Session.SetString("grid", GridHTML);
        }

        public void OnPost()
        {
            // Pobierz obecny numer tury z sesji
            Turn = HttpContext.Session.GetInt32("Turn") ?? 0;

            // Zmiana tury na podstawie akcji użytkownika
            string action = Request.Form["turnchange"];
            Turn = action switch
            {
                "prev" => Math.Max(0, Turn - 1),
                "next" => Math.Min(20, Turn + 1),
                _ => Turn
            };

            HttpContext.Session.SetInt32("Turn", Turn);

            SimHistory = GenerateSimulationHistory();
            GridHTML = GenerateGridHTML(SimHistory, Turn);
        }
    }
}

