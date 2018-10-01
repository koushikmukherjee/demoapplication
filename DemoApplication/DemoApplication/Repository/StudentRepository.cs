using Demo.Entity;
using Demo.Model;
using Demo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Web
{
    public class StudentRepository
    {
        IStudentService IObjStudent = null;
        /// <summary>
        /// Constructor
        /// </summary>
        public StudentRepository(IStudentService objStudent)
        {
            IObjStudent = objStudent;
        }

        /// <summary>
        /// Get Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentModel GetStudent(Guid id)
        {
            StudentModel objModel = new StudentModel();

            Student objStudent = IObjStudent.GetStudentDetail(id);
            if (objStudent != null)
            {
                objModel.UserID = objStudent.UserID;
                objModel.FirstName = objStudent.FirstName;
                objModel.LastName = objStudent.LastName;
                objModel.Email = objStudent.Email;
                objModel.Mobile = objStudent.Mobile;
            }
            return objModel;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        public StudentModel GetStudents()
        {
            StudentModel objModel = new StudentModel();
            objModel.lstStudent = new List<Student>();

            List<Student> lstStudent = IObjStudent.GetStudents();
            if (lstStudent.Any())
            {
                foreach (var item in lstStudent)
                {
                    objModel.lstStudent.Add(new Student
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Mobile = item.Mobile,
                        UserID = item.UserID
                    });
                }
            }

            return objModel;
        }

        /// <summary>
        /// Save student
        /// </summary>
        /// <returns></returns>
        public int Save(StudentModel objModel)
        {
            int SavedStatus = 0;
            Student objStudent = new Student();
            objStudent.UserID = objModel.UserID;
            objStudent.FirstName = objModel.FirstName;
            objStudent.LastName = objModel.LastName;
            objStudent.Email = objModel.Email;
            objStudent.Mobile = objModel.Mobile;
            objStudent.IsDeleted = objModel.isDeleted;
            SavedStatus = IObjStudent.Save(objStudent);
            return SavedStatus;
        }

        /// <summary>
        /// Check Duplicate Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool CheckDuplicateEmail(string Email, Guid userID)
        {
            bool emailExist = false;
            if (!string.IsNullOrEmpty(Email))
            {
                emailExist = IObjStudent.IsEmailExists(Email, userID);
            }
            return emailExist;
        }

        /// <summary>
        /// Check Duplicate Mobile
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public bool CheckDuplicateMobile(string Mobile, Guid userID)
        {
            bool mobileExist = false;
            if (!string.IsNullOrEmpty(Mobile))
            {
                mobileExist = IObjStudent.IsMobileExists(Mobile, userID);
            }
            return mobileExist;
        }
    }
}