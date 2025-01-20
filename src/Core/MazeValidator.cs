namespace MazeApi.Core
{
    public class MazeValidator
    {
        /// <summary>
        /// Validates if a given maze string is correctly formatted.
        /// </summary>
        /// <param name="maze">The maze string.</param>
        /// <returns>True if the maze is valid, otherwise false.</returns>
        public static bool Validate(string maze)
        {
            var lines = maze.Split('\n');
            if (lines.Length > 20 || lines.Any(line => line.Length > 20)) return false;

            int expectedLength = lines[0].Length;
            if (lines.Any(line => line.Length != expectedLength)) return false;

            int startCount = maze.Count(c => c == 'S');
            int goalCount = maze.Count(c => c == 'G');
            return startCount == 1 && goalCount == 1;
        }
    }
}
