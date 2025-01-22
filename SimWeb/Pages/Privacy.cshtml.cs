using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using Microsoft.AspNetCore.Http;
using System.Numerics;
using System.Net.WebSockets;

namespace SimWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        private static readonly List<char> Moves = new();

        public string Info { get; set; } = "Wprowadź ruch!";
        public int Turn { get; set; }
        public string GridHTML { get; private set; } = "";

        public SimulationHistory? SimHistory { get; private set; }

        public void OnGet()
        {
            // Pobierz wartości sesji lub ustaw domyślne, jeśli ich nie ma
            Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
            string storedMoves = HttpContext.Session.GetString("Moves") ?? "";
            Moves.Clear();
            Moves.AddRange(storedMoves);

            SimHistory = GenerateSimulationHistory(new string(Moves.ToArray()));
            GridHTML = GenerateGridHTML(SimHistory, Turn);
        }

        public void OnPost()
        {
            string? moveDirection = Request.Form["moveDirection"];
            if (moveDirection != null)
            {
                switch (moveDirection)
                {
                    case "up":
                        Moves.Add('u');
                        break;
                    case "down":
                        Moves.Add('d');
                        break;
                    case "left":
                        Moves.Add('l');
                        break;
                    case "right":
                        Moves.Add('r');
                        break;
                }
            }

            HttpContext.Session.SetString("Moves", new string(Moves.ToArray()));
            Info = $"Wprowadzono ruch: {moveDirection}";
            SimHistory = GenerateSimulationHistory(new string(Moves.ToArray()));

            // Obsługa zmiany tury
            Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
            string action = Request.Form["turnchange"];
            Turn = action switch
            {
                "prev" => Math.Max(0, Turn - 1),
                "next" => Math.Min(20, Turn + 1),
                _ => Turn
            };

            HttpContext.Session.SetInt32("Turn", Turn);
            GridHTML = GenerateGridHTML(SimHistory, Turn);

        }

        public SimulationHistory GenerateSimulationHistory(string moves)
        {
            Map map = new BigBounceMap(8, 6);
            List<IMappable> creatures = new()
            {
                new Player("Astronaut"),
                new Ufo("Ufo"),
                new Aliens {Description = "X Æ A-Xii", Size = 1},
                new Aliens {Description = "Exa Dark Sideræl", Size = 2},
                new Aliens {Description = "Tau Techno Mechanicus", Size = 2},
                new FlyingAliens { Description = "Griffin", Size = 1, FastFlying = true },
                new FlyingAliens { Description = "Vivian", Size = 1, FastFlying = true },
                new FlyingAliens { Description = "Saxon", Size = 1, FastFlying = false },
                new FlyingAliens { Description = "Strider", Size = 1, FastFlying = false },
                new FlyingAliens { Description = "Azure", Size = 1, FastFlying = false }
            };

            // Początkowe pozycje obiektów
            List<Point> positions = new()
            {
                new Point(1, 2),
                new Point(2, 5),
                new Point(2, 1),
                new Point(4, 1),
                new Point(5, 1),
                new Point(1, 3),
                new Point(2, 4),
                new Point(6, 5),
                new Point(7, 1),
                new Point(6, 1)
            };


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
                        "A" => "Al",
                        "F" => "Fast",
                        "" => "Blank",
                        _ => symbol
                    };

                    string image = $"<img src=\"/css/{symbol}.png\">";
                    output += $"<div class=\"grid-item\">{image}</div>";
                }
            }
            return output;
        }
    }
}
