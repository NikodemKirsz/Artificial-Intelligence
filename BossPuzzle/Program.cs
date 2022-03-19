﻿using System;
using BossPuzzle.Dao;
using BossPuzzle.PuzzleBoard;

namespace BossPuzzle;
using Dir = Board.Direction;

class Program
{
    public static void Main()
    {
        var sth = new FileFifteenPuzzleDao("test.file");
        Board board = sth.Read();
        board.Print();
        Console.WriteLine(board.IsValid());
        board.SolvePuzzle();

        /*var board1 = board.Move(2, 2, Dir.Up);
        board1.Print();

        var board2 = board1.Move(1, 2, Dir.Down);
        board2.Print();

        var board3 = board1.Move(Dir.Up);
        board3.Print();

        var board4 = board3.Move(Dir.Left);
        board4.Print();

        var board5 = board.Move(Dir.Up).Move(Dir.Left).Move(Dir.Down).Move(Dir.Right);
        board5.Print();

        Console.WriteLine($"board2 == board = {board2 == board}  //Expected 'True'");
        Console.WriteLine($"board5 == board = {board5 == board}  //Expected 'False'");*/

        /*
        How the fuck do refs work

        int five = 5;

        ref int fiveRef = ref five;

        fiveRef = 6;

        Console.WriteLine($"five = {five}"); // Prints '6'
        Console.WriteLine($"fiveRef = {fiveRef}"); // Prints '6'
        */

        var directions = new[]
        {
            Dir.Up,
            Dir.Down,
            Dir.Right,
            Dir.Left
        };

        var visited = new HashSet<int> { board.GetHashCode() };
        var clearedDirections = board.ClarifyMovement(directions);
        var queue = new List<Board>();
        foreach (var direction in clearedDirections)
        {
            var nextBoard = board.Move(direction);
            queue.Add(nextBoard);
        }

        Console.ReadKey();
    }
}