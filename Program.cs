namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Để hiển thị tiếng Việt có dấu (nếu console hỗ trợ)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Student_Manager manager = new Student_Manager();
            bool running = true;

            while (running)
            {
                // TODO: In menu
                Console.WriteLine("\n========== MENU QUẢN LÝ SINH VIÊN ==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Cập nhật điểm");
                Console.WriteLine("4. In danh sách");
                Console.WriteLine("5. Tính điểm trung bình");
                Console.WriteLine("6. Tìm điểm cao nhất");
                Console.WriteLine("7. Tìm sinh viên theo ID");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("============================================");
                Console.Write("Chọn chức năng: ");

                // TODO: Thêm try-catch để xử lý lỗi nhập liệu
                try
                {
                    // TODO: Nhận lựa chọn từ người dùng
                    string choice = Console.ReadLine();

                    // TODO: Dùng switch xử lý từng lựa chọn
                    switch (choice)
                    {
                        case "1": // Thêm
                            Console.Write("Nhập ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Nhập Tên: ");
                            string name = Console.ReadLine();
                            Console.Write("Nhập Điểm: ");
                            double score = double.Parse(Console.ReadLine());
                            manager.AddStudent(id, name, score);
                            break;

                        case "2": // Xóa
                            Console.Write("Nhập ID sinh viên cần xóa: ");
                            string delId = Console.ReadLine();
                            manager.RemoveStudent(delId);
                            break;

                        case "3": // Cập nhật điểm
                            Console.Write("Nhập ID sinh viên: ");
                            string upId = Console.ReadLine();
                            Console.Write("Nhập điểm mới: ");
                            double newScore = double.Parse(Console.ReadLine());
                            manager.UpdateScore(upId, newScore);
                            break;

                        case "4": // In danh sách
                            manager.DisplayAllStudents();
                            break;

                        case "5": // Điểm trung bình
                            Console.WriteLine($"Điểm trung bình của lớp: {manager.GetAverageScore():F2}");
                            break;

                        case "6": // Điểm cao nhất
                            Console.WriteLine($"Điểm cao nhất: {manager.GetMaxScore()}");
                            break;

                        case "7": // Tìm kiếm
                            Console.Write("Nhập ID cần tìm: ");
                            string findId = Console.ReadLine();
                            Student foundStudent = manager.FindStudentById(findId);
                            if (foundStudent != null)
                            {
                                Console.WriteLine("Tìm thấy:");
                                foundStudent.Display();
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy sinh viên này.");
                            }
                            break;

                        case "0":
                            running = false;
                            Console.WriteLine("Tạm biệt!");
                            break;

                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Bạn đã nhập sai định dạng số (ví dụ: điểm phải là số).");
                }
                catch (ArgumentException ex)
                {
                    // Bắt lỗi từ Class Student (Validation ID, Score...)
                    Console.WriteLine($"Lỗi dữ liệu: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Đã xảy ra lỗi không xác định: {ex.Message}");
                }
            }
        }
    }
}

