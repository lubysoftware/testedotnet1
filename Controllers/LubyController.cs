using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testedotnet1.Data;
using testedotnet1.Entities;
using testedotnet1.Services;

namespace testedotnet1.Controllers
{
    [Route("api/luby")]
    public class LubyController : ControllerBase
    {
        #region Injection dependency BD
        private readonly TesteContext _testeContext;
        private readonly IUserService _userService;

        public LubyController(TesteContext testeContext, IUserService userService)
        {
            _testeContext = testeContext;
             _userService = userService;
        }


        #endregion

        ///<summary>
        /// hello word api get
        ///</summary>
        [Route("")]
        [HttpGet]
        public string MeuMetodo()
        {
            return "Olá mundo!";
        }

        #region Users

        ///<summary>
        /// GET - Get all Users
        ///</summary>
        [Route("users")]
        [HttpGet]
        [Authorize(Roles = "ceo, manager, developer")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _testeContext.UserItems
            .Select(x => userTo(x))
            .ToListAsync();
        }

        ///<summary>
        /// GET - Get User by Id
        ///</summary>
        [Route("users/{id}")]
        [HttpGet]
        [Authorize(Roles = "ceo, manager, developer")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var userItem = await _testeContext.UserItems.FindAsync(id);

            if (userItem == null)
            {
                return NotFound();
            }

            return userItem;
        }

        ///<summary>
        /// POST - Add new User
        ///</summary>
        [Route("users")]
        [HttpPost]
        [Authorize(Roles = "ceo, manager")]
        public async Task<ActionResult<User>> AddUser([FromBody] User userItem)
        {
            var itemUser = new User
            {
                UserName = userItem.UserName,
                Password = userItem.Password,
                Role = userItem.Role,
                HoursWork = userItem.HoursWork
            };
            _testeContext.UserItems.Add(itemUser);

            await _testeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddUser), new { id = itemUser.IdUser }, userTo(itemUser));
        }

        ///<summary>
        /// PUT - Update User Item by Id
        ///</summary>
        [Route("users/{id}")]
        [HttpPut]
        [Authorize(Roles = "ceo, manager")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] User userItem)
        {
            //if (id != userItem.UserId)
            //{
            //    return BadRequest();
            //}

            var itemUser = await _testeContext.UserItems.FindAsync(id);
            if (itemUser == null)
            {
                return NotFound();
            }

            itemUser.UserName = userItem.UserName;
            itemUser.Password = userItem.Password;
            itemUser.Role = userItem.Role;
            itemUser.HoursWork = userItem.HoursWork;

            try
            {
                await _testeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!UserItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        ///<summary>
        /// DELETE - Delete User Item by id
        ///</summary>
        [Route("users/{id}")]
        [HttpDelete]
        [Authorize(Roles = "ceo")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var userItem = await _testeContext.UserItems.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }

            _testeContext.UserItems.Remove(userItem);
            await _testeContext.SaveChangesAsync();

            return userItem;
        }

        private bool UserItemExists(long id) =>
                 _testeContext.UserItems.Any(e => e.IdUser == id);
        private static User userTo(User userItem) =>
            new User
            {
                UserName = userItem.UserName,
                Password = userItem.Password,
                Role = userItem.Role,
                HoursWork = userItem.HoursWork
            };
        #endregion
    }
}