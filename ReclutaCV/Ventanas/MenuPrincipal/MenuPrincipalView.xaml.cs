﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReclutaCV.Ventanas.MenuPrincipal
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipalView.xaml
    /// </summary>
    public partial class MenuPrincipalView : Window
    {
        public MenuPrincipalView()
        {
            this.DataContext = new MenuPrincipalViewModel();
            InitializeComponent();
        }
    }
}
