using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditableDeletableCollection
{
    public class EditableDeletablePerson : EditableDeletableCollectionViewModel
    {

        public EditableDeletablePerson(ObservableCollection<object> Persons) : base(Persons)
        {
        }

        protected override string DisplayList(object item)
        {
            Person person = (Person)item;
            return person.PersonName;
        }


        protected override void AddSelectedItem(object item, EditableDeletableCollectionViewModel viewModel)
        {
            Person person = (Person)item;
            person.viewModel = viewModel;

            Person CopyPerson = new Person()
            {
                PersonID = person.PersonID,
                PersonAge = person.PersonAge,
                PersonName = person.PersonName,
                viewModel = viewModel
            };

            EditableDeletableObjectCollectionList.Add(CopyPerson);
        }

        protected override bool ValidateSearch(object item)
        {
            Person person = (Person)item;
            return person?.PersonName.ToLower().Contains(FilterText?.ToLower() ?? "") ?? false;
        }
    }
}
