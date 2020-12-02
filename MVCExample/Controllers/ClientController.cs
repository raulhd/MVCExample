using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Controllers.Interfaces;
using System;
using Entities.Dtos;

namespace MVCExample.Controllers
{
    public class ClientController : Controller
    {
       
        public ClientController(IClientControllerBl ClientControllerBl)
        {
            ControllerBl = ClientControllerBl;
        }

        public IClientControllerBl ControllerBl { get; private set; }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            return View(await ControllerBl.GetAll());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
                   
            var client = await ControllerBl.GetById(Convert.ToInt32(id));

            if (client == null)       
                return NotFound();    

            return View(client);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,IdentificationNumber")] ClientDto client)
        {
            if (!ModelState.IsValid)           
                return View(client);            

            await ControllerBl.Create(client);
            return RedirectToAction(nameof(Index));
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();           

            var client = await ControllerBl.GetById(Convert.ToInt32(id));

            if (client == null)          
                return NotFound();
            
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,IdentificationNumber")] ClientDto client)
        {
            if (id != client.Id)           
                return NotFound();           

            if (!ModelState.IsValid)          
                return View(client);

            await ControllerBl.Update(client,id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();          

            var client = await ControllerBl.GetById(Convert.ToInt32(id));

            if (client == null)
                return NotFound();           

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ControllerBl.Delete(id);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
