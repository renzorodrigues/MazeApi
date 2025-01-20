using MazeApi.Models;

namespace MazeApi.Services
{
    public interface IMazeService
    {
        string? FindPath(string maze);
        IEnumerable<MazeRecord> GetAllMazes();
    }
}
