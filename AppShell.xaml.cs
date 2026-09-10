namespace UI1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }

    // הפונקציה קיימת כדי שהקוד שהגיע עם התבנית יוכל להיבנות
    public static Task DisplayToastAsync(string message)
    {
        return Task.CompletedTask;
    }

    public static Task DisplaySnackbarAsync(string message)
    {
        return Task.CompletedTask;
    }
}