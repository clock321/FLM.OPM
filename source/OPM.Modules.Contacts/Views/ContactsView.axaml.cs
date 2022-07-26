using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace OPM.Modules.Contacts.Views
{
  public partial class ContactsView : UserControl
  {
    public ContactsView()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}