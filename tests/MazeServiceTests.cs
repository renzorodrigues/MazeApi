using MazeApi.Services;

namespace MazeApiTests
{
    public class MazeServiceTests
    {
        [Fact]
        public void FindPath_ValidMaze_ReturnsSolution()
        {
            var service = new MazeService();
            string maze = "S____\n_XG__\n_____";
            var solution = service.FindPath(maze);
            
            Assert.NotNull(solution);
        }

        [Fact]
        public void GetAllMazes_InitiallyEmpty_ReturnsEmptyList()
        {
            var service = new MazeService();
            var mazes = service.GetAllMazes();
            
            Assert.Empty(mazes);
        }
    }
}
