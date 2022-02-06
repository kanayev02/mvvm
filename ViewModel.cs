using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mvvm
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string RezultatChanged
        {
            get
            {
                return Model.rezultat.ToString();
            }
        }
        public List<string> combo
        {
            get
            {
                return Model.DataList;
            }
        }
        public static float PervoeChislo
        {
            set
            {
                Model.a = value;
            }
        }
        public static float VtoroeChislo
        {
            set
            {
                Model.b = value;
            }
        }
        public static int ComboIndex
        {
            set
            {
                Model.index = value;
            }
        }
        public RoutedCommand Command { get; set; } = new RoutedCommand();
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch (Model.index)
            {
                case 0:
                    Model.rezultat = Model.a * Model.b;
                    break;
                case 1:
                    Model.rezultat = Model.a + Model.b;
                    break;
                case 2:
                    Model.rezultat = Model.a / Model.b;
                    break;
                case 3:
                    Model.rezultat = Model.a - Model.b;
                    break;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("RezultatChanged"));
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
