using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletableCollection
{
    public class MainWindowViewModel
    {
        public DeletableCollectionViewModel DeletablePersonVM { get; set; }
        public MainWindowViewModel()
        {

            DeletablePersonVM = new DeletablePerson(new ObservableCollection<object>()
            {
                new Person { PersonID = 1, PersonName = "Shaam", PersonAge = 30},
                new Person { PersonID = 2, PersonName = "Baburao", PersonAge = 50},
                new Person { PersonID = 3, PersonName = "Raju", PersonAge = 32},
                new Person { PersonID = 4, PersonName = "Bunty", PersonAge = 26},
                new Person { PersonID = 5, PersonName = "Jones", PersonAge = 28},
                new Person { PersonID = 6, PersonName = "Mohan", PersonAge = 21},
                new Person { PersonID = 7, PersonName = "Sanjana", PersonAge = 19},
                new Person { PersonID = 8, PersonName = "Prakash", PersonAge = 19},
                new Person { PersonID = 9, PersonName = "Jayesh", PersonAge = 21},
                new Person { PersonID = 10, PersonName = "Kaushik", PersonAge = 40},
                new Person { PersonID = 11, PersonName = "Aman", PersonAge = 45},
            });
        }
    }
}
