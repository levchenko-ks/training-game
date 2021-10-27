public interface IServiceLocator
{
    IResourcesService ResourcesService { get; }
    IStateService StateService { get; }
    ISaveService SaveService { get; }    
}
