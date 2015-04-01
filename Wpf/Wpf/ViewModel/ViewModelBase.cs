using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace Wpf.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            ClearError();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDesignTime
        {
            get
            {
                //return (Application.Current == null) || (Application.Current.GetType() == typeof(Application));
                return DesignerProperties.GetIsInDesignMode(new DependencyObject());
            }
        }


        private bool hasError;

        public bool HasError
        {
            get { return hasError; }
            private set
            {
                hasError = value;
                RaisePropertyChanged("HasError");
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            private set
            {
                errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        public void SetError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            HasError = true;
        }

        public void ClearError()
        {
            ErrorMessage = null;
            HasError = false;
        }
    }
}
