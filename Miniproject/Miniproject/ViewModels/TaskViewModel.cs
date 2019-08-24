using Miniproject.Helper;
using Miniproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Miniproject.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {

        private List<Tasks> _listOfTasks;

        public List<Tasks> ListOfTasks
        {
            get { return _listOfTasks; }
            set
            {
                _listOfTasks = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel()
        {
            AllTasks();
            ListStatus();
        }

        protected async void AllTasks()
        {
            //Get All Tasks
            ListOfTasks = await App.SQLiteDb.GetItemsAsync();
        }

        private Tasks _task = new Tasks();

        public Tasks Tasks
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        public Command CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    _task.TaskId = await App.SQLiteDb.SaveItemAsync(_task);

                });
            }
        }

        public Command UpdateCommand // For UPDATE
        {
            get
            {
                return new Command(async () =>
                {
                    // instantiate to supply the new set of details
                    var TaskUpdate = new Tasks
                    {
                        TaskId = _task.TaskId,
                        Description = _task.Description,
                        status = _task.status
                    };

                    _task.TaskId = await App.SQLiteDb.SaveItemAsync(_task);
                });
            }
        }

        public Command RemoveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    // get the details with specific id
                    await App.SQLiteDb.DeleteItemAsync(_task);
                  
                });
            }
        }

        public List<string> StatusList = new List<string>();

        private void ListStatus()
        {
            
            StatusList.Add("Inactive");
            StatusList.Add("In Progress");
            StatusList.Add("Completed");
 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
