using MazeApi.Core;

namespace MazeApiTests
{
    public class MazeSolverTests
    {
        [Fact]
        public void Solve_ValidMaze_ReturnsSolution()
        {
            var solver = new MazeSolver();
            string maze = "S____\n_XG__\n_____";
            var result = solver.Solve(maze);
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Solve_UnsolvableMaze_ReturnsNull()
        {
            var solver = new MazeSolver();
            string maze = "S_X__\nXXXG_\n_____";
            var result = solver.Solve(maze);
            
            Assert.Null(result);
        }
    }
}
