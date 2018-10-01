using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Model;
using Demo.Service;

namespace DemoApplication.Web
{
    public class StudentController : BaseController
    {
       private IStudentService IObjStudent;
        /// <summary>
        /// Constructor
        /// </summary>
        public StudentController(IStudentService objStudent)
        {
            IObjStudent = objStudent;
        }

        // GET: Student List
        public ActionResult Students()
        {
            StudentRepository objStudent = new StudentRepository(IObjStudent);
            var _model= objStudent.GetStudents();
            return View(_model);
        }

        // GET: Student Detail
        public ActionResult StudentView(Guid id)
        {
            StudentRepository objStudent = new StudentRepository(IObjStudent);
            var _model = objStudent.GetStudent(id);
            return View(_model);
        }

        
        public ActionResult ManageStudent(string id)
        {
            StudentModel _model=new StudentModel();
            StudentRepository objStudent = new StudentRepository(IObjStudent);
            if (!string.IsNullOrEmpty(id))
            {
                _model = objStudent.GetStudent(Guid.Parse(id));
            }
            return View(_model);
        }

        [HttpPost]
        public ActionResult ManageStudent(StudentModel studentModel)
        {
            if (ModelState.IsValid == true)
            {
                StudentRepository objStudent = new StudentRepository(IObjStudent);
                StudentModel model = new StudentModel();
                if (studentModel.UserID==Guid.Empty)
                {
                    Guid newId = Guid.NewGuid();
                    studentModel.UserID = newId;
                }
                studentModel.isDeleted = false;
                model = studentModel;
                int status = objStudent.Save(model);
                if (status == 1)
                {
                    return RedirectToAction("Students", "Student");
                }
                else
                {
                    ViewBag.failure = "Data not saved. please try again";
                    return View(studentModel);
                }
            }
            else
            {
                ViewBag.failure = "Data not saved. please try again";
                return View(studentModel);
            }
        }

        [AllowAnonymous]
        public JsonResult CheckDuplicateEmail(StudentModel studentModel)
        {
            bool isNewEmailID = true;
            StudentRepository objStudent = new StudentRepository(IObjStudent);
            isNewEmailID = objStudent.CheckDuplicateEmail(studentModel.Email,studentModel.UserID);

            return Json(isNewEmailID, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult CheckDuplicateMobile(StudentModel studentModel)
        {
            bool isNewEmailID = true;
            StudentRepository objStudent = new StudentRepository(IObjStudent);
            isNewEmailID = objStudent.CheckDuplicateMobile(studentModel.Mobile, studentModel.UserID);
            return Json(isNewEmailID, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult Delete(string UserID)
        {
            bool deletedStatus = false;
            string Message = "Data deletion failed, please try again.";
            if (ModelState.IsValid == true)
            {
                StudentRepository objStudent = new StudentRepository(IObjStudent);
                var model = objStudent.GetStudent(Guid.Parse(UserID));
                model.isDeleted = true;
                int status = objStudent.Save(model);
                if (status == 1)
                {
                    deletedStatus = true;
                    Message = "Data deleted successfully.";
                }
            }
            return this.Json(new { isDeleted = deletedStatus, message = Message }, JsonRequestBehavior.AllowGet);
        }
    }
}