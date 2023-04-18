using Lab10;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime;


//номер5--------------------------------------------------------------------------------------------------------------------------------------
try
{
    DirectoryInfo txtdir = new DirectoryInfo(@"..\..\..\basedir\data");
    if (txtdir.Exists)
    {
        Person[] persons = { new Person("Сидоров", 182, 78, new DateTime(1990, 8, 1)), new Person("Иванов", 175, 70, new DateTime(1995, 2, 22)), new Person("Птушкин", 189, 90, new DateTime(2001, 3, 13)) };
        FileInfo filePerson = new FileInfo(Path.Combine(txtdir.FullName, "persons.txt"));
        filePerson.Create().Close();
        using (StreamWriter writer = new StreamWriter(filePerson.FullName))
        {
            foreach (Person person in persons)
            {
                writer.WriteLine($"{person.Lastname};{person.Height};{person.Weight};{person.BtDate.ToShortDateString()}");
            }
        }
        Console.WriteLine("\nЗапись создана.");

        Console.WriteLine("\nВведите данные 2х людей: ");
        Person person4 = new Person();
        person4.Input();
        Person person5 = new Person();
        person5.Input();
        using (StreamWriter writer = new StreamWriter(filePerson.FullName, true))
        {
            writer.WriteLine($"{person4.Lastname};{person4.Height};{person4.Weight};{person4.BtDate.ToShortDateString()}");
            writer.WriteLine($"{person5.Lastname};{person5.Height};{person5.Weight};{person5.BtDate.ToShortDateString()}");
        }

        Person[] all;
        using (StreamReader reader = new StreamReader(filePerson.FullName))
        {
            int count = File.ReadLines(filePerson.FullName).Count();
            all = new Person[count];
            int i = 0;
            foreach (string line in File.ReadLines(filePerson.FullName))
            {
                string[] str = line.Split(';');
                all[i] = new Person(str[0], int.Parse(str[1]), int.Parse(str[2]), DateTime.Parse(str[3]));
                i++;
            }
        }

        Console.WriteLine("\nИмена - Возрост");
        double totalweight = 0;
        double totalheight = 0;
        foreach (Person person in all)
        {
            Console.WriteLine($"{person.Lastname} - {person.FullAge()}");
            totalweight += person.Weight;
            totalheight += person.Height;
        }
        Console.WriteLine($"Средний рост = {totalheight / all.Length}\nСредний вес = {totalweight / all.Length}");

        using (StreamWriter writer = new StreamWriter(filePerson.FullName, true))
        {
            writer.WriteLine($"\nСредний рост;{totalheight / all.Length}");
            writer.WriteLine($"\nСредний вес;{totalweight / all.Length}");
        }


        FileInfo overweightPerson = new FileInfo(Path.Combine(txtdir.FullName, "overweightPerson.txt"));
        filePerson.Create().Close();
        using (StreamWriter writer = new StreamWriter((overweightPerson.FullName), true))
        {
            foreach (Person person in all)
            {
                if (person.Weight > person.Height - 100 + 10)
                {
                    Console.WriteLine($"{person.Lastname} имеет избыточный: {person.Weight} кг, рост: {person.Height} см");

                    writer.WriteLine($"{person.Lastname};{person.Height};{person.Weight};{person.BtDate}");

                }
            }
        }
        Console.WriteLine("\n\nВсе успешно закончилось!\n");

    }
    else
    {
        Console.WriteLine("Директории не существует.");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}




////номер4-----------------------------------------------------------------------------------------------------------------------------------------
//try
//{
//    DirectoryInfo dir = new DirectoryInfo(@"..\..\..\basedir\dir0");
//    DirectoryInfo basedir = new DirectoryInfo(@"..\..\..\basedir");
//    DirectoryInfo txtdir = new DirectoryInfo(@"..\..\..\basedir\data");

//    if (dir.Exists)
//    {
//        foreach (FileInfo file in txtdir.GetFiles())
//        {
//            //a
//            if (file.Name == "dataset_1.txt")
//            {
//                using (StreamReader fdata = new StreamReader(file.FullName))
//                {
//                    string[] line = fdata.ReadLine().Split();
//                    double a = double.Parse(line[0]);
//                    double b = double.Parse(line[1]);
//                    Console.WriteLine("a + b = " + (a + b));
//                    Console.WriteLine("a * b = " + (a * b));
//                    Console.WriteLine("a + b^2 = " + (a + b * b));
//                }
//            }

//            //b
//            if (file.Name == "dataset_2.txt")
//            {
//                using (StreamReader fdata = new StreamReader(file.FullName))
//                {
//                    int counter = 0;
//                    foreach (string line in fdata.ReadToEnd().Split('\n'))
//                    {
//                        foreach (string number in line.Split(' '))
//                        {
//                            if (int.TryParse(number, out int num) && num % 2 == 0)
//                            {
//                                counter++;
//                            }
//                        }
//                    }
//                    Console.WriteLine("\nКоличество четных чисел = " + counter);
//                }
//            }

//            //c
//            if (file.Name == "dataset_3.txt")
//            {
//                FileInfo fileres = new FileInfo(Path.Combine(txtdir.FullName, "res_3.txt"));
//                fileres.Create().Close();

//                Console.WriteLine("Числа меньше 9999: ");
//                using (StreamWriter writer = new StreamWriter(Path.Combine(txtdir.FullName, "res_3.txt")))
//                {
//                    using (StreamReader fdata = new StreamReader(file.FullName))
//                    {
//                        foreach (string line in fdata.ReadToEnd().Split('\n'))
//                        {
//                            foreach (string number in line.Split(' '))
//                            {
//                                if (int.TryParse(number, out int num))
//                                {
//                                    if (num < 9999)
//                                    {
//                                        writer.WriteLine(num);
//                                        Console.WriteLine(num);
//                                    }
//                                }
//                            }
//                        }
//                    }

//                }
//            }

//            //d
//            if (file.Name == "dataset_4.txt")
//            {
//                int max = int.MinValue;
//                using (StreamReader fdata = new StreamReader(file.FullName))
//                {
//                    foreach (string line in fdata.ReadToEnd().Split('\n'))
//                    {
//                        foreach (string number in line.Split(' '))
//                        {
//                            if (int.TryParse(number, out int num))
//                            {
//                                if (num > max)
//                                {
//                                    max = num;
//                                }
//                            }
//                        }
//                    }
//                }
//                Console.WriteLine($"\nМаксимальное число = {max}");
//                using (StreamWriter writer = new StreamWriter(Path.Combine(txtdir.FullName, "res_3.txt"), true))
//                {

//                    writer.WriteLine(max);
//                }
//            }

//            //e
//            if (file.Name == "dataset_5.txt")
//            {
//                using (StreamReader fdata = new StreamReader(file.FullName))
//                {
//                    foreach (string line in fdata.ReadToEnd().Split('\n'))
//                    {
//                        Console.WriteLine(line.ToUpper());
//                    }
//                }

//            }


//        }
//    }
//    else
//    {
//        Console.WriteLine("Директории не существует.");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}







////номер3----------------------------------------------------------------------------------------------------------------------------
//try
//{
//    DirectoryInfo dir = new DirectoryInfo(@"..\..\..\basedir\dir0");
//    DirectoryInfo basedir = new DirectoryInfo(@"..\..\..\basedir");
//    if (dir.Exists)
//    {
//        //a
//        DirectoryInfo picdir = Directory.CreateDirectory(Path.Combine(basedir.FullName, "Picture"));
//        DirectoryInfo hisdir = Directory.CreateDirectory(Path.Combine(basedir.FullName, "Texts", "History"));
//        DirectoryInfo horrdir = Directory.CreateDirectory(Path.Combine(basedir.FullName, "Texts", "Horror", "First"));

//        for(int i = 1; i <= 6; i++)
//        {
//            FileInfo file = new FileInfo(Path.Combine(picdir.FullName, $"{i}.txt"));
//            file.Create().Close();
//        }

//        Console.WriteLine("\nДиректории и файлы были созданы");

//        //b
//        File.Delete(Path.Combine(picdir.FullName, "5000.txt"));
//        File.Move(Path.Combine(picdir.FullName, "5.txt"), Path.Combine(picdir.FullName, "5000.txt"));
//        Console.WriteLine("\nПереименование выполнено");

//        File.Delete(Path.Combine(hisdir.FullName, "5000.txt"));
//        File.Move(Path.Combine(picdir.FullName, "5000.txt"), Path.Combine(hisdir.FullName, "5000.txt"));
//        Console.WriteLine("\nПеремещение выполнено");

//        //c
//        File.Delete(Path.Combine(picdir.FullName, "6.txt"));
//        Console.WriteLine("\nФайл удален.");

//        Console.WriteLine($"Оставшиеся файлы {picdir}:");
//        foreach (FileInfo file in picdir.GetFiles())
//        {
//            Console.WriteLine("- " + file.Name);
//        }

//        Console.Write("Введите имя файла(с расширением), который необходимо удалить: ");
//        string killname = Console.ReadLine();

//        File.Delete(Path.Combine(picdir.FullName, killname));
//        Console.WriteLine("Файл удален.");

//        Directory.Delete(Path.Combine(basedir.FullName, "Texts", "Horror"), true);  //удаление директории с поддиректориями
//        Console.WriteLine("\nДиректория удалена");
//        Directory.Delete(Path.Combine(basedir.FullName, "Picture"), true);
//        Console.WriteLine("\nДиректория удалена");
//    }
//    else
//    {
//        Console.WriteLine("Директории не существует.");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}







//номер2-------------------------------------------------------------------------------------------------------------------------------
static string DeepestObject(DirectoryInfo dir)
{
    string deepestName = dir.FullName;
    int deepestCount = dir.FullName.Split(Path.DirectorySeparatorChar).Length;

    foreach (FileInfo file in dir.GetFiles())
    {
        int fileCount = file.FullName.Split(Path.DirectorySeparatorChar).Length;
        if (fileCount > deepestCount)
        {
            deepestCount = fileCount;
            deepestName = file.FullName;
        }
    }

    foreach (DirectoryInfo subDir in dir.GetDirectories())
    {
        string dirName = DeepestObject(subDir);
        int dirCount = dirName.Split(Path.DirectorySeparatorChar).Length;
        if (dirCount > deepestCount)
        {
            deepestCount = dirCount;
            deepestName = dirName;
        }
    }

    return deepestName;
}


static string GetMaxDirectory(DirectoryInfo basedir)
{
    int maxCount = 0;
    string maxDirName = "";
    Check(basedir);
    void Check(DirectoryInfo basedir)
    {
        foreach (DirectoryInfo dir in basedir.GetDirectories())
        {
            int fileCount = dir.GetFiles().Length;
            //Console.WriteLine($"{dir.FullName} ---------------- {fileCount}");
            if (fileCount > maxCount)
            {
                maxCount = fileCount;
                maxDirName = dir.FullName;
            }
            Check(dir);
        }
    }

    return maxDirName;
}


static void PrintFileDirEntries(DirectoryInfo directory)
{
    foreach (FileInfo file in directory.GetFiles())
    {
        Console.WriteLine(file.FullName);
    }

    foreach (DirectoryInfo subDir in directory.GetDirectories())
    {
        Console.WriteLine(subDir.FullName);
        PrintFileDirEntries(subDir);
    }
}


static void EmptyDirectoryNames(DirectoryInfo dir)
{
    try
    {
        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            if (subDir.GetFiles().Length == 0 && subDir.GetDirectories().Length == 0)
            {
                Console.WriteLine(subDir.FullName);
            }
            EmptyDirectoryNames(subDir);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

//try
//{
//    DirectoryInfo dir = new DirectoryInfo(@"..\..\..\basedir\dir0");
//    if (dir.Exists)
//    {
//        //a
//        int fileCount = dir.GetFiles().Length;
//        int dirCount = dir.GetDirectories().Length;
//        Console.WriteLine("Кол-во файлов: " + fileCount);
//        Console.WriteLine("Кол-во каталогов: " + dirCount);

//        //b
//        Console.WriteLine("\nПодкаталоги:");
//        foreach (DirectoryInfo s in dir.GetDirectories())
//        {
//            Console.WriteLine(s.Name);
//        }

//        //с
//        Console.WriteLine($"\nВсего файлов: {fileCount}");
//        Console.WriteLine($"Текстовых файлов (*.txt): {dir.GetFiles("*.txt").Length}");

//        //d
//        Console.WriteLine("\nПустые строки: ");
//        EmptyDirectoryNames(new DirectoryInfo(@"..\..\..\basedir"));

//        //e
//        Console.WriteLine("\nПолный абсолютный путь файла 'елки.txt' из директории basedir/dir0/:");
//        Console.WriteLine(Path.Combine(dir.FullName, "елки.txt"));

//        //f
//        DirectoryInfo basedir = new DirectoryInfo(@"..\..\..\basedir");
//        Console.WriteLine("\nИмена всех вложенных файлов и директорий в рассматриваемой иерархии:");
//        PrintFileDirEntries(basedir);

//        //g
//        Console.WriteLine("\nИмя директории с максимальным количеством файлов: " + GetMaxDirectory(basedir));

//        //h
//        Console.WriteLine($"\nПолное имя (абсолютный путь) файла или директории с самой глубокой вложенностью: {DeepestObject(basedir)} ");

//        //i
//        DriveInfo driveInfo = new DriveInfo(basedir.Root.FullName);
//        Console.WriteLine($"Свободное место на диске '{driveInfo.Name}': {driveInfo.AvailableFreeSpace} ");

//        //j
//        Console.WriteLine($"\nНайдено устройств хранения: {DriveInfo.GetDrives().Length}");
//        foreach (DriveInfo drive in DriveInfo.GetDrives())
//        {
//            Console.WriteLine($"Имя устройства: '{drive.Name}' ");
//        }

//    }
//    else
//    {
//        Console.WriteLine("Директории не существует.");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
