using JustDoIt.Data;
using JustDoIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustDoIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SortingPage : ContentPage
    {
        private ListView listView;

        public SortingPage(ListView listView)
        {
            InitializeComponent();

            this.listView = listView;
        }

        private async void OnSwitchSorting_Toggled(object sender, ToggledEventArgs e)
        {
            ToDoNoteDatabase database = await ToDoNoteDatabase.Instance;

            List<ToDoNote> notes = await database.GetItemsByCriteriaAsync();

            if (SwitchByPriority.IsToggled && SwitchByDeadlineDate.IsToggled)
            {
               listView.ItemsSource = notes.OrderBy(note => note.Priority).ThenBy(note => note.DeadlineDateTime);
            }
            else
            if (SwitchByPriority.IsToggled && !SwitchByDeadlineDate.IsToggled)
            {
                listView.ItemsSource = notes.OrderBy(note => note.Priority).ThenByDescending(note => note.DeadlineDateTime);
            }
            else
            if (!SwitchByPriority.IsToggled && SwitchByDeadlineDate.IsToggled)
            {
                listView.ItemsSource = notes.OrderByDescending(note => note.Priority).ThenBy(note => note.DeadlineDateTime);
            }
            else
            if (!SwitchByPriority.IsToggled && !SwitchByDeadlineDate.IsToggled)
            {
                listView.ItemsSource = notes.OrderByDescending(note => note.Priority).ThenByDescending(note => note.DeadlineDateTime);
            }
        }

        private void OnButtonResetFilter4(object sender, EventArgs e)
        {
            MessagingCenter.Send<SortingPage>(this, "SortingPage");
        }

        private void OnFindButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}