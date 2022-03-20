﻿using BossPuzzle.Utils;

namespace BossPuzzle.PuzzleBoard;
using Dir = Board.Direction;

public class DFS : IPuzzleSolver
{
    private readonly int _depth;
    private readonly Dir[] _directions;

    public DFS(Dir[] directions)
        : this(directions, 20)
    { }

    public DFS(Dir[] directions, int depth)
    {
        _directions = Cloner.SingleArr(directions);
        _depth = depth;
    }

    public Board Solve(in Board board)
    {
        if (board.IsValid()) return board;

        var visited = new HashSet<ulong>();
        var stack = new Stack<Board>();

        visited.Add(board.Hash);
        stack.Push(board);

        while (stack.Count > 0)
        {
            if (stack.Count > _depth)
            {
                stack.Pop();
            }

            var currentBoard = stack.Pop();
            visited.Add(board.Hash);
            var directions = currentBoard.ClarifyMovement(_directions);

            foreach (var direction in directions)
            {
                var nextBoard = currentBoard.Move(direction);
                nextBoard.AddToPath(direction);

                if (nextBoard.IsValid()) return nextBoard;

                if (visited.Add(nextBoard.Hash)) stack.Push(nextBoard);
            }
        }

        return board;
    }
}