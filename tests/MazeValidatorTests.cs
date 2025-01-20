using MazeApi.Core;

namespace MazeApiTests
{
    public class MazeValidatorTests
    {
        [Fact]
        public void Validate_ValidMaze_ReturnsTrue()
        {
            string maze = "S____\n_XG__\n_____";
            
            Assert.True(MazeValidator.Validate(maze));
        }

        [Fact]
        public void Validate_InvalidMaze_ReturnsFalse()
        {
            string maze = "S____\n_XG__\n_";
           
            Assert.False(MazeValidator.Validate(maze));
        }
    }
}
