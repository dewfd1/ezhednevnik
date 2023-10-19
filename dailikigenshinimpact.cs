using System;
using System.Collections.Generic;

public class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string AdditionalInfo { get; set; }
}

public class DailyPlanner
{
    private List<Note> notes;
    private int currentIndex;

    public DailyPlanner()
    {
        notes = new List<Note>
        {
            new Note
            {
                Title = "Заметка 1",
                Description = "Описание заметки 1",
                Date = new DateTime(2022, 10, 6),
                AdditionalInfo = "Дополнительная информация 1"
            },
            new Note
            {
                Title = "Заметка 2",
                Description = "Описание заметки 2",
                Date = new DateTime(2022, 10, 8),
                AdditionalInfo = "Дополнительная информация 2"
            },
            new Note
            {
                Title = "Заметка 3",
                Description = "Описание заметки 3",
                Date = new DateTime(2022, 10, 13),
                AdditionalInfo = "Дополнительная информация 3"
            },
        };

        currentIndex = 0;
    }

    public void Run()
    {
        Console.WriteLine("Ежедневник");

        while (true)
        {
            Console.Clear();
            PrintMenu();
            HandleInput();
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("Используйте стрелки влево и вправо для управления.");
        for (int i = 0; i < notes.Count; i++)
        {
            string title = notes[i].Title;

            if (i == currentIndex)
                title = $"> {title} <"; 

            Console.WriteLine(title);
        }
    }

    private void PrintNoteInfo(Note note)
    {
        Console.Clear();
        Console.WriteLine("Полная информация о заметке:");
        Console.WriteLine();
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для продолжения...");
        Console.ReadLine();
    }

    private void HandleInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            currentIndex = (currentIndex + 1) % notes.Count; 
        }
        else if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            currentIndex = (currentIndex + notes.Count - 1) % notes.Count; 
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            PrintNoteInfo(notes[currentIndex]); 
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DailyPlanner dailyPlanner = new DailyPlanner();
        dailyPlanner.Run();
    }
}