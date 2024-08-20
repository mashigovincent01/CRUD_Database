using CRUD_Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Database.Controllers
{
    public class StudentController : Controller
    {
        static SqlConnection connection = new SqlConnection(Globals.ConnectionString);
        // GET: Student
        public ActionResult Index()
        {
            List<Student> studentList = new List<Student>();

            try
            {
                //Step 1, is to create an sql command
                string query = "SELECT Id, Name, GPA, StudentNo, Age from Student";
                SqlCommand cmd = new SqlCommand(query, connection);

                //step 2 is to open the connection
                connection.Open();

                //step 3 is to create an instance of sqlreader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        StudentNo = reader["StudentNo"].ToString(),
                        GPA = Convert.ToDecimal(reader["GPA"])
                    };
                    studentList.Add(student);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(studentList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                //step 1
                string query = "INSERT INTO Student(Name, Age, GPA, StudentNo) VALUES (@Name, @Age, @GPA, @StudentNo)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Name", student.Name);
                cmd.Parameters.AddWithValue("Age", student.Age);
                cmd.Parameters.AddWithValue("GPA", student.GPA);
                cmd.Parameters.AddWithValue("StudentNo", student.StudentNo);

                //step 2
                connection.Open();

                //step 3
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create");
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {

                string query = "DELETE FROM Student WHERE ID=" + id;
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Student student = new Student();
            try
            {
                string query = "SELECT Id, Name, GPA, StudentNo, Age from Student WHERE Id=" + id;
                SqlCommand cmd = new SqlCommand(query, connection);


                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                student.Name = reader["Name"].ToString();
                student.Age = Convert.ToInt32(reader["Age"]);
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                student.StudentNo = reader["StudentNo"].ToString();
                student.Id = Convert.ToInt32(reader["Id"]);
            }

            catch(Exception ex )
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Index");
            }
            finally
            {
                connection.Close();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                string query = $"UPDATE Student SET Name = @Name, Age = @Age, StudentNo = @StudentNo, GPA = @GPA WHERE ID={student.Id}"; ;
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("GPA", student.GPA);
                cmd.Parameters.AddWithValue("Name", student.Name);
                cmd.Parameters.AddWithValue("Age", student.Age);
                cmd.Parameters.AddWithValue("StudentNo", student.StudentNo);
                connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }

       
    }
}