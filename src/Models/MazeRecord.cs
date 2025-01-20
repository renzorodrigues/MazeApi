namespace MazeApi.Models
{
    public record MazeRecord
    {
        public string Maze { get; set; } = "";
        public string? Solution { get; set; }
    }
}
