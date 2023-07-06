using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditableDeletableCollection
{
    public class Person
    {
        public EditableDeletableCollectionViewModel viewModel { get; set; }
        public Person Item
        {
            get
            {
                return this;
            }
        }

        public ICommand DeleteButton { get; set; }
        public ICommand UpdateButton { get; set; }


        public Person()
        {
            DeleteButton = new RelayCommand(DeletePersonCommand);
            UpdateButton = new RelayCommand(UpdatePersonCommand);
        }

        public void DeletePersonCommand()
        {
            Person p = Item;
            viewModel.DeleteCommandAction(p);
        }

        public void UpdatePersonCommand()
        {
            Person p = Item;
            viewModel.UpdateCommandAction(p);
        }


        public int PersonID { get; set; }

        public string PersonName { get; set; }

        public int PersonAge { get; set; }

    }
}
