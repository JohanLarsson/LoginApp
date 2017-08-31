namespace LoginApp
{
    using System.Windows;
    using System.Windows.Controls;

    public class MainViewSelector : DataTemplateSelector
    {
        public DataTemplate LoginTemplate { get; set; }

        public DataTemplate ContentTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is LoginViewModel)
            {
                return this.LoginTemplate;
            }

            if (item is ContentViewModel)
            {
                return this.ContentTemplate;
            }

            // throwing is perhaps better here
            return base.SelectTemplate(item, container);
        }
    }
}