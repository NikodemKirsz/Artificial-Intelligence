﻿using BossPuzzle.Utils;

namespace BossPuzzle.PuzzleBoard;
using Dir = Board.Direction;

public class DFS : IPuzzleSolver
{
    private readonly int _maxDepth;
    private readonly Dir[] _directions;

    public DFS(Dir[] directions)
        : this(directions, 25)
    { }

    public DFS(Dir[] directions, int maxDepth)
    {
        _maxDepth = maxDepth;
        _directions = Arrayer.Copy(directions);
    }

    public Board Solve(in Board board)
    {
        if (board is null) throw new ArgumentNullException(nameof(board));

        var stack = new Stack<Board>();
        var boardsDepth = new Dictionary<ulong, short>();
        var validBoards = new List<Board>();

        var currentBoard = board;
        stack.Push(currentBoard);

        while (stack.Count > 0)
        {
            if (currentBoard.IsValid()) validBoards.Add(currentBoard);

            if (stack.Count > _maxDepth)
            {
                stack.Pop();
                currentBoard = stack.Peek();
            }

            bool boardAdded = false;
            var directions = currentBoard.ClarifyMovement(_directions);
            foreach (var direction in directions)
            {
                var nextBoard = currentBoard.Move(direction);
                short stackCount = (short)stack.Count;
                ulong nextBoardHash = nextBoard.Hash;

                if (!boardsDepth.TryAdd(nextBoardHash, stackCount))
                {
                    if (stackCount >= boardsDepth[nextBoardHash]) continue;
                    else boardsDepth[nextBoardHash] = stackCount;
                }

                boardAdded = true;
                stack.Push(nextBoard);
                currentBoard = nextBoard;
                break;
            }

            if (!boardAdded)
            {
                stack.Pop();
                stack.TryPeek(out currentBoard!);
            }
        }

        validBoards.Sort((board1, board2) => board1.GetPathLength().CompareTo(board2.GetPathLength()));

        return validBoards[0];
    }
}