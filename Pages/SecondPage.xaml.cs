namespace UI1.Pages;

public partial class SecondPage : ContentPage
{
    private readonly Entry nameEntry = new Entry();
    private readonly Entry ageEntry = new Entry();
    private readonly Label resultLabel = new Label();
    private readonly VerticalStackLayout candlesLayout = new VerticalStackLayout();

    public SecondPage()
    {
        InitializeComponent();

        // יצירת ה-Grid הראשי
        Grid mainGrid = new Grid
        {
            Padding = 30
        };

        mainGrid.RowDefinitions.Add(new RowDefinition
        {
            Height = new GridLength(1, GridUnitType.Star)
        });

        mainGrid.RowDefinitions.Add(new RowDefinition
        {
            Height = GridLength.Auto
        });


        // אזור התוצאה
        VerticalStackLayout resultArea = new VerticalStackLayout
        {
            Spacing = 10
        };

        resultLabel.FontSize = 24;
        resultLabel.HorizontalOptions = LayoutOptions.Center;
        resultLabel.HorizontalTextAlignment = TextAlignment.Center;

        resultArea.Children.Add(resultLabel);

        candlesLayout.Spacing = 5;

        resultArea.Children.Add(candlesLayout);

        ScrollView scrollView = new ScrollView
        {
            Content = resultArea
        };

        mainGrid.Add(scrollView, 0, 0);


        // החלק התחתון
        VerticalStackLayout layoutFields = new VerticalStackLayout
        {
            Spacing = 10
        };


        // שם
        Label nameLabel = new Label
        {
            Text = "שם"
        };

        layoutFields.Children.Add(nameLabel);

        nameEntry.Placeholder = "הכנס שם";

        layoutFields.Children.Add(nameEntry);


        // גיל
        Label ageLabel = new Label
        {
            Text = "גיל"
        };

        layoutFields.Children.Add(ageLabel);

        ageEntry.Placeholder = "הכנס גיל";
        ageEntry.Keyboard = Keyboard.Numeric;

        layoutFields.Children.Add(ageEntry);


        // כפתור
        Button customButton = new Button
        {
            Text = "חשב"
        };

        customButton.Clicked += btnCalculateAge_Clicked;

        layoutFields.Children.Add(customButton);

        mainGrid.Add(layoutFields, 0, 1);

        Content = mainGrid;
    }


    private void btnCalculateAge_Clicked(object? sender, EventArgs e)
    {
        if (int.TryParse(ageEntry.Text, out int age))
        {
            int newAge = age + 10;

            resultLabel.Text =
                $"{nameEntry.Text}, בעוד 10 שנים הגיל שלך יהיה {newAge}";

            // מוחקים נרות מהחישוב הקודם
            candlesLayout.Children.Clear();


            // יוצרים שורות של עד 10 נרות
            for (int i = 0; i < newAge; i += 10)
            {
                HorizontalStackLayout row = new HorizontalStackLayout
                {
                    Spacing = 3,
                    HorizontalOptions = LayoutOptions.Center
                };

                int candlesInRow = Math.Min(10, newAge - i);

                for (int j = 0; j < candlesInRow; j++)
                {
                    Image candle = new Image
                    {
                        Source = "candle.png",
                        WidthRequest = 25,
                        HeightRequest = 55
                    };

                    row.Children.Add(candle);
                }

                candlesLayout.Children.Add(row);
            }
        }
        else
        {
            resultLabel.Text = "יש להכניס גיל תקין";
            candlesLayout.Children.Clear();
        }
    }
}