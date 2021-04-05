﻿using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для PageEnterCodeEmail.xaml
    /// </summary>
    public partial class PageEnterCodeEmail : Page
    {


        public PageEnterCodeEmail(NavigationService navigationService, Task<TimeSpan> timeSpan,string email)
        {
            InitializeComponent();
            this.DataContext = new PageEnterCodeViewModel(navigationService, timeSpan,email);
        }


    }
}
