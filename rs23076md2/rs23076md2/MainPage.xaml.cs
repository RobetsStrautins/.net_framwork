using System.Globalization;
using System.Xml.Schema;
using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Numerics;
using Microsoft.VisualBasic;
using System.Reflection;




namespace rs23076md2
{
    public partial class MainPage : ContentPage
    {

        public enum Gender
        {
            Men,
            Women
        }

        public void test()// nu nezinu vai so vajag komenete jo liekas pasaprotams :D bet labi
        {
            // uztaisa teacher
            Teacher teacher1 = new Teacher("John", "Doe", Gender.Men, new DateTime(2015, 5, 23));
            Teacher teacher2 = new Teacher("Jane", "Smith", Gender.Women, new DateTime(2018, 8, 19));
            Teacher teacher3 = new Teacher("Roberts", "Kipurs", Gender.Men, new DateTime(2012, 3, 14));

            // pievieno listam
            Teacher.Teachers.Add(new Teacher("John", "Doe", Gender.Men, new DateTime(2015, 5, 23)));
            Teacher.Teachers.Add(teacher2);
            Teacher.Teachers.Add(teacher3);

            // uztaisa stundetus
            Student student1 = new Student("Michael", "Johnson", Gender.Men, "AB12345");
            Student student2 = new Student("Sarah", "Williams", Gender.Women, "CD23456");
            Student student3 = new Student("Robert", "Jones", Gender.Men, "EF34567");
            Student student4 = new Student("Laura", "Brown", Gender.Women, "GH45678");
            Student student5 = new Student("David", "Davis", Gender.Men, "IJ56789");


            Student.Students.Add(student1);
            Student.Students.Add(student2);
            Student.Students.Add(student3);
            Student.Students.Add(student4);
            Student.Students.Add(student5);

            // uztaisa course
            Course course1 = new Course("Mathematics", teacher1);
            Course course2 = new Course("Physics", teacher2);
            Course course3 = new Course("Chemistry", teacher2);
            Course course4 = new Course("Biology", teacher2);
            Course course5 = new Course("History", teacher3);
            Course course6 = new Course("Computer Science", teacher1);


            Course.Courses.Add(course1);
            Course.Courses.Add(course2);
            Course.Courses.Add(course3);
            Course.Courses.Add(course4);
            Course.Courses.Add(course5);
            Course.Courses.Add(course6);

            // uztaisa Assignement ja es kopeju Assignement jo man slinkums visu laiku to rakstit
            Assignement assignment1 = new Assignement(DateTime.Now.AddDays(7), course1, "Algebra homework");
            Assignement assignment2 = new Assignement(DateTime.Now.AddDays(14), course2, "Newton's Laws of Motion");
            Assignement assignment3 = new Assignement(DateTime.Now.AddDays(10), course3, "Chemical Reactions Lab Report");
            Assignement assignment4 = new Assignement(DateTime.Now.AddDays(5), course4, "Cell Biology Project");
            Assignement assignment5 = new Assignement(DateTime.Now.AddDays(20), course5, "World War II Essay");
            Assignement assignment6 = new Assignement(DateTime.Now.AddDays(12), course6, "Java Programming Task");
            Assignement assignment7 = new Assignement(DateTime.Now.AddDays(5), course4, "Plants and Meat");


            Assignement.Assignments.Add(assignment1);
            Assignement.Assignments.Add(assignment2);
            Assignement.Assignments.Add(assignment3);
            Assignement.Assignments.Add(assignment4);
            Assignement.Assignments.Add(assignment5);
            Assignement.Assignments.Add(assignment6);
            Assignement.Assignments.Add(assignment7);

            // uztaisa Submission ari Submission man slinkums rakstit 
            Submission submission1 = new Submission(assignment1, student1, DateTime.Now.AddDays(3), 85);
            Submission submission2 = new Submission(assignment2, student2, DateTime.Now.AddDays(1), 92);
            Submission submission3 = new Submission(assignment3, student3, DateTime.Now.AddDays(5), 78);
            Submission submission4 = new Submission(assignment4, student4, DateTime.Now.AddDays(2), 90);
            Submission submission5 = new Submission(assignment5, student5, DateTime.Now.AddDays(15), 88);
            Submission submission6 = new Submission(assignment2, student3, DateTime.Now.AddDays(9), 9);
            Submission submission7 = new Submission(assignment3, student2, DateTime.Now.AddDays(6), 80);


            Submission.Submissions.Add(submission1);
            Submission.Submissions.Add(submission2);
            Submission.Submissions.Add(submission3);
            Submission.Submissions.Add(submission4);
            Submission.Submissions.Add(submission5);
            Submission.Submissions.Add(submission6);
            Submission.Submissions.Add(submission7);
            //teiksu godigi man apnika rakstit 
        }


        public MainPage()
        {
            InitializeComponent();

        }



        private void OnDataClicked(object sender, EventArgs e)// kad nosapiests data parada clases un paslej parejo
        {
            ButtonGroup.IsVisible = false;
            Label1.IsVisible = false;


            Back.IsVisible = true;
            ButtonGroup1.IsVisible = true;
        }
        private void OnSaveClicked(object sender, EventArgs e)// kad nosapiests save parada tekstu un saglaba visas classes
        {
            Label1.IsVisible = true;
            Label1.Text = "Dati tika saglabāti.";// nomaina tekstu 

            // failu lokacija
            string fileLocationT = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Teachers.txt");
            string fileLocationSt = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Students.txt");
            string fileLocationC = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Courses.txt");
            string fileLocationA = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Assignments.txt");
            string fileLocationS = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Submissions.txt");
            // failu izdzesana pirms rakstisanas
            File.WriteAllText(fileLocationT, string.Empty);
            File.WriteAllText(fileLocationSt, string.Empty);
            File.WriteAllText(fileLocationC, string.Empty);
            File.WriteAllText(fileLocationA, string.Empty);
            File.WriteAllText(fileLocationS, string.Empty);

            //padara visus class vairaks rindinas
            string pTeachers = "", pStundents = "", pCourses = "", pAssignments = "", pSubmissions = "";
            foreach (var teacher in Teacher.Teachers) // atkaro tik daudz reizes cik lista
            {
                pTeachers += teacher.ToString() + "\n"; //pieliek jaunu rindinu
                foreach (var student in Student.Students)
                {
                    pStundents += student.ToString() + "\n";
                }
                foreach (var course in Course.Courses)
                {
                    pCourses += course.ToString() + "\n";
                }
                foreach (var assignement in Assignement.Assignments)
                {
                    pAssignments += assignement.ToString() + "\n";
                }
                foreach (var submission in Submission.Submissions)
                {
                    pSubmissions += submission.ToString() + "\n";
                }

                // ieraksta atiecigo class sava faila
                using (StreamWriter streamWriter = new StreamWriter(fileLocationT))
                {
                    streamWriter.Write(pTeachers);
                }

                using (StreamWriter streamWriter = new StreamWriter(fileLocationSt))
                {
                    streamWriter.Write(pStundents);
                }

                using (StreamWriter streamWriter = new StreamWriter(fileLocationC))
                {
                    streamWriter.Write(pCourses);
                }

                using (StreamWriter streamWriter = new StreamWriter(fileLocationA))
                {
                    streamWriter.Write(pAssignments);
                }

                using (StreamWriter streamWriter = new StreamWriter(fileLocationS))
                {
                    streamWriter.Write(pSubmissions);
                }

            }
        }
        private void OnLoadClicked(object sender, EventArgs e)//kad nosapiests load parada tekstu un ielade no failus no saglabatiem failiem
        {
            Label1.IsVisible = true;
            Label1.Text = "Tika ielādēti dati.";

            //failu lokacija
            string fileLocationT = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Teachers.txt");
            string fileLocationSt = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Students.txt");
            string fileLocationC = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Courses.txt");
            string fileLocationA = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Assignments.txt");
            string fileLocationS = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "SaveFiles", "Submissions.txt");

            //meigina pieklut failam
            try
            {
                using (StreamReader streamReader = new StreamReader(fileLocationT))
                {
                    //nem pa rindinai un tad saples mazakos lai uztaisitu jaunu
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length >= 2)
                        {
                            string[] parts = line.Split(',');//sadala kur komats
                            string name = parts[0].Split(':')[1].Trim();  // sadala atkal un panem labo pusi no :
                            string surname = parts[1].Split(':')[1].Trim(); // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), parts[2].Split(':')[1].Trim()); // tas pac kas ieprieks plus parveido uz "gender" lai varetu uztasit teacher
                            string dateString = parts[3].Replace("Date:", "").Trim();// tas pac kas iepriesk plus nonem date jo sekunes ari ir :
                            DateTime contractDate = DateTime.Parse(dateString);// paraisa no string uz date
                            Teacher.Teachers.Add(new Teacher(name, surname, gender, contractDate));// uztaisa teacher
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading Teachers: {ex.Message}");
            }
            try
            {
                using (StreamReader streamReader = new StreamReader(fileLocationSt))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length >= 2)
                        {
                            string[] parts = line.Split(',');// ne nu siten ir tas pac 
                            string name = parts[0].Split(':')[1].Trim();
                            string surname = parts[1].Split(':')[1].Trim();
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), parts[2].Split(':')[1].Trim());
                            string ID = parts[3].Split(':')[1].Trim();
                            Student.Students.Add(new Student(name, surname, gender, ID));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading Stundents: {ex.Message}");
            }
            try
            {
                using (StreamReader streamReader = new StreamReader(fileLocationC))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length >= 2)
                        {

                            string[] parts = line.Split(',');// un atkal tas pac
                            string course = parts[0].Split(':')[1].Trim();
                            string name = parts[1].Split(':')[1].Trim();
                            string surname = parts[2].Split(':')[1].Trim();
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), parts[3].Split(':')[1].Trim());
                            string dateString = parts[4].Replace("Date:", "").Trim();
                            DateTime contractDate = DateTime.Parse(dateString);

                            Course.Courses.Add(new Course(course, new Teacher(name, surname, gender, contractDate)));//yappy vins netaisa dubulta :)
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading Courses: {ex.Message}");
            }
            try
            {
                using (StreamReader streamReader = new StreamReader(fileLocationA))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length >= 2)
                        {

                            string[] parts = line.Split(',');// un atkal tiesi tas pac
                            string date1 = parts[0].Replace("Deadline:", "").Trim();
                            DateTime contractDate1 = DateTime.Parse(date1);
                            string course = parts[1].Split(':')[1].Trim();
                            string name = parts[2].Split(':')[1].Trim();
                            string surname = parts[3].Split(':')[1].Trim();
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), parts[4].Split(':')[1].Trim());
                            string dateString = parts[5].Replace("Date:", "").Trim();
                            DateTime contractDate = DateTime.Parse(dateString);
                            string tekts = parts[6].Split(':')[1];

                            Assignement.Assignments.Add(new Assignement(contractDate1, new Course(course, new Teacher(name, surname, gender, contractDate)), tekts));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading Assignments: {ex.Message}");
            }
            try
            {
                using (StreamReader streamReader = new StreamReader(fileLocationS))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Length >= 2)
                        {

                            string[] parts = line.Split(',');// jus neticesies be takal tiesi tas pac kas sakuma
                            string date1 = parts[0].Replace("Deadline:", "").Trim();
                            DateTime contractDate1 = DateTime.Parse(date1);
                            string course = parts[1].Split(':')[1].Trim();
                            string name = parts[2].Split(':')[1].Trim();
                            string surname = parts[3].Split(':')[1].Trim();
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), parts[4].Split(':')[1].Trim());
                            string dateString = parts[5].Replace("Date:", "").Trim();
                            DateTime contractDate = DateTime.Parse(dateString);
                            string tekts = parts[6].Split(':')[1];
                            string name1 = parts[7].Split(':')[1].Trim();
                            string surname1 = parts[8].Split(':')[1].Trim();
                            Gender gender1 = (Gender)Enum.Parse(typeof(Gender), parts[9].Split(':')[1].Trim());
                            string ID = parts[10].Split(':')[1].Trim();
                            string dateString2 = parts[11].Replace("submissionTime:", "").Trim();
                            DateTime contractDate2 = DateTime.Parse(dateString);
                            string scoreString = parts[12].Split(':')[1].Trim();
                            int score = int.Parse(scoreString);


                            Submission.Submissions.Add(new Submission(new Assignement(contractDate1, new Course(course, new Teacher(name, surname, gender, contractDate)), tekts), new Student(name1, surname1, gender1, ID), contractDate2, score));// Correctly instantiate and add to list
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading Submission: {ex.Message}");
            }
            // jaiedzer!!! nu protam es domaju udeni
        }
        private void OnTestClicked(object sender, EventArgs e)//ielade testa failus vai palilda ja jau ir
        {
            test();
            Label1.IsVisible = true;
            Label1.Text = "Tika ielādēti testa dati.";
        }
        private void OnClearClicked(object sender, EventArgs e)//izdzes klases
        {
            // notira visus listus ar klases
            Submission.Submissions.Clear();
            Assignement.Assignments.Clear();// es nevaru dala kodu ir Assignement un daza ir Assignment aaaaaaaaaaaaaaaaaaaaa 
            Course.Courses.Clear();
            Student.Students.Clear();
            Teacher.Teachers.Clear();

            Label1.IsVisible = true;
            Label1.Text = "Tika izdzēsti visi dati. \nHa pat nevar uztaisit neko jaunu jo sis izdzes ari Teachers un Courses nu tik talu nepadomaju";// yee teksts izsaka visu

        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            //prada visas pirmas pogas un noslepj vius parejo
            TeacherListStack.Children.Clear();
            ButtonGroup.IsVisible = true;
            Back.IsVisible = false;
            Label1.IsVisible = false;
            ButtonGroup1.IsVisible = false;
        }


        private void TeacherClicked(object sender, EventArgs e)//parada visus Teacher
        {

            TeacherListStack.Children.Clear();// sis tiek izmantots lai raditu visus class un form tpc visur sakuma vins izdzesis

            // iet caur katru Teacher kas ir lista uz uztaisa jaunu lable priek ta
            foreach (var teacher in Teacher.Teachers)
            {
                string teksts = teacher.ToString();
                teksts = teksts.Replace(", ", "\n") + "\n========";// panem no list 
                // rekur sis taisa tos jaunos lable un ja es nevareju izdomat ko pielikt klat 
                var teacherLabel = new Label
                {
                    Text = teksts,// parsauc label taja varda
                    FontSize = 20,

                };
                TeacherListStack.Children.Add(teacherLabel);// galvenias ir sis lai pievienotu un redzetu
            }
        }

        private void StudentClicked(object sender, EventArgs e)//parada visus Student
        {
            TeacherListStack.Children.Clear();
            //Lai sakuma paradas add button sis pa lielam bus ka visias pogas izskatisis no protams bez green
            var addButton = new Button
            {
                Text = "Add new student",
                FontSize = 22,
                BackgroundColor = Colors.Green,
                HorizontalOptions = LayoutOptions.Start // Sis man patik ko vins vnk noliek pie kreisas puses nevis pa vidu
            };
            addButton.Clicked += (s, args) =>
            {
                //partrauc un aizsuta uz forms aka vnk izdzs kas bija un taisa no jauna
                StudentForm();
            };
            TeacherListStack.Children.Add(addButton);

            // atkal taisa katram savu label
            foreach (var students in Student.Students)
            {
                string teksts = students.ToString();
                teksts = teksts.Replace(", ", "\n") + "\n========";
                var teacherLabel = new Label// ja visus te label sauc teacher a ko vini parak daudz bija
                {
                    Text = teksts,
                    FontSize = 20,
                };
                TeacherListStack.Children.Add(teacherLabel);

            }
        }
        private void CourseClicked(object sender, EventArgs e)//parada visus Course
        {
            TeacherListStack.Children.Clear();

            // tiesam man savi jatkarto nu labi ta tad "// iet caur katru Teacher kas ir lista uz uztaisa jaunu lable priek ta" tik Teacher vieta ir Course
            foreach (var course in Course.Courses)
            {
                string teksts = course.ToString();
                teksts = teksts.Replace(", ", "\n") + "\n========";
                var teacherLabel = new Label
                {
                    Text = teksts,
                    FontSize = 20,

                };
                TeacherListStack.Children.Add(teacherLabel);

            }
        }
        private void AssignmentClicked(object sender, EventArgs e)//parada visus Assignment
        {
            TeacherListStack.Children.Clear();
            // jus ari velejaties lai asignments var pievienots soo ja ari seit ir add poga
            var addButton = new Button
            {
                Text = "Add new assignment",
                FontSize = 22,
                BackgroundColor = Colors.Green,
                HorizontalOptions = LayoutOptions.Start
            };
            addButton.Clicked += (s, args) =>
            {
                AssignmentForm();
            };
            TeacherListStack.Children.Add(addButton);

            // jus neticesiet bet seit ar nem no list un taisa katram label 
            foreach (var assignment in Assignement.Assignments)
            {
                string teksts = assignment.ToString();
                teksts = teksts.Replace(", ", "\n") + "\n========";
                var teacherLabel = new Label
                {
                    Text = teksts,
                    FontSize = 20,
                };
                TeacherListStack.Children.Add(teacherLabel);
                // vot te sakas intrasanta dala jo nak jaunas pogas
                var buttonLayout = new HorizontalStackLayout//sis ir lai pogas butu blakam pectam
                {
                    Spacing = 10,
                    HorizontalOptions = LayoutOptions.Start
                };

                // pirma poga delete pasaprotami vnk izdzes
                var viewButton = new Button
                {
                    Text = "Delete",
                    FontSize = 15,
                    WidthRequest = 100,
                    BackgroundColor = Colors.Red,// hehe kurs butu gaidijs ka delete ir sarkans ps. te nav bridinajumi
                    HorizontalOptions = LayoutOptions.Start
                };
                viewButton.Clicked += (s, args) =>
                {
                    Assignement.Assignments.Remove(assignment); // nu ja sis notiek tas Assignement ir gone 
                    RefreshAssignments(); // sis ir lai atjaunotu datus
                };

                // otra poga edit  sis bija smagi taka loti smagi
                var editButton = new Button
                {
                    Text = "Edit",
                    FontSize = 15,
                    WidthRequest = 100,
                    BackgroundColor = Colors.LightGray,
                    HorizontalOptions = LayoutOptions.Start // Align button to the left
                };
                editButton.Clicked += (s, args) =>
                {
                    EditAssignmentForm(assignment);// tiesi is funkcija bija smaga un ari add bet tas vel nebija tik traki
                };

                buttonLayout.Children.Add(viewButton);
                buttonLayout.Children.Add(editButton);
                TeacherListStack.Children.Add(buttonLayout);
            }
        }
        private void SubmissionClicked(object sender, EventArgs e)//parada visus Submission
        {
            TeacherListStack.Children.Clear();

            // ir taka 1 on 1 kopija Assignment tik mazliet nomainits
            var addButton = new Button
            {
                Text = "Add new submission",
                FontSize = 22,
                BackgroundColor = Colors.Green,
                HorizontalOptions = LayoutOptions.Start
            };
            addButton.Clicked += (s, args) =>
            {
                SubmissionForm();
            };
            TeacherListStack.Children.Add(addButton);

            foreach (var submission in Submission.Submissions)
            {
                string teksts = submission.ToString();
                teksts = teksts.Replace(", ", "\n") + "\n========";
                var teacherLabel = new Label
                {
                    Text = teksts,
                    FontSize = 20,
                };
                TeacherListStack.Children.Add(teacherLabel);

                var buttonLayout = new HorizontalStackLayout
                {
                    Spacing = 10,
                    HorizontalOptions = LayoutOptions.Start
                };

                var viewButton = new Button
                {
                    Text = "Delete",
                    FontSize = 15,
                    WidthRequest = 100,
                    BackgroundColor = Colors.Red,
                    HorizontalOptions = LayoutOptions.Start
                };
                viewButton.Clicked += (s, args) =>
                {
                    Submission.Submissions.Remove(submission);
                    RefreshSubmissions();
                    return;
                };

                var editButton = new Button
                {
                    Text = "Edit",
                    FontSize = 15,
                    WidthRequest = 100,
                    BackgroundColor = Colors.LightGray,
                    HorizontalOptions = LayoutOptions.Start
                };
                editButton.Clicked += (s, args) =>
                {
                    EditSubmissionForm(submission);
                };

                buttonLayout.Children.Add(viewButton);
                buttonLayout.Children.Add(editButton);
                TeacherListStack.Children.Add(buttonLayout);
            }
        }
        private void RefreshAssignments()// sis ir reali lai izsauktu atpakal to funkciju
        {

            AssignmentClicked(null, EventArgs.Empty);
        }
        private void RefreshSubmissions()// sis ir reali lai izsauktu atpakal to funkciju
        {
            SubmissionClicked(null, EventArgs.Empty);
        }
        void StudentForm()//nu forom
        {
            TeacherListStack.Children.Clear();

            // vajag katram label prieks teksta 
            // sis ir vardam
            TeacherListStack.Children.Add(new Label//lai butu teksts 
            {
                Text = "Name",
                FontSize = 20,
            });
            var nameEntry = new Entry// lai butu kur ierakstit
            {
                Placeholder = "Enter Name",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            TeacherListStack.Children.Add(nameEntry);

            // uzvardam 
            TeacherListStack.Children.Add(new Label
            {
                Text = "Surname",
                FontSize = 20,
            });
            var surnameEntry = new Entry
            {
                Placeholder = "Enter Surname",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            TeacherListStack.Children.Add(surnameEntry);

            // Gender ps. sis bija mazliet cakars
            TeacherListStack.Children.Add(new Label
            {
                Text = "Gender",
                FontSize = 20,
            });
            var genderPicker = new Picker
            {
                Title = "Select Gender",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            genderPicker.ItemsSource = Enum.GetNames(typeof(Gender));
            TeacherListStack.Children.Add(genderPicker);

            // ID bija plans ka es pats uztaisisu bet nepietika laiks taka lidziga sistma LU
            TeacherListStack.Children.Add(new Label
            {
                Text = "ID",
                FontSize = 20,
            });
            var idEntry = new Entry
            {
                Placeholder = "Enter ID",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            TeacherListStack.Children.Add(idEntry);

            // Submit poga
            var submitButton = new Button
            {
                Text = "Submit",
                FontSize = 22,
                BackgroundColor = Colors.Blue,// atvainojos ka tik prasti bet nebija idejas
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100
            };
            submitButton.Clicked += async (s, args) =>
            {
                // sis ir lai nonemtu liekas atsrpes 
                string name = nameEntry.Text?.Trim();
                string surname = surnameEntry.Text?.Trim();
                string id = idEntry.Text?.Trim();
                string selectedGender = genderPicker.SelectedItem?.ToString();

                // lai parbauditu ka ir kkas ielikts
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(selectedGender))
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Aizpildi laukus", "Aizpildi laukus", "Aizpildi laukus");// man patika ko es atradu interneta so es paturu ps. aizmirsu pievienot atsauksmi bet izskatas pietiekami simple lai zinatu
                    return;  // atgriezas atpakl lai var aizpildit un nepievieno aks ir galvenais

                }

                // parveido gender lai varetu ielikt ieksa sutdenta 
                // ammm tas izklausas nepareizi
                Gender gender = (Gender)Enum.Parse(typeof(Gender), selectedGender);

                Student.Students.Add(new Student(name, surname, gender, id));

                // aatjaunina students ar jauno cilveku
                StudentClicked(null, EventArgs.Empty); // Refresh main view
            };

            // Add the submit button to the layout
            TeacherListStack.Children.Add(submitButton);
        }
        void AssignmentForm()// nu velviesn forom
        {
            TeacherListStack.Children.Clear();

            // lidzigi ka iepriekseji bet laiks iet uz beigam so komentesu tik kas izmainas
            // Course
            TeacherListStack.Children.Add(new Label
            {
                Text = "Course",
                FontSize = 20,
            });
            var coursePicker = new Picker
            {
                Title = "Select Course",
                FontSize = 20,
                MinimumWidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };

            // seit ir lai paraditos izvele no esosiem kursism
            coursePicker.ItemsSource = Course.Courses.Select(course => course.GetCourseName()).ToList();
            TeacherListStack.Children.Add(coursePicker);
            //Description
            TeacherListStack.Children.Add(new Label
            {
                Text = "Description",
                FontSize = 20,
            });
            var descriptionEntry = new Entry
            {
                Placeholder = "Enter Description",
                FontSize = 20,
                MinimumWidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            TeacherListStack.Children.Add(descriptionEntry);

            // Deadline sis ir kinda slikti uztaisits nu man bija vizija kura bija labi, si nav ta vizija
            TeacherListStack.Children.Add(new Label
            {
                Text = "Deadline (YYYY-MM-DD)",
                FontSize = 20,
            });
            var deadlineEntry = new Entry
            {
                Placeholder = "Enter Deadline",
                FontSize = 20,
                MinimumWidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            TeacherListStack.Children.Add(deadlineEntry);

            // Submit poga atkal
            var submitButton = new Button
            {
                Text = "Submit",
                FontSize = 22,
                BackgroundColor = Colors.Blue,
                HorizontalOptions = LayoutOptions.Start,
                MinimumWidthRequest = 100
            };
            submitButton.Clicked += async (s, args) =>
            {
                // 
                string description = descriptionEntry.Text?.Trim();
                string deadlineInput = deadlineEntry.Text?.Trim();
                string selectedCourseName = coursePicker.SelectedItem?.ToString();

                // atkal parbaude vai vispar vajadzeja parbaudi? ig labak ir nevis nav
                if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(deadlineInput) || string.IsNullOrWhiteSpace(selectedCourseName) ||
                !DateTime.TryParse(deadlineInput, out DateTime deadline) || Course.Courses.FirstOrDefault(c => c.GetCourseName() == selectedCourseName) == null)
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Aizpildi laukus", "Aizpildi laukus", "Aizpildi laukus");
                    return;
                }
                // parveido un uztaisa jaunu Assignments
                Course selectedCourse = Course.Courses.FirstOrDefault(c => c.GetCourseName() == selectedCourseName);
                Assignement.Assignments.Add(new Assignement(deadline, selectedCourse, description));

                AssignmentClicked(null, EventArgs.Empty);
            };

            TeacherListStack.Children.Add(submitButton);
        }

        void SubmissionForm()
        {
            TeacherListStack.Children.Clear();

            // ja vel sekojat esat nopelnijusi kko saldu piemeram konfekti
            //es atkal skrienu cauri nebus atkal 6 sekunas
            //Assignment
            TeacherListStack.Children.Add(new Label
            {
                Text = "Assignment",
                FontSize = 20,
            });
            var assignmentPicker = new Picker
            {
                Title = "Select Assignment",
                FontSize = 20,
                MinimumWidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };

            // parada assignment kas pieejami
            assignmentPicker.ItemsSource = Assignement.Assignments.Select(assignment =>
                assignment.Description).ToList();
            TeacherListStack.Children.Add(assignmentPicker);

            // Student 
            TeacherListStack.Children.Add(new Label
            {
                Text = "Student",
                FontSize = 20,
            });
            var studentPicker = new Picker
            {
                Title = "Select Student",
                FontSize = 20,
                MinimumWidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };

            // izvele no studentiem
            studentPicker.ItemsSource = Student.Students.Select(student =>
                student.ToString()).ToList();
            TeacherListStack.Children.Add(studentPicker);

            // atzime nu score same thing
            TeacherListStack.Children.Add(new Label
            {
                Text = "Score",
                FontSize = 20,
            });
            var scoreEntry = new Entry
            {
                Placeholder = "Enter Score",
                FontSize = 20,
                MinimumWidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            TeacherListStack.Children.Add(scoreEntry);

            // Submit poga mes milam so pogu nav izraisijuas sapes
            var submitButton = new Button
            {
                Text = "Submit",
                FontSize = 22,
                BackgroundColor = Colors.Blue,
                HorizontalOptions = LayoutOptions.Start,
                MinimumWidthRequest = 100
            };
            submitButton.Clicked += async (s, args) =>
            {
                string selectedAssignmentDescription = assignmentPicker.SelectedItem?.ToString();
                string selectedStudentDescription = studentPicker.SelectedItem?.ToString();
                string scoreInput = scoreEntry.Text?.Trim();

                // tik garss if 
                if (string.IsNullOrWhiteSpace(selectedAssignmentDescription) || string.IsNullOrWhiteSpace(selectedStudentDescription) ||
                    string.IsNullOrWhiteSpace(scoreInput) || !int.TryParse(scoreInput, out int score) ||
                    Assignement.Assignments.FirstOrDefault(a => a.Description == selectedAssignmentDescription) == null ||
                    Student.Students.FirstOrDefault(s => s.ToString() == selectedStudentDescription) == null)
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Aizpildi laukus", "Aizpildi laukus", "Aizpildi laukus");
                    return;
                }

                // uztaisa jaunu Submission
                Assignement selectedAssignment = Assignement.Assignments.FirstOrDefault(a => a.Description == selectedAssignmentDescription);
                Student selectedStudent = Student.Students.FirstOrDefault(s => s.ToString() == selectedStudentDescription);
                Submission.Submissions.Add(new Submission(selectedAssignment, selectedStudent, DateTime.Now, score));

                AssignmentClicked(null, EventArgs.Empty);
            };

            TeacherListStack.Children.Add(submitButton);
        }

        private void EditSubmissionForm(Submission submission)// nu sis bija ari sapites
        {
            TeacherListStack.Children.Clear();
            // davaj fiksi esam gandriz gala
            TeacherListStack.Children.Add(new Label
            {
                Text = "Assignment: " + submission.Assignement.Description,
                FontSize = 20,
            });

            // Student 
            TeacherListStack.Children.Add(new Label
            {
                Text = "Student",
                FontSize = 20,
            });
            var studentPicker = new Picker
            {
                Title = "Select Student",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };

            // lai nomainitu student
            studentPicker.ItemsSource = Student.Students.Select(s =>
                s.ToString()).ToList(); // Show student details
            studentPicker.SelectedItem = submission.Student.ToString();
            TeacherListStack.Children.Add(studentPicker);

            // Score vai atzime
            TeacherListStack.Children.Add(new Label
            {
                Text = "Score",
                FontSize = 20,
                TextColor = Colors.Black
            });
            var scoreEntry = new Entry
            {
                Placeholder = "Enter Score",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            scoreEntry.Text = submission.Score.ToString();
            TeacherListStack.Children.Add(scoreEntry);

            // Submit pog atkal vina uzrodas
            var submitButton = new Button
            {
                Text = "Update",
                FontSize = 22,
                BackgroundColor = Colors.Blue,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100
            };
            submitButton.Clicked += async (s, args) =>
            {
                string selectedStudentDescription = studentPicker.SelectedItem?.ToString();
                string scoreInput = scoreEntry.Text?.Trim();

                if (string.IsNullOrWhiteSpace(selectedStudentDescription) ||
                    string.IsNullOrWhiteSpace(scoreInput) ||
                    !int.TryParse(scoreInput, out int score))
                {
                    await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Aizpildi laukus", "Aizpildi laukus", "Aizpildi laukus");
                    return;
                }
                //izmaina submission datus
                submission.Student = Student.Students.FirstOrDefault(s =>
                    s.ToString() == selectedStudentDescription);
                submission.Score = score;

                SubmissionClicked(null, EventArgs.Empty);
            };

            TeacherListStack.Children.Add(submitButton);
        }

        private void EditAssignmentForm(Assignement assignment)// oki pedejais
        {
            TeacherListStack.Children.Clear();
            // ir vel 10 min aka 23:49 busu laika
            // Deadline
            TeacherListStack.Children.Add(new Label
            {
                Text = "Deadline",
                FontSize = 20,
                TextColor = Colors.Black
            });
            var deadlineEntry = new Entry
            {
                Placeholder = "Enter Deadline (yyyy-mm-dd)",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            // man nepatik laiks abas nozimes gan kad jasuta gan ka ievaddati
            deadlineEntry.Text = assignment.Deadline.ToString("yyyy-MM-dd");
            TeacherListStack.Children.Add(deadlineEntry);

            //Description
            TeacherListStack.Children.Add(new Label
            {
                Text = "Description",
                FontSize = 20,
            });
            var descriptionEntry = new Entry
            {
                Placeholder = "Enter Description",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            descriptionEntry.Text = assignment.Description;
            TeacherListStack.Children.Add(descriptionEntry);
            //Course
            TeacherListStack.Children.Add(new Label
            {
                Text = "Course",
                FontSize = 20,
            });
            var coursePicker = new Picker
            {
                Title = "Select Course",
                FontSize = 20,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Start
            };
            coursePicker.ItemsSource = Course.Courses.Select(course => course.GetCourseName()).ToList();
            coursePicker.SelectedItem = assignment.Course.GetCourseName(); // Set selected course
            TeacherListStack.Children.Add(coursePicker);

            // Submit poga vismaz si bus pedeja
            var submitButton = new Button
            {
                Text = "Update",
                FontSize = 22,
                BackgroundColor = Colors.Blue,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100
            };
            submitButton.Clicked += async (s, args) =>
            {

                if (!DateTime.TryParse(deadlineEntry.Text, out DateTime newDeadline) ||
                    string.IsNullOrWhiteSpace(descriptionEntry.Text) ||
                    coursePicker.SelectedItem == null)
                {
                    await App.Current.MainPage.DisplayAlert("Aizpildi laukus", "Aizpildi laukus", "Aizpildi laukus");
                    return; 
                }

                // atjauno datus
                assignment.Deadline = newDeadline;
                assignment.Description = descriptionEntry.Text;
                assignment.Course = Course.Courses.FirstOrDefault(c => c.GetCourseName() == coursePicker.SelectedItem.ToString());

                AssignmentClicked(null, EventArgs.Empty);

            };

            TeacherListStack.Children.Add(submitButton);
        }

    }
}//Paldies par uzmanibu!!!
// bet xaml nebus komentari ka ari pa klases :( 
