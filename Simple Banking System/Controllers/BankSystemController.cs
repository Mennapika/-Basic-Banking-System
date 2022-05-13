using Microsoft.AspNetCore.Mvc;
using Simple_Banking_System.Data;
using Simple_Banking_System.Models;

namespace Simple_Banking_System.Controllers
{
    public class BankSystemController : Controller
    {
        private readonly UserContext _db;
        private readonly TransferContext _dbt;
        public BankSystemController(UserContext db , TransferContext dbt)
        {
            _db = db;
           _dbt = dbt;

        }
       
        public IActionResult Index()
        {
            IEnumerable<User> objUserList = _db.Users;
            return View(objUserList);
        }
        
    }
}
