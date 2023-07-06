using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeletableCollection
{
    public class DeletableCollectionViewModel : BaseWindowViewModel
    {
        public ICommand DeleteCommand { get; set; }
        //private string selectedFilterText { get; set; }

        //public string SelectedFilterText
        //{
        //    get
        //    {
        //        return selectedFilterText;
        //    }
        //    set
        //    {
        //        if (filterText != value && value != null)
        //        {
        //            selectedFilterText = value;
        //            FilterText = selectedFilterText;
        //            OnPropertyChange(nameof(FilterText));
        //        }
        //    }
        //}


        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                OnPropertyChange(nameof(DeletableCollectionList));
                FilterList();
            }
        }

        private string filterText;

        public ObservableCollection<string> DeletableCollectionList { get; set; }

        private ObservableCollection<object> deletableCollectionList { get; set; }

        public ObservableCollection<object> DeletableObjectCollectionList
        {
            get
            {
                return deletableObjectCollectionList;
            }
            set
            {
                deletableObjectCollectionList = value;
            }
        }

        private ObservableCollection<object> deletableObjectCollectionList { get; set; }


        public void FilterList()
        {
            DeletableObjectCollectionList = new ObservableCollection<object>();
            foreach (var item in deletableCollectionList)
            {
                if (ValidateSearch(item))
                {
                    AddSelectedItem(item, this);
                    //DeletableCollectionList.Add(DisplayList(item));
                }
            }
           OnPropertyChange(nameof(DeletableObjectCollectionList));
        }

        protected virtual void AddSelectedItem(object item,DeletableCollectionViewModel viewModel)
        {
            DeletableObjectCollectionList.Add(item);
        }

        //protected virtual bool ValidateSelectedItem(object item)
        //{
        //    return SelectedFilterText == item.ToString();
        //}

        //protected virtual string DisplayList(object item)
        //{
        //    return item.ToString();
        //}

        protected virtual bool ValidateSearch(object item)
        {
            return item?.ToString().ToLower().Contains(FilterText?.ToLower() ?? "") ?? false;
        }


        public void DeleteCommandAction(object item)
        {

            DeletableObjectCollectionList.Remove(item);

            OnPropertyChange(nameof(DeletableObjectCollectionList));
        }

        public DeletableCollectionViewModel(ObservableCollection<object> Editable)
        {
            deletableCollectionList = new ObservableCollection<object>(Editable);
            FilterList();
        }
    }
}
