using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace Validation_ByINotifyDataErrorInfo
{
    public class ValidationModel : ValidateAsyncModelBase
    {
        private string _username = nameof(Username);

        private string password = nameof(Password);

        private string reportPassword = nameof(ReportPassword);

        [Required(ErrorMessage = "Must not be empty.")]
        public string Password
        {
            get => password; set
            {
                OnPropertyChanged(ref _username, value);
            }
        }

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(60)]
        [CustomValidation(typeof(ValidationModel), nameof(SameEmailValidate))]
        public string ReportPassword
        {
            get => reportPassword;
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }

        [Required(ErrorMessage = "Must not be empty.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }

        public static ValidationResult? SameEmailValidate(object obj, ValidationContext context)
        {
            var user = (ValidationModel)context.ObjectInstance;
            if (user.Password != user.ReportPassword)
            {
                return new ValidationResult("The emails are not equal",
                    new List<string> { "Email", "RepeatEmail" });
            }
            return ValidationResult.Success;
        }
    }
}
