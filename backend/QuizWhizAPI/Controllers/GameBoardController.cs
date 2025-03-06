#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/gameboards")]
[ApiController]
public class GameBoardController : ControllerBase
{
    private readonly IGameBoardService _gameBoardService;

    public GameBoardController(IGameBoardService gameBoardService)
    {
        _gameBoardService = gameBoardService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameBoard>>> GetAllGameBoards()
    {
        var gameBoards = await _gameBoardService.GetAllGameBoards();
        return Ok(gameBoards);
    }

    [HttpPost]
    public async Task<ActionResult<GameBoard>> CreateGameBoard([FromBody] GameBoard gameBoard)
    {
        var createdBoard = await _gameBoardService.CreateGameBoard(gameBoard);
        return CreatedAtAction(nameof(GetAllGameBoards), new { id = createdBoard.Id }, createdBoard);
    }
}