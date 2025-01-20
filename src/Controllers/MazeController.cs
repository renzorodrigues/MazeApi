using MazeApi.Core;
using MazeApi.Models;
using MazeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MazeApi.Controllers
{
    /// <summary>
    /// Controller responsible for handling maze-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MazeController(IMazeService mazeService) : ControllerBase
    {
        private readonly IMazeService _mazeService = mazeService;

        /// <summary>
        /// Submits a new maze configuration and returns a possible solution.
        /// </summary>
        /// <param name="request">The maze request object containing the maze grid.</param>
        /// <returns>The solution to the maze if solvable.</returns>
        [HttpPost("submit")]
        public IActionResult SubmitMaze([FromBody] SubmitMazeRequest request)
        {
            if (!MazeValidator.Validate(request.Maze))
            {
                return BadRequest("Invalid maze format.");
            }

            var solution = _mazeService.FindPath(request.Maze);
            return Ok(new SubmitMazeResponse { Maze = request.Maze, Solution = solution });
        }

        /// <summary>
        /// Retrieves a list of all previously submitted mazes and their solutions.
        /// </summary>
        /// <returns>List of stored mazes with their respective solutions.</returns>
        [HttpGet("mazes")]
        public IActionResult GetMazes()
        {
            var mazes = _mazeService.GetAllMazes();
            return Ok(mazes);
        }
    }
}
