using System;
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

}
