﻿using Newtonsoft.Json;

namespace Practice_Linq
{
    public class Program
    {
        static void Main(string[] args)
        {

            string path = @"../../../data/results_2010.json";

            List<FootballGame> games = ReadFromFileJson(path);

            int test_count = games.Count();
            Console.WriteLine($"Test value = {test_count}.");    // 13049

            Query1(games);
            Query2(games);
            Query3(games);
            Query4(games);
            Query5(games);
            Query6(games);
            Query7(games);
            Query8(games);
            Query9(games);
            Query10(games);

        }


        // Десеріалізація json-файлу у колекцію List<FootballGame>
        static List<FootballGame> ReadFromFileJson(string path)
        {

            var reader = new StreamReader(path);
            string jsondata = reader.ReadToEnd();

            List<FootballGame> games = JsonConvert.DeserializeObject<List<FootballGame>>(jsondata);


            return games;

        }


        // Запит 1
        private static void Query1(List<FootballGame> games)
        {
            var selectedGames = from game in games
                where game.Country == "Ukraine" &&
                      game.Date.Year == 2012
                select game;

            Console.WriteLine("\n======================== QUERY 1 ========================");
            foreach (var game in selectedGames)
            {
                string score = $"{game.Home_score} - {game.Away_score}";
                Console.WriteLine(
                    $"{game.Date:dd.MM.yyyy} {game.Home_team} - {game.Away_team}, Score: {score}, Country: {game.Country}");
            }
        }

        // Запит 2
        static void Query2(List<FootballGame> games)
        {
            var selectedGames = from game in games
                where (game.Home_team == "Italy" || game.Away_team == "Italy") &&
                      game.Tournament.Contains("Friendly") &&
                      game.Date.Year >= 2020
                select game;

            Console.WriteLine("\n======================== QUERY 2 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine(
                    $"{game.Date:dd.MM.yyyy} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 3
        static void Query3(List<FootballGame> games)
        {
            var selectedGames = from game in games
                where game.Home_team == "France" &&
                      game.Country == "France" &&
                      game.Date.Year == 2021 &&
                      game.Home_score == game.Away_score
                select game;

            Console.WriteLine("\n======================== QUERY 3 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine(
                    $"{game.Date:dd.MM.yyyy} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 4
        static void Query4(List<FootballGame> games)
        {
            var selectedGames = from game in games
                where game.Date.Year >= 2018 &&
                      game.Date.Year <= 2020 &&
                      game.Away_team == "Germany" &&
                      game.Home_score > game.Away_score
                select game;

            Console.WriteLine("\n======================== QUERY 4 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine(
                    $"{game.Date:dd.MM.yyyy} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 5
        static void Query5(List<FootballGame> games)
        {
            var selectedGames = from game in games
                where (game.City == "Kyiv" || game.City == "Kharkiv") &&
                      game.Tournament == "UEFA Euro qualification" &&
                      game.Country == "Ukraine" &&
                      game.Home_team == "Ukraine" &&
                      game.Home_score > game.Away_score
                select game;

            Console.WriteLine("\n======================== QUERY 5 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine(
                    $"{game.Date:dd.MM.yyyy} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 6
        static void Query6(List<FootballGame> games)
        {
            var selectedGames = (from game in games
                where game.Tournament == "FIFA World Cup"
                orderby game.Date descending
                select game).Take(8);

            Console.WriteLine("\n======================== QUERY 6 ========================");
            foreach (var game in selectedGames)
            {
                Console.WriteLine(
                    $"{game.Date:dd.MM.yyyy} {game.Home_team} - {game.Away_team}, Score: {game.Home_score} - {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 7
        static void Query7(List<FootballGame> games)
        {
            var selectedGame = (from game in games
                where game.Date.Year == 2023 &&
                      ((game.Home_team == "Ukraine" && game.Home_score > game.Away_score) ||
                       (game.Away_team == "Ukraine" && game.Away_score > game.Home_score))
                orderby game.Date
                select game).FirstOrDefault();

            Console.WriteLine("\n======================== QUERY 7 ========================");
            if (selectedGame != null)
            {
                Console.WriteLine(
                    $"{selectedGame.Date:dd.MM.yyyy} {selectedGame.Home_team} - {selectedGame.Away_team}, Score: {selectedGame.Home_score} - {selectedGame.Away_score}, Country: {selectedGame.Country}");
            }
        }

        // Запит 8
        static void Query8(List<FootballGame> games)
        {
            var selectedGames = from game in games
                where game.Tournament == "UEFA Euro" &&
                      game.Country == "Ukraine" &&
                      game.Date.Year == 2012
                select new
                {
                    MatchYear = game.Date.Year,
                    Team1 = game.Home_team,
                    Team2 = game.Away_team,
                    Goals = game.Home_score + game.Away_score
                };

            Console.WriteLine("\n======================== QUERY 8 ========================");
            foreach (var match in selectedGames)
            {
                Console.WriteLine($"{match.MatchYear} {match.Team1} - {match.Team2}, Goals: {match.Goals}");
            }
        }


        // Запит 9
        static void Query9(List<FootballGame> games)
        {
            //Query 9: Перетворити всі матчі UEFA Nations League у 2023 році на матчі з наступними властивостями:
            // MatchYear - рік матчу, Game - назви обох команд через дефіс (першою - Home_team), Result - результат для першої команди (Win, Loss, Draw)

            var selectedGames = games;   // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 9 ========================");

            // див. приклад як має бути виведено:


        }

        // Запит 10
        static void Query10(List<FootballGame> games)
        {
            //Query 10: Вивести з 5-го по 10-тий (включно) матчі Gold Cup, які відбулися у липні 2023 р.

            var selectedGames = games;    // Корегуємо запит !!!

            // Перевірка
            Console.WriteLine("\n======================== QUERY 10 ========================");

            // див. приклад як має бути виведено:


        }

    }
}