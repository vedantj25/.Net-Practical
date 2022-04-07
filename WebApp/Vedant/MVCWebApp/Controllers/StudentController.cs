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

namespace MVCWebApp.Controllers;

public class StudentController : Controller
{
 public readonly ApplicationDBContext _db;

 public StudentController(ApplicationDBContext db)
 {
  _db = db;
 }

 private void PopulateSubjectsDropDownList(object selectedSubject = null)
 {
  var subjectsQuery = from s in _db.Subject
                      orderby s.Subject_Name
                      select new { SubjectId = s.ID, s.Subject_Name };

  ViewBag.SubjectID = new SelectList(subjectsQuery.AsNoTracking(), "SubjectId", "Subject_Name", selectedSubject);

 }

 public async Task<IActionResult> Index(string searchString)
 {
  var students = from t in _db.Student
                 select t;
  if (!String.IsNullOrEmpty(searchString))
  {
   students = students.Where(s => s.Name!.Contains(searchString));
  }

  return View(await students.ToListAsync());

 }

 public IActionResult Create()
 {
  PopulateSubjectsDropDownList();
  return View();
 }


 [HttpPost]
 public IActionResult Create([Bind("Name,Class,SubjectId")] Student studobj)
 {
  Console.WriteLine(studobj);
  if (ModelState.IsValid)
  {
   _db.Student.Add(studobj);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }
  else
  {
   var errors = ModelState.Select(x => x.Value.Errors)
                       .Where(y => y.Count > 0)
                       .ToList();
   Console.WriteLine(errors);
  }
  return View(studobj);
 }

 //Get Create
 public IActionResult Edit(int id)
 {

  var studobj = _db.Student.Find(id);
  PopulateSubjectsDropDownList(studobj.SubjectId);
  return View(studobj);
 }


 [HttpPost]
 public IActionResult Edit(Student obj)
 {
  if (ModelState.IsValid)
  {
   _db.Student.Update(obj);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }
  return View(obj);
 }

 //Get Delete
 public IActionResult Delete(int id)
 {

  var studobj = _db.Student.Find(id);
  return View(studobj);
 }


 [HttpPost]
 public IActionResult DeletePost(int studentid)
 {
  var studobj = _db.Student.Find(studentid);

  if (ModelState.IsValid)
  {

   _db.Student.Remove(studobj);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }
  return View(studobj);
 }

 [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
 public IActionResult Error()
 {
  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
 }
}
