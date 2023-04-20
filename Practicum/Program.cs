using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;

// начальные данные

internal class Program
{
    public static List<Person> users = new List<Person>();
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.UseInput();
        app.Run(async (context) =>
        {
            var response = context.Response;
            var request = context.Request;
            var path = request.Path;
            if (path == "/user" && request.Method == "POST")
            {
                response.ContentType = "text/plain; charset=utf-8";
                IFormFileCollection files = request.Form.Files;
                // путь к папке, где будут храниться файлы
                var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
                // создаем папку для хранения файлов
                Directory.CreateDirectory(uploadPath);

                foreach (var file in files)
                {
                    // путь к папке uploads
                    string fullPath = $"{uploadPath}/{file.FileName}";

                    // сохраняем файл в папку uploads
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                Console.WriteLine("Загрузка файлов завершена");
                await response.WriteAsync("<p>Файлы успешно загружены</p>");
            }
            else
            {
                response.ContentType = "text/html; charset=utf-8";
                await response.SendFileAsync("html/files.html");
            }
        });
        app.Run();
    }
}

public class InputMiddleware
{
    private readonly RequestDelegate next;

    public InputMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var response = context.Response;
        var request = context.Request;
        var path = request.Path;
        response.ContentType = "text/html; charset=utf-8";

        if (path == "/user")
        {
            var form = request.Form;
            //var b = request.Query;
            if (!Program.users.Contains(new Person { Name = form["login"], Password = form["password"] }))
                Program.users.Add(new Person { Name = form["login"], Password = form["password"] });
            await response.WriteAsync($"{form["login"]} - {form["password"]}");
            response.ContentType = "text/html; charset=utf-8";
            Console.WriteLine("страница пользователя");
            await next.Invoke(context);
        }
        else
        {
            response.ContentType = "text/html; charset=utf-8";
            await response.SendFileAsync("html/index.html");
        }
    }
}

public static class InputExtensions
{
    public static IApplicationBuilder UseInput(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<InputMiddleware>();
    }
}

public class Person
{
    
    public string Name { get; set; } = "";
    public string Password { get; set; } = "";
}


