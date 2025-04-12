using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProgressTracker.Models;

namespace ProgressTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Exercise> allExercises = new();
        public MainWindow()
        {
            InitializeComponent();
            LoadSavedExercises();
            //FillExercises();
        }

        private void LoadSavedExercises()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "combined_exercises.json");
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                var savedExercises = JsonSerializer.Deserialize<List<Exercise>>(jsonString);

                if (savedExercises != null)
                {
                    allExercises.AddRange(savedExercises);
                }
                exerciseListBox.ItemsSource = allExercises;
            }
        }

        private void FillExercises()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    var json = File.ReadAllText(file);
                    var exercises = JsonSerializer.Deserialize<List<Exercise>>(json);
                    if (exercises != null)
                    {
                        allExercises.AddRange(exercises);
                    }
                }
            }
            exerciseListBox.ItemsSource = null;
            exerciseListBox.ItemsSource = allExercises;
        }

        private void SaveAllExercises()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(documentsPath, "combined_exercises.json");

            string json = JsonSerializer.Serialize(allExercises, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

            MessageBox.Show("Saved Exercises");
        }

        private void exerciseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exerciseListBox.SelectedItem is Exercise selectedExercise)
            {
                repsAndSetsListBox.ItemsSource = null;
                List<object> combinedItems = new();
                combinedItems.Add(selectedExercise.DateTime.ToString("yyyy-MM-dd HH:mm:ss") ?? "No Date");
                combinedItems.AddRange(selectedExercise.Sets);

                repsAndSetsListBox.ItemsSource = combinedItems;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveAllExercises();
        }
    }
}