using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditableDeletableCollection
{
    public class EditableDeletableCollectionViewModel : BaseWindowViewModel
    {
        private string selectedFilterText { get; set; }

        public string SelectedFilterText
        {
            get
            {
                return selectedFilterText;
            }
            set
            {
                if (filterText != value && value != null)
                {
                    selectedFilterText = value;
                    FilterText = selectedFilterText;
                    OnPropertyChange(nameof(FilterText));
                }
            }
        }


        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                OnPropertyChange(nameof(EditableDeletableCollectionList));
                FilterList();
            }
        }

        private string filterText;

        public ObservableCollection<string> EditableDeletableCollectionList { get; set; }
        public ObservableCollection<object> EditableDeletableObjectCollectionList { get; set; }

        private ObservableCollection<object> editableDeletableCollectionList { get; set; }


        public void FilterList()
        {
            EditableDeletableCollectionList = new ObservableCollection<string>();
            EditableDeletableObjectCollectionList = new ObservableCollection<object>();
            foreach (var item in editableDeletableCollectionList)
            {
                if (ValidateSearch(item))
                {
                    EditableDeletableCollectionList.Add(DisplayList(item));
                    AddSelectedItem(item, this);
                }
            }

            OnPropertyChange(nameof(EditableDeletableObjectCollectionList));
            OnPropertyChange(nameof(EditableDeletableCollectionList));
        }

        protected virtual void AddSelectedItem(object item, EditableDeletableCollectionViewModel viewModel)
        {
            EditableDeletableObjectCollectionList.Add(item);
        }

        public void DeleteCommandAction(object item)
        {
            EditableDeletableObjectCollectionList.Remove(item);

            OnPropertyChange(nameof(EditableDeletableObjectCollectionList));
        }

        public void UpdateCommandAction(object item)
        {
            int i = EditableDeletableObjectCollectionList.IndexOf(item);
            editableDeletableCollectionList.RemoveAt(i);
            editableDeletableCollectionList.Insert(i, item);
            OnPropertyChange(nameof(editableDeletableCollectionList));
        }

        protected virtual string DisplayList(object item)
        {
            return item.ToString();
        }

        protected virtual bool ValidateSearch(object item)
        {
            return item?.ToString().ToLower().Contains(FilterText?.ToLower() ?? "") ?? false;
        }


        public EditableDeletableCollectionViewModel(ObservableCollection<object> Editable)
        {
            editableDeletableCollectionList = new ObservableCollection<object>(Editable);
            FilterList();
        }
    }
}
