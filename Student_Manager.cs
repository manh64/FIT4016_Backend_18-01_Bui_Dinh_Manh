using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    public class Student_Manager
    {
        // Danh sách chứa sinh viên
        private List<Student> students = new List<Student>();

        public void AddStudent(string id, string name, double score)
        {
            // Kiểm tra trùng ID
            if (students.Any(s => s.Id == id))
            {
                Console.WriteLine("Lỗi: ID này đã tồn tại!");
                return;
            }

            Student newStudent = new Student(id, name, score);
            students.Add(newStudent);
            Console.WriteLine("Đã thêm sinh viên thành công!");
        }

        public void RemoveStudent(string id)
        {
            Student s = students.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                students.Remove(s);
                Console.WriteLine("Đã xóa thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy ID này.");
            }
        }

        public void UpdateScore(string id, double newScore)
        {
            Student s = students.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                // Validate điểm lại nếu cần
                if (newScore < 0 || newScore > 10)
                {
                    Console.WriteLine("Điểm không hợp lệ.");
                    return;
                }
                s.Score = newScore;
                Console.WriteLine("Cập nhật điểm thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
            }
        }

        public void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
            }
            else
            {
                Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
                foreach (var s in students)
                {
                    s.Display();
                }
            }
        }

        public double GetAverageScore()
        {
            if (students.Count == 0) return 0;
            return students.Average(s => s.Score);
        }

        public double GetMaxScore()
        {
            if (students.Count == 0) return 0;
            return students.Max(s => s.Score);
        }

        public Student FindStudentById(string id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}