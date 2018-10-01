using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
  public interface IStudentService
    {
        /// <summary>
        /// Get Student detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudentDetail(Guid id);

        /// <summary>
        /// Add or update Student
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        int Save(Student objStudent);

        /// <summary>
        /// Get All Students
        /// </summary>
        /// <returns></returns>
        List<Student> GetStudents();

        /// <summary>
        /// Check Duplicate Email
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        bool IsEmailExists(string Email, Guid userID);

        /// <summary>
        /// Check Duplicate Mobile
        /// </summary>
        /// <param name="Mobile"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        bool IsMobileExists(string Mobile, Guid userID);
    }
}
