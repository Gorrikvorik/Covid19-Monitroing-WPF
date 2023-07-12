
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
 

namespace PR22.Components
{
    /// <summary>
    /// Логика взаимодействия для Gaugeindicator.xaml
    /// </summary>
    public partial class GaugeIndicator : UserControl
    {


        #region ValueProperty

        public static readonly DependencyProperty ValueProperty =
    DependencyProperty.Register(
        nameof(Value),
        typeof(double),
        typeof(GaugeIndicator),
        new PropertyMetadata(default(double),
            OnValuePropertyChanged,
            OnCoerceValue),
        OnValidateValue);

        private static bool OnValidateValue(object value) //Если ложь - не привязывается, истина - установка нового значения
        {
            return true;
        }

        private static object OnCoerceValue(DependencyObject d, object baseValue) //корректировка значения
        {
            var value = (double)baseValue;
            return Math.Max(0,Math.Min(100,value));
        }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var gaugeIndicator = (GaugeIndicator)d;
            //gaugeIndicator.ArrowRotator.Angle = (double)e.NewValue;
        }

        [Category("Моя категория")]
        [Description("Меняем угол стрелочки!")]
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);

        } 
        #endregion
        public GaugeIndicator()
        {
            InitializeComponent();
        }
    }
}
