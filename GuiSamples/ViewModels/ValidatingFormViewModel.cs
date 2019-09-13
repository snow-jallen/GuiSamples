using GuiSamples.Wpf.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;

namespace GuiSamples.Wpf.ViewModels
{
    public class ValidatingFormViewModel : BindableDataErrorInfoBase
    {
        public ValidatingFormViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            NavigateToMessaging = new DelegateCommand<string>((uri) =>
            {
                regionManager.RequestNavigate("ContentRegion", uri);
            });
            InterestRate = .039M;
            LoanAmount = 100000;
            TermInYears = 100;
        }
        private string title = "Validing Form ViewModel";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string userValue;
        public string UserValue
        {
            get { return userValue; }
            set
            {
                SetProperty(ref userValue, value);
                eventAggregator.GetEvent<UserMessageEvent>().Publish(userValue);
            }
        }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public DelegateCommand<string> NavigateToMessaging { get; }

        private void calculatePayment()
        {
            MonthlyPayment = InterestRate * LoanAmount * TermInYears;
        }


        private decimal interestRate;
        public decimal InterestRate
        {
            get { return interestRate; }
            set
            {
                if (value < 0)
                    InterestRateError = "Interest rate must be >= 0";
                else
                    InterestRateError = null;
                SetProperty(ref interestRate, value);
                calculatePayment();
            }
        }
        private decimal loanAmount;
        public decimal LoanAmount
        {
            get { return loanAmount; }
            set
            {

                if (value < 0)
                    LoanAmountError = "Loan Amount must be >= 0";
                else
                    LoanAmountError = null;
                SetProperty(ref loanAmount, value);
                calculatePayment();
            }
        }
        
        private int termInYears;
        public int TermInYears
        {
            get { return termInYears; }
            set
            {
                SetProperty(ref termInYears, value);
                calculatePayment();
            }
        }
        private decimal monthlyPayment;
        public decimal MonthlyPayment
        {
            get { return monthlyPayment; }
            set { SetProperty(ref monthlyPayment, value); }
        }

        private string interestRateError;
        public string InterestRateError
        {
            get { return interestRateError; }
            set
            {
                SetProperty(ref interestRateError, value);
                ErrorDictionary[nameof(InterestRate)] = value;
                InterestRateErrorVisibility = value.IsNullOrWhiteSpace() ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private string loanAmountError;
        public string LoanAmountError
        {
            get { return loanAmountError; }
            set { SetProperty(ref loanAmountError, value);
                ErrorDictionary[nameof(LoanAmount)] = value;
                LoanAmountErrorVisibility = value.IsNullOrWhiteSpace() ? Visibility.Collapsed : Visibility.Visible;
                }
        }
        private Visibility interestRateErrorVisibility;
        public Visibility InterestRateErrorVisibility
        {
            get { return interestRateErrorVisibility; }
            set { SetProperty(ref interestRateErrorVisibility, value); }
        }

        private Visibility loanAmountErrorVisibility;
        public Visibility LoanAmountErrorVisibility
        {
            get { return loanAmountErrorVisibility; }
            set { SetProperty(ref loanAmountErrorVisibility, value); }
        }
    }

    public static class DemoExtensionMethods
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }
    }
}
