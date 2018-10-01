using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Entity;
using Demo.Service.DBContext;
using System.Data.Entity;

namespace Demo.Service
{
    public class StudentService: IStudentService
    {
        private readonly IDemoContext _context;

        public StudentService(IDemoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Student detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudentDetail(Guid id)
        {
            return _context.Students.FirstOrDefault(s => s.UserID == id);
        }

        /// <summary>
        /// Add or update Student
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public int Save(Student objStudent)
        {
            if (_context.Students.Any(s => s.UserID == objStudent.UserID))
            {
                var old = _context.Students.FirstOrDefault(s => s.UserID == objStudent.UserID);
                _context.Entry(old).State = EntityState.Detached;
                _context.Entry(objStudent).State = EntityState.Modified;
            }
            else
            {
                _context.Students.Add(objStudent);
            }
            //Save DB
            return _context.SaveChanges();
        }

        /// <summary>
        /// Get All Students
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return _context.Students.Where(s => s.IsDeleted == false).ToList();
        }

        /// <summary>
        /// Check Duplicate Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool IsEmailExists(string Email, Guid userID)
        {
            return !_context.Students.Any(s => s.Email == Email && s.UserID != userID);
        }

        /// <summary>
        /// Check Duplicate Mobile
        /// </summary>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public bool IsMobileExists(string Mobile, Guid userID)
        {
            return !_context.Students.Any(s => s.Mobile == Mobile && s.UserID != userID);
        }

    }
}
