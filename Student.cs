using System;

namespace StudentManagementSystem
{
    public class Student
    {
        // Các thuộc tính (Properties)
        public string Id { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }

        // Hàm khởi tạo (Constructor)
        public Student(string id, string name, double score)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID không được để trống");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Tên không được để trống");
            if (score < 0 || score > 10) throw new ArgumentException("Điểm phải từ 0 đến 10");

            Id = id;
            Name = name;
            Score = score;
        }

        // Hàm hiển thị thông tin
        public void Display()
        {
            Console.WriteLine($"ID: {Id} | Tên: {Name} | Điểm: {Score}");
        }
    }
}