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
        //Get
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.FirstOrDefault(c => c.Id == id);// return onl first in list if it found more than one 
            var UserFromDb = _db.Users.Find(id);
            //var cateoryFromSinle=_db.Categories.SingleOrDefault(category => category.Id == id);// return expcetion if found more than one 
            if (UserFromDb == null)
            {
                return NotFound();
            }
            return View(UserFromDb);
        }
        //Get
        public IActionResult Transfer()
        {

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Transfer(int Sender, int Recevier, float TransferAmount)
        {  
            if( Sender==null || Sender<0 )
            {
                ModelState.AddModelError("Sender", "Enter Avalid Id ");
            }
            if (Recevier == null || Recevier < 0)
            {
                ModelState.AddModelError("Recevier", "Enter Avalid Id ");
            }
            var SenderObj = _db.Users.Find(Sender);
            var RecevierObj = _db.Users.Find(Recevier);
            if(Sender < 0 || SenderObj == null)
            {
                return NotFound();
            }
            if ( RecevierObj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var newTransfer = new Transactions();
                newTransfer.Sender = SenderObj.Name;
                newTransfer.Recevier= RecevierObj.Name;
                newTransfer.TransferAmount = TransferAmount;
                newTransfer.Date = DateTime.Now;
                if (SenderObj.Balance >= TransferAmount)
                {
                    SenderObj.Balance-=TransferAmount;
                    RecevierObj.Balance+=TransferAmount;
                    newTransfer.OperationState = "Sucess";
                    _dbt.Transfers.Add(newTransfer);
                    _db.SaveChanges();
                    _dbt.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("TransferAmount", "Your balance is not enough ");
                    newTransfer.OperationState = "Failed";
                    _dbt.Transfers.Add(newTransfer);
                    _dbt.SaveChanges();
                    return View();
                }

            }
            return View();
        }
        public IActionResult History()
        {
            IEnumerable<Transactions> objTransfersList = _dbt.Transfers;
            return View(objTransfersList);
        }



    }
}
