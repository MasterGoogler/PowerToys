﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows;
using System.Windows.Input;
using FancyZonesEditor.Models;
using FancyZonesEditor.Utils;

namespace FancyZonesEditor
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class GridEditorWindow : EditorWindow
    {
        public GridEditorWindow()
        {
            InitializeComponent();

            KeyUp += GridEditorWindow_KeyUp;

            _stashedModel = (GridLayoutModel)(App.Overlay.CurrentDataContext as GridLayoutModel).Clone();
        }

        protected new void OnCancel(object sender, RoutedEventArgs e)
        {
            base.OnCancel(sender, e);
            GridLayoutModel model = App.Overlay.CurrentDataContext as GridLayoutModel;
            _stashedModel.RestoreTo(model);
        }

        private void GridEditorWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                OnCancel(sender, null);
            }
        }

        private GridLayoutModel _stashedModel;

        private void NameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            customLayoutNameTextBox.CaretIndex = customLayoutNameTextBox.Text.Length;
        }

        public System.Windows.Controls.TextBox NameTextBox()
        {
            return customLayoutNameTextBox;
        }
    }
}
