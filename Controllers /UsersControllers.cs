using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UsersController(IUserRepository repo)
    {
        _repo = repo;
    }

    // GET: api/users
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_repo.GetAll());
    }

    // GET: api/users/5
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _repo.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        _repo.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/users/5
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        var existing = _repo.GetById(id);
        if (existing == null) return NotFound();

        _repo.Update(user);
        return NoContent();
    }

    // DELETE: api/users/5
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var existing = _repo.GetById(id);
        if (existing == null) return NotFound();

        _repo.Delete(id);
        return NoContent();
    }
}
