using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;
using MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MVCWebApp.Controllers
{
 public class SubjectController : Controller
 {
  private readonly ApplicationDBContext _db;

  public SubjectController(ApplicationDBContext db)
  {
   _db = db;
  }
  public async Task<IActionResult> Index(string searchString)
  {
   var subjects = from t in _db.Subject
                  select t;
   if (!String.IsNullOrEmpty(searchString))
   {
    subjects = subjects.Where(s => s.Subject_Name!.Contains(searchString));
   }

   return View(await subjects.ToListAsync());

  }

  public IActionResult Create()
  {
   return View();
  }


  [HttpPost]
  public IActionResult Create([Bind("Subject_Name,syllabus,credits")] Subject subobj)
  {
   if (ModelState.IsValid)
   {
    _db.Subject.Add(subobj);
    _db.SaveChanges();
    return RedirectToAction("Index");
   }

   return View(subobj);
  }

  [HttpGet]
  public IActionResult Edit(int subjectid)
  {
   var subobj = _db.Subject.Find(subjectid);
   return View(subobj);

  }

  [HttpPost]
  public IActionResult Edit(Subject updatedvaluesobj)
  {
   _db.Subject.Update(updatedvaluesobj);
   _db.SaveChanges();
   return RedirectToAction("Index");

  }


  //Get Delete
  [HttpGet]
  public IActionResult Delete(int subjectid)
  {

   var subobj = _db.Subject.Find(subjectid);
   return View(subobj);
  }


  [HttpPost]
  public IActionResult DeletePost(int id)
  {
   var subobj = _db.Subject.Find(id);

   if (ModelState.IsValid)
   {

    _db.Subject.Remove(subobj);
    _db.SaveChanges();
    return RedirectToAction("Index");
   }
   return View(subobj);
  }


 }
}