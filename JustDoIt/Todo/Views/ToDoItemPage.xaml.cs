using JustDoIt.Data;
using JustDoIt.Enums;
using JustDoIt.Extensions;
using JustDoIt.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace JustDoIt.Views
{
    public partial class ToDoItemPage : ContentPage
    {
        public ToDoItemPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ToDoNote todoItem = (ToDoNote)BindingContext;

            if (todoItem.DeadlineDateTime == null)
            {
                todoItem.DeadlineDateTime = DateTime.Today.AddDays(1);
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            ToDoNote todoItem = (ToDoNote)BindingContext;

            todoItem.CreationDateTime = (todoItem.CreationDateTime == null) ? DateTime.Now : todoItem.CreationDateTime;

            ToDoNoteDatabase database = await ToDoNoteDatabase.Instance;

            await database.SaveItemAsync(todoItem);

            await Navigation.PopAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Send<ToDoItemPage>(this, "ToDoItemPage");
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить элемент?", "Да", "Нет");

            if (!result) return;

            ToDoNote todoItem = (ToDoNote)BindingContext;

            ToDoNoteDatabase database = await ToDoNoteDatabase.Instance;

            await database.DeleteItemAsync(todoItem);

            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnPriorityChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            ToDoNote todoItem = (ToDoNote)BindingContext;

            todoItem.Priority = (Priority)picker.SelectedIndex;
        }


        private void HyperlinkLabel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                HyperlinkLabel hyperText = (HyperlinkLabel)sender;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {

            DateTime date = e.NewDate;

            string dateForUI;

            if (TranslateExtension.CultureInfo.Name == "ru-RU")
            {
                dateForUI = date.ToString("dd/MM/yy");
            }
            else
            {
                dateForUI = date.ToString("MM/dd/yyyy");
            }

            if (TranslateExtension.CultureInfo.Name == "ru-RU")
            {
                DeadlineDateLabel.Text = $"{Constants.ChosenMessageRu}: " + dateForUI;
            }
            else
            {
                DeadlineDateLabel.Text = $"{Constants.ChosenMessageEng}: " + dateForUI;
            }

        }

        private void OnDescriptionEditorFocused(object sender, FocusEventArgs e)
        {
            DescriptionEditor.HeightRequest = 150;
        }

        private void OnDescriptionEditorCompleted(object sender, EventArgs e)
        {
            DescriptionEditor.HeightRequest = 50;
        }

        void OnItalicCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                DescriptionEditor.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                DescriptionEditor.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        void OnBoldCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                DescriptionEditor.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                DescriptionEditor.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }
}
