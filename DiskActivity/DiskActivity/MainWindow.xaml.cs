using DiskActivity.Interfaces;
using DiskActivity.Services;
using System.Windows;

namespace DiskActivity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DiskActivityService _activityService;

        public MainWindow()
        {
            InitializeComponent();

            _activityService = new DiskActivityService(new DiskContentQueryService());
            _activityService.RegisterObserver(Observer);
        }

        private void Observer(DisckActivityEvent eventArgs)
        {

        }
    }
}
