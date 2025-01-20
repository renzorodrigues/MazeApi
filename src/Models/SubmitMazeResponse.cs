namespace MazeApi.Models
{
    public record SubmitMazeResponse
    {
        public string Maze { get; set; } = "";
        public string? Solution { get; set; }
    }
}
