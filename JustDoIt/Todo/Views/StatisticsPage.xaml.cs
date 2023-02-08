using JustDoIt.Data;
using JustDoIt.Extensions;
using JustDoIt.Models;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.ChartEntry;

namespace JustDoIt.Views
{
    public partial class StatisticsPage : ContentPage
    {
        private const string pickerHeaderRu = "Выбрать график";

        private const string pickerHeaderEng = "Select a statistic";

        private const string firstPickerOptionRu = "Статистика заданий в процессе";

        private const string secondPickerOptionRu = "Статистика избранных заданий";

        private const string firstPickerOptionEng = "Statistics of tasks in process";

        private const string secondPickerOptionEng = "Statistics of highlighted tasks";

        private ToDoNoteDatabase database;

        private int last = 0;

        List<Entry> entries = new List<Entry>()
        {
            new Entry(600)
            {
                Color = SKColor.Parse("#00BFFF"),
            },
            new Entry(200)
            {
                Color = SKColor.Parse("#A0BFFF"),
            },
            new Entry(150)
            {
                Color = SKColor.Parse("#ABCDFF"),
            },
        };

        public StatisticsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            InitializeDatabase();

            

            if (TranslateExtension.CultureInfo.Name == "ru-RU")
            {
                picker.ItemsSource = new List<string>()
                {
                    firstPickerOptionRu,

                    secondPickerOptionRu,
                };

                picker.Title = pickerHeaderRu;
            }
            else
            {
                picker.ItemsSource = new List<string>()
                {
                    firstPickerOptionEng,

                    secondPickerOptionEng,
                };

                picker.Title = pickerHeaderEng;
            }

            List<ToDoNote> toDoNotes = await database.GetItemsAsync();

            tasksToBeDone.Chart = new BarChart() { Entries = await GetToDoEntriesAsync(toDoNotes), LabelTextSize = 36, ValueLabelOrientation = Orientation.Horizontal, LabelOrientation = Orientation.Horizontal, };
            
            tasksMarkedWithTheHeart.Chart = new DonutChart() { Entries = await GetMarkedWithHeartEntriesAsync(toDoNotes), LabelTextSize = 36, };
        }

        public async void InitializeDatabase()
        {
            database = await ToDoNoteDatabase.Instance;
        }

        public List<Entry> GetDoneEntries()
        {
            return null;
        }

        public async Task<List<Entry>> GetMarkedWithHeartEntriesAsync(List<ToDoNote> toDoNotes)
        {
            List<Entry> entries = new List<Entry>();

            var selectedHighPriorityItems = from p in toDoNotes
                                            where (p.IsFavourite == true && p.Priority == Enums.Priority.High)
                                            select p;

            var selectedMediumPriorityItems = from p in toDoNotes
                                              where (p.IsFavourite == true && p.Priority == Enums.Priority.Medium)
                                              select p;

            var selectedLowPriorityItems = from p in toDoNotes
                                           where (p.IsFavourite == true && p.Priority == Enums.Priority.Low)
                                           select p;

            entries.Add(new Entry(selectedHighPriorityItems.Count()) { Color = SKColor.Parse("#e26d00"), ValueLabel = $"{selectedHighPriorityItems.Count()}", Label = "High", TextColor = SKColor.Parse("#e26d00") });
            entries.Add(new Entry(selectedMediumPriorityItems.Count()) { Color = SKColor.Parse("#ffdb5a"), ValueLabel = $"{selectedMediumPriorityItems.Count()}", Label = "Medium", TextColor = SKColor.Parse("#ffdb5a") });
            entries.Add(new Entry(selectedLowPriorityItems.Count()) { Color = SKColor.Parse("#1dde7d"), ValueLabel = $"{selectedLowPriorityItems.Count()}", Label = "Low", TextColor = SKColor.Parse("#1dde7d") });

            return entries;
        }

        public async Task<List<Entry>> GetToDoEntriesAsync(List<ToDoNote> toDoNotes)
        {
            List<Entry> entries = new List<Entry>();

            var selectedHighPriorityItems = from p in toDoNotes
                                            where (p.Done == false && p.Priority == Enums.Priority.High) 
                                            select p;

            var selectedMediumPriorityItems = from p in toDoNotes
                                              where (p.Done == false && p.Priority == Enums.Priority.Medium)
                                              select p;

            var selectedLowPriorityItems = from p in toDoNotes
                                           where (p.Done == false && p.Priority == Enums.Priority.Low)
                                            select p;

            entries.Add(new Entry(selectedHighPriorityItems.Count()) { Color = SKColor.Parse("#e26d00"), ValueLabel = $"{selectedHighPriorityItems.Count()}", Label = "High", TextColor = SKColor.Parse("#e26d00") });
            entries.Add(new Entry(selectedMediumPriorityItems.Count()) { Color = SKColor.Parse("#ffdb5a"), ValueLabel = $"{selectedMediumPriorityItems.Count()}", Label = "Medium", TextColor = SKColor.Parse("#ffdb5a") });
            entries.Add(new Entry(selectedLowPriorityItems.Count()) { Color = SKColor.Parse("#1dde7d"), ValueLabel = $"{selectedLowPriorityItems.Count()}", Label = "Low", TextColor = SKColor.Parse("#1dde7d") });

            return entries;
        }

        private void picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker picker = (Picker)sender;

            int selectedOption = picker.SelectedIndex;

            if (selectedOption != -1)
            {
                if (selectedOption == 0)
                {
                    firstFrame.IsVisible = true;

                    secondFrame.IsVisible = false;

                    last = 1;
                }
                else
                {
                    firstFrame.IsVisible = false;

                    secondFrame.IsVisible = true;

                    last = 2;
                }
            }
            else
            {
                if (last == 1)
                {
                    firstFrame.IsVisible = true;

                    secondFrame.IsVisible = false;
                }
                else if (last == 2)
                {
                    secondFrame.IsVisible = true;

                    firstFrame.IsVisible = false;
                }
            }
        }
    }
}
