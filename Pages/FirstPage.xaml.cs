namespace UI1.Pages;

public partial class FirstPage : ContentPage
{
    public FirstPage()
    {
        InitializeComponent();
    }

    private void btnCalculateAge_Clicked(object? sender, EventArgs e)
    {
        if (int.TryParse(ageEntry.Text, out int age))
        {
            int newAge = age + 10;

            resultLabel.Text =
                $"{nameEntry.Text}, בעוד 10 שנים הגיל שלך יהיה {newAge}";
        }
        else
        {
            resultLabel.Text = "יש להכניס גיל תקין";
        }
    }
}