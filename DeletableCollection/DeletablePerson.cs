using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeletableCollection
{
    public class DeletablePerson : DeletableCollectionViewModel
    {
        public DeletablePerson(ObservableCollection<object> Persons) : base(Persons)
        {
        }

        protected override void AddSelectedItem(object item, DeletableCollectionViewModel viewModel)
        {
            Person person = (Person)item;
            person.viewModel = viewModel;
            DeletableObjectCollectionList.Add(person);
        }



        protected override bool ValidateSearch(object item)
        {
            Person person = (Person)item;
            return person?.PersonName.ToLower().Contains(FilterText?.ToLower() ?? "") ?? false;
        }
    }
}
