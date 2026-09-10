namespace UI1.Pages;

public partial class ThirdPage : ContentPage
{
    private Entry nameEntry;
    private Entry ageEntry;
    private Label resultLabel;
    private Label sliderValueLabel;
    private VerticalStackLayout candlesLayout;

    public ThirdPage()
    {
        InitializeComponent();

        // יצירת Grid ראשי
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


        // אזור התוצאה והנרות
        VerticalStackLayout resultArea = new VerticalStackLayout
        {
            Spacing = 10
        };

        resultLabel = new Label
        {
            FontSize = 24,
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center
        };

        resultArea.Children.Add(resultLabel);

        candlesLayout = new VerticalStackLayout
        {
            Spacing = 5
        };

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

        nameEntry = new Entry
        {
            Placeholder = "הכנס שם"
        };

        layoutFields.Children.Add(nameEntry);


        // גיל
        Label ageLabel = new Label
        {
            Text = "גיל"
        };

        layoutFields.Children.Add(ageLabel);

        ageEntry = new Entry
        {
            Placeholder = "הכנס גיל",
            Keyboard = Keyboard.Numeric,
            Text = "17"
        };

        layoutFields.Children.Add(ageEntry);


        // הצגת ערך ה-Slider
        sliderValueLabel = new Label
        {
            Text = "Slider: 17",
            HorizontalOptions = LayoutOptions.Center
        };

        layoutFields.Children.Add(sliderValueLabel);


        // יצירת Slider במקום הכפתור
        Slider ageSlider = new Slider
        {
            Minimum = 1,
            Maximum = 100,
            Value = 17
        };

        // Event של ה-Slider
        ageSlider.ValueChanged += ageSlider_ValueChanged;

        layoutFields.Children.Add(ageSlider);

        mainGrid.Add(layoutFields, 0, 1);

        Content = mainGrid;
    }


    private void ageSlider_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        // לוקחים את הערך של ה-Slider
        int age = (int)e.NewValue;

        ageEntry.Text = age.ToString();
        sliderValueLabel.Text = "Slider: " + age;

        int newAge = age + 10;

        resultLabel.Text =
            $"{nameEntry.Text}, בעוד 10 שנים הגיל שלך יהיה {newAge}";

        // מחיקת הנרות הקודמים
        candlesLayout.Children.Clear();


        // יצירת הנרות
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
}