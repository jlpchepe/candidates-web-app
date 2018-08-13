using ReactiveUI;
using ReclutaCV.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReclutaCV.Controls
{
    public class EnumComboBox : System.Windows.Controls.ComboBox
    {
        static EnumComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumComboBox), new FrameworkPropertyMetadata(typeof(EnumComboBox)));
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.WhenAnyValue(p => p.SelectedValue)
                .Where(p => p != null)
                .Select(o => o.GetType())
                .Where(t => t.IsEnum)
                .DistinctUntilChanged()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(FillItems);
        }

        private void FillItems(Type enumType)
        {
            List<KeyValuePair<object, string>> values =
                EnumHelper.EnumToList(enumType)
                .Select(idx => new KeyValuePair<object, string>(idx.Item1, idx.Item2))
                .ToList();

            this.ItemsSource = 
                values
                .Select(o => o.Key.ToString())
                .ToList();

            UpdateLayout();
            this.ItemsSource = values;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";
        }
    }
}
