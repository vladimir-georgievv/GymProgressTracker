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
        public MainWindow()
        {
            InitializeComponent();
            FillExercises();
        }

        private void FillExercises()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string filePath = System.IO.Path.Combine(documentsPath, "exercises_output.json");
            string jsonString = File.ReadAllText(filePath);
            List<Exercise> exercises = JsonSerializer.Deserialize<List<Exercise>>(jsonString);
            exerciseListBox.ItemsSource = exercises;

        }

        private void exerciseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (exerciseListBox.SelectedItem is Exercise selectedExercise)
            {
                repsAndSetsListBox.ItemsSource = selectedExercise.Sets;
            }
        }
    }
}