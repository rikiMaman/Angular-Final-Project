using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> usersList = new List<User>()
        {
            new User { Id = 1, Name="r", Adress="Chevron 12", Email="r@gmail.com", Password="1"},
            new User { Id = 2, Name="Chaim", Adress="Chevron 12", Email="r@gmail.com", Password="123"},
            new User { Id = 3, Name="Yael", Adress="Rabi Akiva", Email="noa@gokdfinger.com", Password="2468"},
            new User { Id = 4, Name="Riki", Adress="Rabi Akiva", Email="noa@gokdfinger.com", Password="2468"},
            new User { Id = 5, Name="Itamar", Adress="Rabi Akiva", Email="noa@gokdfinger.com", Password="2468"},
            new User { Id = 6, Name="Hadas", Adress="Ertzog", Email="noa@gokdfinger.com", Password="2468"},
            new User { Id = 7, Name="Sarit", Adress="Yerushalaim", Email="noa@gokdfinger.com", Password="2468"},
            new User { Id = 13, Name="Gili", Adress="Rabi Akiva", Email="noa@gokdfinger.com", Password="2468"}
        };
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return usersList;
        }
        //Get by id
        //[HttpGet("{id}")]
        //public User Get(int id)
        //{
        //    var recipe = usersList[id - 1];
        //    return recipe;
        //}
        //[HttpPost]
        //public IEnumerable<User> Post([FromBody] User user)
        //{
        //    usersList.Add(user);
        //    throw new Exception("Something Wrong");
        //}

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                usersList.Add(user);
                return Ok(usersList); // בחזרה עם המשתמש החדש שנוסף
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // בחזרה עם הודעת שגיאה במקרה של חריגה
            }
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}
        [HttpGet("{name}")]
        public User Get(string name)
        {
            var user = usersList.Find(x => x.Name == name);
            if (user != null)
                return user;
            return null;
        }
        [HttpGet("byCredentials/{username}/{password}")]
        public User GetByCredentials(string username, string password)
        {
            var user = usersList.Find(x => x.Name == username && x.Password == password);
            if (user != null)
                return user;
            return null;
        }

        











    }
}
