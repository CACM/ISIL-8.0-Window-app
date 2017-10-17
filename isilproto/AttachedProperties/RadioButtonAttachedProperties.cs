﻿using System.Windows;
using System.Windows.Controls;

namespace Cacm.Isils
{
    /// <summary>
    /// radio button checked uncheck toggle
    /// </summary>
    /// <seealso cref="System.Windows.Controls.RadioButton" />
    public class OptionalRadioButton : RadioButton
    {
        #region bool IsOptional dependency property
        public static DependencyProperty IsOptionalProperty =
            DependencyProperty.Register(
                "IsOptional",
                typeof(bool),
                typeof(OptionalRadioButton),
                new PropertyMetadata((bool)true,
                    (obj, args) =>
                    {
                        ((OptionalRadioButton)obj).OnIsOptionalChanged(args);
                    }));
        public bool IsOptional
        {
            get
            {
                return (bool)GetValue(IsOptionalProperty);
            }
            set
            {
                SetValue(IsOptionalProperty, value);
            }
        }
        private void OnIsOptionalChanged(DependencyPropertyChangedEventArgs args)
        {
            // TODO: Add event handler if needed
        }
        #endregion

        protected override void OnClick()
        {
            bool? wasChecked = this.IsChecked;
            base.OnClick();
            if (this.IsOptional && wasChecked == true)
                this.IsChecked = false;
        }
    }
}
