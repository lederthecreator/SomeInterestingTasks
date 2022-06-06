using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Task24;

var container = new WindsorContainer();
container.Register(Component
    .For<IIngredient>()
    .ImplementedBy<Sausage>());
var sausage = container
    .Resolve<IIngredient>();

sausage.Put();
sausage.Cook();
sausage.Eat();

container.Register(
    Component
    .For<ICompositionRoot>()
    .ImplementedBy<CompositionRoot>());
container.Register(Component
    .For<IConsoleWriter>()
    .ImplementedBy<ConsoleWriter>());
    
var root = container.Resolve<ICompositionRoot>();
root.LogMessage("some message");

