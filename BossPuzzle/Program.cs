﻿using System.Text;
using BossPuzzle.Dao;
using BossPuzzle.Utils;
using BossPuzzle.PuzzleBoard;
using System.Diagnostics;

namespace BossPuzzle;
using Dir = Board.Direction;
using Heur = AStar.Heuristic;

class Program
{
    public static void Main()
    {
        /*var readFile = new FileFifteenPuzzleDao("test.file");
        var board = readFile.Read();*/

        var board = PuzzleGenerator.Generate(4, 4, 40);
        board.Print();
        Console.WriteLine($"Hammings distance = {board.Hammings}");
        Console.WriteLine($"Manhattan distance = {board.Manhattans}");


        IPuzzleSolver solver = new AStar(Heur.Manhattan);

        /*IPuzzleSolver solver = new BFS(new[]
        {
            Dir.Up,
            Dir.Down,
            Dir.Left,
            Dir.Right
        });*/

        /*IPuzzleSolver solver = new DFS(
            new[] {
            Dir.Up,
            Dir.Down,
            Dir.Left,
            Dir.Right
            },
            19);*/


        var watch = Stopwatch.StartNew();
        var solvedBoard = board.Solve(solver);
        watch.Stop();

        if (solvedBoard.IsValid()) Console.WriteLine($"SOLVED in {watch.ElapsedMilliseconds}ms");
        solvedBoard.Print();

        var sb = new StringBuilder();
        foreach (var direction in solvedBoard.GetPath()) sb.Append(direction.ToString()[0]);
        string path = sb.ToString();
        Console.WriteLine($"Created {Board.instances:n0} instances of Board.");
        Console.WriteLine($"Path: {path} (length = {path.Length})");


        /*var saveFile = new FileFifteenPuzzleDao("test_sol.file");
        saveFile.Write(solvedBoard);*/

        Console.ReadKey();
    }
}