using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeletableCollection
{
    public class Person
    {
        public DeletableCollectionViewModel viewModel { get;set; }
        public Person Item
        {
            get
            {
                return this;
            }
        }

        public ICommand DeleteButton { get; set; }

        public Person()
        {
            DeleteButton = new RelayCommand(DeletePersonCommand);
        }

        public void DeletePersonCommand()
        {
            Person p = Item;
            viewModel.DeleteCommandAction(p);
        }


        public int PersonID { get; set; }

        public string PersonName{ get; set; }

        public int PersonAge { get; set; }

    }
}
