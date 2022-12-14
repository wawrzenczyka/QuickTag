using Avalonia.Controls;
using Avalonia.Controls.Templates;
using QuickTag.ViewModels;
using System;

namespace QuickTag
{
    public class ViewLocator: IDataTemplate
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!;
            if (name.Contains("ViewModelDesign"))
            {
                name = name.Replace("ViewModelDesign", "View");
                name = name.Replace(".Design.", ".");
            }
            name = name.Replace("ViewModel", "View");

            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
