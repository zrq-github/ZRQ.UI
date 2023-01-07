﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZRQ.UI.UIModel
{
    public class ViewModelBase
        : INotifyPropertyChanged
        , INotifyDataErrorInfo
        , IDataErrorInfo
    {
        private readonly Dictionary<string, IList<string>> _validationErrors = new Dictionary<string, IList<string>>();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Error => string.Join(Environment.NewLine, GetAllErrors());

        public bool HasErrors => _validationErrors.Any();

        public string this[string propertyName]
        {
            get
            {
                if (string.IsNullOrEmpty(propertyName))
                    return Error;

                if (_validationErrors.ContainsKey(propertyName))
                    return string.Join(Environment.NewLine, _validationErrors[propertyName]);

                return string.Empty;
            }
        }

        public void AddValidationError(string propertyName, string errorMessage)
        {
            if (!_validationErrors.ContainsKey(propertyName))
                _validationErrors.Add(propertyName, new List<string>());

            _validationErrors[propertyName].Add(errorMessage);
            ErrorsChanged?.Invoke(this, new(propertyName));
        }

        public void ClearValidationErrors(string propertyName)
        {
            if (_validationErrors.ContainsKey(propertyName))
                _validationErrors.Remove(propertyName);
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _validationErrors.SelectMany(kvp => kvp.Value);

            return _validationErrors.TryGetValue(propertyName, out var errors) ? errors : Enumerable.Empty<object>();
        }

        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        private IEnumerable<string> GetAllErrors()
        {
            return _validationErrors.SelectMany(kvp => kvp.Value).Where(e => !string.IsNullOrEmpty(e));
        }
    }
}