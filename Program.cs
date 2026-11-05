using System;
using System.Collections.Generic;
namespace Collections;

class Program
{
    private static void Main()
    {
        // - 1
        Console.WriteLine("=== 1 ===");
        ShowName("    ");
        // - 2
        Console.WriteLine("=== 2 ===");
        ShowGrades([]);
        // - 3
        Console.WriteLine("=== 3 ===");
        ShowSelectedGrade([80, 90, 100], 3);
        // - 4
        Console.WriteLine("=== 4 ===");
        ShowNames();
        // - 5
        Console.WriteLine("=== 5 ===");
        FindStudent(new List<string> { "Ali", "Malika", "Madina" }, "Ma");
        // - 6
        Console.WriteLine("=== 6 ===");
        TryRemoveStudent(new List<string> { "Ali" }, 1);

        // - 7
        Console.WriteLine("=== 7 ===");
        Dictionary<int, string> students = new Dictionary<int, string>
        {
            { 101, "Ali" },
            { 102, "Vali" }
        };
        SearchStudent(students, 101);
        UpdateStudent(students, 101, "Alisher");
        AddStudent(students, 103, "Ali");
        RemoveStudent(students, 102);
        RemoveStudent(students, 999);

        Console.WriteLine("=== 8 ===");

        ProcessEmails(new List<string> { "  ALI@example.com  ", "ali@example.com", "vali@example.com" });
        ProcessEmails(new List<string> { "", "   " });

        Console.WriteLine("=== 9 ===");

        string[] groupA = { "ali@example.com", "vali@example.com", "malika@example.com" };
        string[] groupB = { "vali@example.com", "aziza@example.com" };
        ProcessSetOperations(groupA, groupB);

        Console.WriteLine("=== 10 ===");
        FindMinMaxGrades([75, 75, 75]);

        Console.WriteLine("=== 11 ===");
        AnalyzeGrades([75, 55, 85, 45, 90]);


        Console.WriteLine("=== 12 ===");

        List<int> grades = new List<int> { 40, 55 };
        FilterHighGrades(grades);

        Console.WriteLine("=== 13 ===");
        CountStudentNames(["Ali", "Vali", "Ali", "Malika", "Aziza", "Ali"]);
    }

    // - 1
    static void ShowName(string studentName)
    {
        if (string.IsNullOrWhiteSpace(studentName))
        {
            Console.WriteLine("Ism bo'sh.");
        }
        else
        {
            studentName = studentName.Trim();
            Console.WriteLine($"Ism: {studentName}; Length: {studentName.Length}; Birinchi: {studentName[0]}");
        }
    }

    // - 2
    static void ShowGrades(int[] grades)
    {
        if (grades == null || grades.Length == 0)
        {
            Console.WriteLine("Jami 0; Baholar hali yo'q; Bo‘lish bajarilmaydi.");
            return;
        }

        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write($"{i + 1}-baho: {grades[i]}; ");
        }

        int total = 0;

        foreach (int grade in grades)
        {
            total += grade;
        }
        double average = (double)total / grades.Length;

        Console.WriteLine($"jami {total}; o‘rtacha {average};");
    }

    // - 3
    static void ShowSelectedGrade(int[] grades, int gradeNumber)
    {
        if (grades == null || grades.Length == 0)
        {
            Console.WriteLine("Raqam noto'g'ri.");
            return;
        }

        if (gradeNumber <= 0 || gradeNumber > grades.Length)
        {
            Console.WriteLine("Raqam noto'g'ri.");
            return;
        }

        Console.WriteLine($"Tanlangan baho: {grades[gradeNumber - 1]}");
    }

    // - 4
    static void ShowNames()
    {
        List<string> names = ["Ali", "Vali"];

        names.Add("Malika");
        names.AddRange(["Aziza", "Ali"]);

        names[1] = "Valijon";
        Console.Write($"Count: {names.Count}; ");
        Console.Write("Tartib: " + string.Join(", ", names) + "; ");
        Console.WriteLine($"Capacity: {names.Capacity};");
    }

    // - 5
    static void FindStudent(List<string> names, string startWith)
    {
        if (names == null || names.Count == 0)
        {
            Console.WriteLine("Talaba topilmadi..");
            return;
        }
        var foundName = names.Find(name => name.StartsWith(startWith));

        if (foundName != null)
        {
            Console.WriteLine($"{foundName}");
        }

    }

    // - 6

    static void TryRemoveStudent(List<string> students, int studentNumber)
    {
        if (studentNumber <= 0 || studentNumber > students.Count || students.Count == 0)
        {
            Console.WriteLine($"{false}; Raqam noto'g'ri.; Count: {students.Count}");
            return;
        }

        students.RemoveAt(studentNumber - 1);
        Console.WriteLine($"{true}; Count: {students.Count}; {string.Join(", ", students)}");
    }

    // - 7

    static void SearchStudent(Dictionary<int, string> students, int id)
    {
        if (students.TryGetValue(id, out string? name))
        {
            Console.WriteLine(name);
        }
        else
        {
            Console.WriteLine("Talaba topilmadi.");
        }
    }

    static void UpdateStudent(Dictionary<int, string> students, int id, string newName)
    {
        students[id] = newName;
        Console.WriteLine($"{id} → {students[id]}; Count {students.Count}");
    }

    static void AddStudent(Dictionary<int, string> students, int id, string name)
    {
        students.Add(id, name);
        Console.WriteLine($"Count {students.Count}");
    }

    static void RemoveStudent(Dictionary<int, string> students, int id)
    {
        bool isRemoved = students.Remove(id);
        Console.WriteLine($"{isRemoved}; Count {students.Count}");
    }

    // - 8
    static void ProcessEmails(List<string> emails)
    {
        HashSet<string> uniqueEmails = new HashSet<string>();
        List<string> outputMessages = new List<string>();

        foreach (var input in emails)
        {
            string cleanedEmail = input.Trim().ToLowerInvariant();
            if (string.IsNullOrEmpty(cleanedEmail))
            {
                outputMessages.Add("Email bo'sh.");
            }
            else
            {
                bool isAdded = uniqueEmails.Add(cleanedEmail);
                outputMessages.Add(isAdded.ToString());
            }
        }
        string result = string.Join("; ", outputMessages) + $"; Count {uniqueEmails.Count}";
        Console.WriteLine(result);

    }

    // - 9

    static void ProcessSetOperations(string[] groupA, string[] groupB)
    {

        var unionSet = new HashSet<string>(groupA);
        unionSet.UnionWith(groupB);
        Console.WriteLine($"Amal:Birlashma {string.Join(", ", unionSet)}, Count: {unionSet.Count}");


        var intersectSet = new HashSet<string>(groupA);
        intersectSet.IntersectWith(groupB);
        Console.WriteLine($"Amal:Kesishma {string.Join(", ", intersectSet)}, Count: {intersectSet.Count}");


        var exceptSet = new HashSet<string>(groupA);
        exceptSet.ExceptWith(groupB);
        Console.WriteLine($"Amal:Ayirma {string.Join(", ", exceptSet)}, Count: {exceptSet.Count}");

    }

    // - 10
    static void FindMinMaxGrades(int[] grades)
    {
        if (grades == null || grades.Length == 0)
        {
            Console.WriteLine("Baholar hali yo'q.");
            return;
        }

        int min = grades[0];
        int max = grades[0];

        for (int i = 1; i < grades.Length; i++)
        {
            if (grades[i] < min)
            {
                min = grades[i];
            }

            if (grades[i] > max)
            {
                max = grades[i];
            }
        }
        Console.WriteLine($"Eng kichik baho: {min}; Eng katta baho: {max}");
    }

    // - 11

    static void AnalyzeGrades(int[] grades)
    {
        int passedCount = 0;
        int failedCount = 0;

        if (grades == null || grades.Length == 0)
        {
            Console.WriteLine($"O'tganlar: {passedCount}; O'tmaganlar: {failedCount}");
            return;
        }

        foreach (int grade in grades)
        {
            if (grade >= 60)
            {
                passedCount++;
            }
            else
            {
                failedCount++;
            }
        }
        Console.WriteLine($"O'tganlar: {passedCount}; O'tmaganlar: {failedCount}");

    }

    // - 12
    static void FilterHighGrades(List<int> grades)
    {
        List<int> selectedGrades = new List<int>();

        foreach (int grade in grades)
        {
            if (grade >= 80)
            {
                selectedGrades.Add(grade);
            }
        }

        string originalStr = grades.Count > 0 ? string.Join(", ", grades) : "Bo‘sh ro‘yxat";

        string newStr;
        if (selectedGrades.Count > 0)
        {
            newStr = string.Join(", ", selectedGrades);
        }
        else
        {
            newStr = "Bo‘sh; Mos baholar yo'q.";
        }

        int count = selectedGrades.Count;

        Console.WriteLine($"Asl ro‘yxat: {originalStr} | Yangi ro‘yxat: {newStr} | Yangi Count: {count}");
    }

    // - 13
    static void CountStudentNames(string[] students)
    {
        if (students == null || students.Length == 0)
        {
            Console.WriteLine("Ismlar yo'q. | Lug‘at Count: 0");
            return;
        }
        Dictionary<string, int> nameCounts = new Dictionary<string, int>();

        foreach (string name in students)
        {
            if (nameCounts.TryGetValue(name, out int count))
            {
                nameCounts[name] = count + 1;
            }
            else
            {
                nameCounts.Add(name, 1);
            }
        }

        List<string> resultPairs = new List<string>();
        foreach (var pair in nameCounts)
        {
            resultPairs.Add($"{pair.Key} → {pair.Value}");
        }
        Console.WriteLine(string.Join("; ", resultPairs) + $" | Lug‘at Count: {nameCounts.Count}");
    }

}
