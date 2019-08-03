using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ReclutaCV.Base.Behaviours
{
    /// <summary>
    /// Atached Behaviour que permite que los elementos de control que heredan de Control puedan ejecutar un comando adjunto al dar doble clic sobre ellos o al pulsar Enter
    /// Puede soportar los tipos TreeView
    /// </summary>
    public static class ItemActivationBehaviour
    {
        /// <summary>
        /// Propiedad que guarda el comando adjunto al elemento
        /// </summary>
        public static readonly DependencyProperty CommandProperty
            = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ItemActivationBehaviour), new PropertyMetadata(null, CommandChanged));

        /// <summary>
        /// Get para obtener el valor de la propiedad CommandProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        /// <summary>
        /// Set para obtener el valor de la propiedad CommandProperty
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Método que se ejecutará cuando se cambie el valor de este attached behaviour en algún elemento de WPF
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Se toma el elemento d como Control porque esta clase es la más alta en la jerarquia de controles WPF que declara el evento "MouseDoubleClick" el cual necesitaremos
            var element = d as Control;

            if (element == null)
                return;

            //Se desuscriben los métodos Execute de los eventos para que no vayan a suscribirse más de una vez en algún momento
            element.MouseDoubleClick -= ExecuteFromMouseDoubleClick;
            element.PreviewKeyDown -= ExecuteFromEnterKey;

            //Si el nuevo valor del comando al cual se liga esta propiedad es diferente de null, se suscribe los método Execute, 
            //los cuales sirven como puente para la ejecución de "ExecuteAttachedCommand, a los eventos
            if (e.NewValue != null)
            {
                //Se suscriben los métodos Execute a los eventos correspondientes
                element.MouseDoubleClick += ExecuteFromMouseDoubleClick;
                element.PreviewKeyDown += ExecuteFromEnterKey;
            }
        }

        /// <summary>
        /// Método que verifica si la tecla presionada fue Enter, en ese caso ejecuta el comando indicado en la propieda CommandProperty
        /// </summary>
        /// <param name="sender">El elemento que disparo el evento</param>
        /// <param name="e">Objeto con la información de la tecla que se presionó</param>
        private static void ExecuteFromEnterKey(object sender, KeyEventArgs e)
        {
            if (IsExecutionPossible(sender))
            {
                //Se determina si fue la tecla Enter la que se presionó y si hay un elemento seleccionado
                if (e.Key == Key.Enter && IsExecutionPossible(sender))
                {
                    ExecuteAttachedCommand(sender);
                    //Se establece e.Handled en true para que ningún otro método adjunto al delegado se ejecute después de este
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Método que ejecuta ExecuteAttachedCommand cuando se da doble clic en el elemento donde se estableció la propiedad CommandProperty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ExecuteFromMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsExecutionPossible(sender))
            {
                ExecuteAttachedCommand(sender);
                //Se establece e.Handled en true para que ningún otro método adjunto al delegado se ejecute después de este
                e.Handled = true;
            }


        }

        /// <summary>
        /// Método que ejecuta el comando adjunto a la propiedad CommandProperty
        /// </summary>
        /// <param name="sender"></param>
        private static void ExecuteAttachedCommand(object sender)
        {
            var element = sender as Control;
            var command = (ICommand)element.GetValue(CommandProperty);
            command?.Execute(null);
        }

        /// <summary>
        /// Determina si el control es un tree view o un selector y si tiene un elemento seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True si el control tiene un elemento seleccionado</returns>
        private static bool IsExecutionPossible(object sender)
        {
            //Se determina el control que llamó al evento es un TreeView o un Selector (los tipos que están soportados al 13/10/2016),
            //si hay un elemento seleccionado, si no lo hay no se hace nada
            if ((sender as TreeView)?.SelectedItem != null ||
                    (sender as Selector)?.SelectedItem != null)
                return true;
            else
                return false;
        }
    }
}
