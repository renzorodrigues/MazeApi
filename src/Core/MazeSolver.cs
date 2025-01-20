namespace MazeApi.Core
{
    public class MazeSolver
    {
        private static readonly (int, int)[] Directions = { (0, 1), (1, 0), (0, -1), (-1, 0) };

        /// <summary>
        /// Finds the shortest path from 'S' (Start) to 'G' (Goal) in a given maze.
        /// </summary>
        /// <param name="maze">The maze represented as a multiline string.</param>
        /// <returns>The solved path as a string or null if no solution exists.</returns>
        public string? Solve(string maze)
        {
            var grid = maze.Split('\n');
            int rows = grid.Length;
            int cols = grid[0].Length;
            (int, int) start = (-1, -1),
                goal = (-1, -1);

            // Locate the start (S) and goal (G) positions in the maze.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 'S')
                        start = (i, j);
                    if (grid[i][j] == 'G')
                        goal = (i, j);
                }
            }

            // If start or goal is not found, return null.
            if (start == (-1, -1) || goal == (-1, -1))
                return null;

            var queue = new Queue<((int, int), List<(int, int)>)>();
            queue.Enqueue((start, new List<(int, int)> { start }));
            var visited = new HashSet<(int, int)> { start };

            // BFS algorithm to find the shortest path.
            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();

                if (current == goal)
                    return FormatPath(path, grid);

                foreach (var (dx, dy) in Directions)
                {
                    (int, int) next = (current.Item1 + dx, current.Item2 + dy);

                    if (
                        next.Item1 >= 0
                        && next.Item1 < rows
                        && next.Item2 >= 0
                        && next.Item2 < cols
                        && grid[next.Item1][next.Item2] != 'X'
                        && !visited.Contains(next)
                    )
                    {
                        visited.Add(next);
                        var newPath = new List<(int, int)>(path) { next };
                        queue.Enqueue((next, newPath));
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Converts the solved path into a formatted maze with '.' marking the shortest path.
        /// </summary>
        /// <param name="path">The list of coordinates representing the shortest path.</param>
        /// <param name="grid">The original maze grid.</param>
        /// <returns>The formatted maze with the solution path.</returns>
        private static string FormatPath(List<(int, int)> path, string[] grid)
        {
            char[][] output = grid.Select(line => line.ToCharArray()).ToArray();
            foreach (var (x, y) in path)
            {
                if (output[x][y] != 'S' && output[x][y] != 'G')
                    output[x][y] = '.';
            }
            return string.Join('\n', output.Select(row => new string(row)));
        }
    }
}
