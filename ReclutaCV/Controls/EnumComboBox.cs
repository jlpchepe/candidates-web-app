using ReactiveUI;
using ReclutaCVLogic.Utils.Extensions;
using ReclutaCVLogic.Utils.Helpers;
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
            List<KeyValuePair<Enum, string>> values =
                EnumHelper.ObtenerListadoDeValoresDeTipoEnum(enumType)
                .Select(x => new KeyValuePair<Enum, string>(x, x.GetDescription()))
                .ToList();

            UpdateLayout();
            this.ItemsSource = values;
            this.DisplayMemberPath = "Value";
            this.SelectedValuePath = "Key";
        }
    }
}
