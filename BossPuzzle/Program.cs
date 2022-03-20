﻿using BossPuzzle.Dao;
using BossPuzzle.Utils;
using BossPuzzle.PuzzleBoard;

namespace BossPuzzle;
using Dir = Board.Direction;

class Program
{
    public static void Main()
    {
        /*var readFile = new FileFifteenPuzzleDao("test.file");
        Board board = readFile.Read();
        board.Print();*/

        /*var bfsUDLR = new BFS(new[]
        {
            Dir.Up,
            Dir.Down,
            Dir.Left,
            Dir.Right
        });

        var solvedBoard = board.Solve(bfsUDLR);
        solvedBoard.Print();*/

        /*
        var dfsUDLR = new DFS(new[]
        {
            Dir.Up,
            Dir.Down,
            Dir.Left,
            Dir.Right
        });

        var solvedBoard = board.Solve(dfsUDLR);
        solvedBoard.Print();*/

        /*var rand = Random.Shared;
        var prevBoard = board;

        for (int i = 0; i < 10; i++)
        {
            Dir dir = (Dir)rand.Next(4);
            var currBoard = prevBoard.Move(dir);

            Console.WriteLine($"Hamming's distance = {currBoard.Hammings}");
            currBoard.Print();

            prevBoard = currBoard;
        }*/

        var board = PuzzleGenerator.Generate(4, 4, 100);
        board.Print();

        /*var hamm = new Hammings(1200);
        var solvedBoard = board.Solve(hamm);
        if (solvedBoard.IsValid()) Console.WriteLine("SOLVED!!");
        solvedBoard.Print();*/

        /*var saveFile = new FileFifteenPuzzleDao("test_sol.file");
        saveFile.Write(solvedBoard);*/

        Console.ReadKey();
    }
}