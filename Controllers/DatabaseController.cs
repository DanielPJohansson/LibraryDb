
namespace LibraryDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly LibraryContext _context;
        private readonly DatabaseInitializer _databaseInitializer;
        public DatabaseController(LibraryContext context)
        {
            _context = context;
            _databaseInitializer = new DatabaseInitializer(_context);
        }
       
        // DELETE api/<DatabaseController>/5
        [HttpPatch]
        public async Task<IActionResult> RecreateDatabase()
        {
            await _databaseInitializer.RecreateDatabase();
            return NoContent();
        }
    }
}
