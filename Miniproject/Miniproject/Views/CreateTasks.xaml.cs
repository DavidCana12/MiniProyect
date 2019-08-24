using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Miniproject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateTasks : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public CreateTasks()
        {
            InitializeComponent();
 
        }
    }
}
