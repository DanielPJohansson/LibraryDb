
namespace LibraryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly DataAccess _dataAccess;
        public DatabaseController(LibraryContext context)
        {
            _context = context;
            _dataAccess = new DataAccess(_context);
        }
       
        // DELETE api/<DatabaseController>/5
        [HttpPatch]
        public async Task<IActionResult> RecreateDatabase()
        {
            await _dataAccess.RecreateDatabase();
            return NoContent();
        }
    }
}
