using Xamarin.Essentials;
using Xamarin.Forms;

namespace JustDoIt
{
    public class HyperlinkLabel : Label
    {
        public static readonly BindableProperty UrlProperty = BindableProperty.Create
            (nameof(Url), typeof(string), typeof(HyperlinkLabel), "");

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public HyperlinkLabel()
        {
            TextDecorations = TextDecorations.Underline;

            TextColor = Color.Blue;

            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Launcher.TryOpenAsync(Url))
            });
        }
    }
}
