namespace LoginApp
{
    using System.Windows;
    using Ninject;

    public partial class App : Application
    {
        public static IKernel Kernel { get; } = CreateKernel();

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<LoginViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<ContentViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<OrderViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<PurchacesViewModel>().ToSelf().InSingletonScope();
            return kernel;
        }
    }
}
