using Autofac;
using KennyMF.Droid.Services;
using KennyMF.Interface;

namespace Mobile.Droid
{
    public class DroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NativeNavigationService>().As<INativeNavigationService>().SingleInstance();
        }
    }
}