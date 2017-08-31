namespace LoginApp
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Markup;
    using Ninject;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? (o => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

    [MarkupExtensionReturnType(typeof(object))]
    public class GetExtension : MarkupExtension
    {
        private static readonly DependencyObject DependencyObject = new DependencyObject();

        public GetExtension()
        {
        }

        public GetExtension(Type type)
            : this(type, false)
        {
        }

        public GetExtension(Type type, bool isDesignTimeCreatable)
        {
            this.Type = type;
            this.IsDesignTimeCreatable = isDesignTimeCreatable;
        }

        private static bool IsInDesignMode => DesignerProperties.GetIsInDesignMode(DependencyObject);

        [ConstructorArgument("type")]
        public Type Type { get; set; }

        [ConstructorArgument("isDesignTimeCreatable")]
        public bool IsDesignTimeCreatable { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Type == null)
            {
                return null;
            }

            if (IsInDesignMode)
            {
                if (this.IsDesignTimeCreatable)
                {
                    return App.Kernel.Get(this.Type);
                }

                return null;
            }

            return App.Kernel.Get(this.Type);
        }
    }
}