using JustDoIt.Data;
using JustDoIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JustDoIt.Views
{
    public partial class ToDoListPage : ContentPage
    {
        private FilteringPage filteringPage;

        private SortingPage sortingPage;
        
        public ToDoListPage()
        {
            InitializeComponent();

            filteringPage = new FilteringPage();

            sortingPage = new SortingPage(listView);

            SubsribeToToDoItemPage();

            SubscribeToFilteringPage();

            SubscribeToSortingPagePage();

            UpdateListView();
        }

        private void SubsribeToToDoItemPage()
        {
            MessagingCenter.Subscribe<ToDoItemPage>(this,
                                      "ToDoItemPage",
                                      (sender) => { UpdateListView(); });
        }

        private void SubscribeToFilteringPage()
        {
            MessagingCenter.Subscribe<FilteringPage>(this,
                                                    "FilteringPage",
                                                    (sender) => { UpdateListView(); });
        }

        private void SubscribeToSortingPagePage()
        {
            MessagingCenter.Subscribe<SortingPage>(this,
                                                    "SortingPage",
                                                    (sender) => { UpdateListView(); });
        }

        private bool IsGoingToItemPagePossible()
        {
            return Navigation.NavigationStack.Last().GetType().Name != "ToDoItemPage";
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {

            if (IsGoingToItemPagePossible())
            {
                await Navigation.PushAsync(new ToDoItemPage
                {
                    BindingContext = new ToDoNote(),
                });
            }
        }

        async void OnListItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                if (IsGoingToItemPagePossible())
                {
                    await Navigation.PushAsync(new ToDoItemPage
                    {
                        BindingContext = e.Item as ToDoNote
                    });
                }
            }
        }
        private async void UpdateListView()
        {
            ToDoNoteDatabase database = await ToDoNoteDatabase.Instance;

            List<ToDoNote> toDoNotes = await database.GetItemsByCriteriaAsync();

            listView.ItemsSource = toDoNotes;

            listViewFrame.HeightRequest = 61 * (toDoNotes.Count);
        }

        private async void OnDoneCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            ViewCell viewCell = checkBox.Parent.Parent as ViewCell;

            ToDoNote toDoItem = (ToDoNote)viewCell.BindingContext;

            if (toDoItem == null)
            {
                return;
            }

            ToDoNoteDatabase database = await ToDoNoteDatabase.Instance;

            await database.SaveItemAsync(toDoItem);
        }

        private async void TapGestureRecognizerHeart_Tapped(object sender, EventArgs e)
        {
            ToDoNote toDoItem = ((sender as Image).Parent.Parent as ViewCell).BindingContext as ToDoNote;

            if (toDoItem == null)
            {
                return;
            }

            toDoItem.IsFavourite = !toDoItem.IsFavourite;

            ToDoNoteDatabase database = await ToDoNoteDatabase.Instance;

            Task<int> task = database.SaveItemAsync(toDoItem);

            UpdateListView();

            await task;
        }

        private bool IsGoingToModalPageIsPossible()
        {
            return Navigation.ModalStack.Count == 0;
        }

        private void TapGestureFiltration_Tapped(object sender, EventArgs e)
        {
            if (IsGoingToModalPageIsPossible())
            {
                Navigation.PushModalAsync(filteringPage);
            }
        }

        private void TapGestureRecognizerSorting_Tapped(object sender, EventArgs e)
        {
            if (IsGoingToModalPageIsPossible())
            {
                Navigation.PushModalAsync(sortingPage);
            }
        }

        private void TapGestureRecognizerAppSettings_Tapped(object sender, EventArgs e)
        {
            if (IsGoingToModalPageIsPossible())
            {
                Navigation.PushModalAsync(new SettingsPage());
            }
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell viewCell = sender as ViewCell;

            if (viewCell != null)
            {
                viewCell.View.BackgroundColor = Color.LightSlateGray;
            }
        }
    }
}
