using System.Collections.Concurrent;
using MazeApi.Core;
using MazeApi.Models;

namespace MazeApi.Services
{
    public class MazeService : IMazeService
    {
        private readonly ConcurrentBag<MazeRecord> _mazes = [];

        /// <summary>
        /// Attempts to find a path through the provided maze.
        /// </summary>
        /// <param name="maze">The maze string.</param>
        /// <returns>The solution path or null if unsolvable.</returns>
        public string? FindPath(string maze)
        {
            var solver = new MazeSolver();
            var solution = solver.Solve(maze);
            _mazes.Add(new MazeRecord { Maze = maze, Solution = solution });
            
            return solution;
        }

        /// <summary>
        /// Retrieves all mazes stored in memory.
        /// </summary>
        /// <returns>List of stored maze records.</returns>
        public IEnumerable<MazeRecord> GetAllMazes() => _mazes;
    }
}
