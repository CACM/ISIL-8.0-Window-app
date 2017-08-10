using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cacm.Isils
{
    /// <summary>
    /// Toggle button attached property to toggle button to change the oncheckedBackground
    /// </summary>
    /// <seealso cref="Cacm.Isils.BaseAttachedProperty{Cacm.Isils.ToggleOnCheckedBackgroundAttachedProperties, System.Windows.Media.SolidColorBrush}" />
    class ToggleOnCheckedBackgroundAttachedProperties : BaseAttachedProperty<ToggleOnCheckedBackgroundAttachedProperties, SolidColorBrush> {  }
    /// <summary>
    /// toogle button text color or foreground color change while checked.
    /// </summary>
    /// <seealso cref="Cacm.Isils.BaseAttachedProperty{Cacm.Isils.ToggleOnCheckedTextColorAttachedProperties, System.Windows.Media.SolidColorBrush}" />
    class ToggleOnCheckedTextColorAttachedProperties : BaseAttachedProperty<ToggleOnCheckedTextColorAttachedProperties, SolidColorBrush> { }

    /// <summary>
    /// Toogle button checked content or text change
    /// </summary>
    /// <seealso cref="Cacm.Isils.BaseAttachedProperty{Cacm.Isils.ToggleOnCheckedContentAttachedProperties, System.String}" />
    class ToggleOnCheckedContentAttachedProperties : BaseAttachedProperty<ToggleOnCheckedContentAttachedProperties, string> { }
    /// <summary>
    /// Toggle button icon chnage on checked
    /// </summary>
    /// <seealso cref="Cacm.Isils.BaseAttachedProperty{Cacm.Isils.ToggleOnCheckedContentAttachedProperties, System.String}" />
    class ToggleOnCheckedIconAttachedProperties : BaseAttachedProperty<ToggleOnCheckedIconAttachedProperties, string> { }
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
