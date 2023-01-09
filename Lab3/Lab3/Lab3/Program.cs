using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Lab3;

using (ApplicationContext db = new ApplicationContext())
{
    Scenarist scenarist1 = new Scenarist { Names = "Хуссейн Амини", Years = "1966" };
    Scenarist scenarist2 = new Scenarist { Names = "Майкл Грин", Years = "1943" };
    Scenarist scenarist3 = new Scenarist { Names = "Хэмптон Фанчер", Years = "1938" };
    db.Scenarists!.AddRange(scenarist1, scenarist2, scenarist3);
    Genre genre1 = new Genre { Title = "Драма" };
    Genre genre2 = new Genre { Title = "Фантастика" };
    Genre genre3 = new Genre { Title = "Триллер" };
    db.Genres!.AddRange(genre1, genre2, genre3);
    FType type1 = new FType { View = "Просмотрен" };
    FType type2 = new FType { View = "Буду смотреть" };
    db.Types!.AddRange(type1, type2);
    Film film1 = new Film { Name = "Драйв", Country = "США", Scenarist = scenarist1, Genre = genre3, Type = type1 };
    Film film2 = new Film { Name = "Бегущий по лезвию 2049", Country = "США", Scenarist = scenarist2, Genre = genre2, Type = type2 };
    db.Films.AddRange(film1, film2);
    db.SaveChanges();
    var Films = db.Films.ToList();
    Console.WriteLine("Список объектов:");
    foreach (Film u in Films)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
    }
}

Console.Write("\n1.Добавить");
Console.Write("\n2.Редактировать");
Console.Write("\n3.Удалить");
Console.Write("\n Выберите желаемый пункт: ");
string? Menu = Console.ReadLine();

if (Menu == "1")
{
    using (ApplicationContext db = new ApplicationContext())
    {
        Console.WriteLine("Введите название фильма: ");
        string? _namefilm = Console.ReadLine();
        Console.WriteLine("Введите страну: ");
        string? _country = Console.ReadLine();
        Console.WriteLine("Введите ФИО сценариста: ");
        string? _namescenarist = Console.ReadLine();
        Console.WriteLine("Введите год рождения сценариста: ");
        string? _years = Console.ReadLine();
        Scenarist scenarist = new Scenarist { Names = _namescenarist, Years = _years };
        db.Add(scenarist);
        Console.WriteLine("Введите жанр фильма: ");
        string? _namegenre = Console.ReadLine();
        Genre genre = new Genre { Title = _namegenre };
        db.Add(genre);
        Console.WriteLine("Введите статус фильма: ");
        string? _type = Console.ReadLine();
        FType type = new FType { View = _type };
        db.Add(type);
        Film films = new Film { Name = _namefilm, Country = _country, Scenarist = scenarist, Genre = genre, Type = type };
        db.Add(films);
        db.SaveChanges();
        Console.WriteLine("Данные успешно добавлены");
    }
}

if (Menu == "3")
{
    using (ApplicationContext db = new ApplicationContext())
    {
        Console.Write("Выберите запись для удаления: ");
        int numbers = Convert.ToInt32(Console.ReadLine());
        Film? film1 = db.Films.FirstOrDefault(x => x.Id == numbers);
        if (film1 != null)
        {
            db.Films.Remove(film1);
            db.SaveChanges();
        }
        Console.WriteLine("Данные после удаления");
        var films = db.Films.ToList();
        foreach (Film u in films)
        {
            Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
        }
    }

}

if (Menu == "2")
{
    using (ApplicationContext db = new ApplicationContext())
    {
        Console.WriteLine("Выберите запись для редактирования: ");
        int numbers = Convert.ToInt32(Console.ReadLine());
        Film? film = db.Films.Include(t => t.Type).Include(t => t.Scenarist).Include(t => t.Genre).FirstOrDefault(x => x.Id == numbers);
        if (film != null)
        {
            Console.WriteLine("Введите название фильма: ");
            film.Name = Console.ReadLine();
            Console.WriteLine("Введите страну: ");
            film.Country = Console.ReadLine();
            Console.WriteLine("Введите ФИО сценариста: ");
            film.Scenarist!.Names = Console.ReadLine()!;
            Console.WriteLine("Введите год рождения сценариста:");
            film.Scenarist.Years = Console.ReadLine();
            Console.WriteLine("Введите жанр фильма: ");
            film.Genre!.Title = Console.ReadLine()!;
            Console.WriteLine("Введите статус фильма: ");
            film.Type!.View = Console.ReadLine()!;
            db.SaveChanges();
        }
        Console.WriteLine("\nДанные после редактирования: ");
        var films = db.Films.ToList();
        foreach (Film u in films)
        {
            Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
        }
    }
}