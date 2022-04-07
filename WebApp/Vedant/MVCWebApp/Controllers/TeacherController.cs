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

public class TeacherController : Controller
{
 public readonly ApplicationDBContext _db;

 public TeacherController(ApplicationDBContext db)
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

 // public IActionResult Index()
 // {

 //  IEnumerable<Teacher> objList = _db.Teacher;
 //  return View(objList);
 // }

 public async Task<IActionResult> Index(string searchString)
 {
  var teachers = from t in _db.Teacher
                 select t;
  if (!String.IsNullOrEmpty(searchString))
  {
   teachers = teachers.Where(s => s.Name!.Contains(searchString));
  }

  return View(await teachers.ToListAsync());

 }

 public IActionResult Create()
 {
  PopulateSubjectsDropDownList();
  return View();
 }


 [HttpPost]
 public IActionResult Create([Bind("Name,Class,SubjectId")] Teacher teacherobj)
 {
  Console.WriteLine(teacherobj);
  if (ModelState.IsValid)
  {
   _db.Teacher.Add(teacherobj);
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
  return View(teacherobj);
 }

 //Get Create
 public IActionResult Edit(int id)
 {

  var teacherobj = _db.Teacher.Find(id);
  PopulateSubjectsDropDownList(teacherobj.SubjectId);
  return View(teacherobj);
 }


 [HttpPost]
 public IActionResult Edit(Teacher obj)
 {
  if (ModelState.IsValid)
  {
   _db.Teacher.Update(obj);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }
  return View(obj);
 }

 //Get Delete
 public IActionResult Delete(int id)
 {

  var teacherobj = _db.Teacher.Find(id);
  return View(teacherobj);
 }


 [HttpPost]
 public IActionResult DeletePost(int teacherid)
 {
  var teacherobj = _db.Teacher.Find(teacherid);

  if (ModelState.IsValid)
  {

   _db.Teacher.Remove(teacherobj);
   _db.SaveChanges();
   return RedirectToAction("Index");
  }
  return View(teacherobj);
 }

 [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
 public IActionResult Error()
 {
  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
 }
}
