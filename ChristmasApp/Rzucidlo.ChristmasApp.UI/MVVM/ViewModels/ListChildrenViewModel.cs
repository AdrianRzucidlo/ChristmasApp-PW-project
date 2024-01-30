using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.Enums;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using Rzucidlo.ChristmasApp.UI.QueryObjects;
using Rzucidlo.ChristmasApp.UI.Tools;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

public partial class ListChildrenViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
{
    private readonly IDataRepository _dataRepository;

    public ListChildrenViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;

        LoadChildrens();
    }

    public ObservableRangeCollection<GetChildrenDto> Childrens { get; set; } = [];

    [RelayCommand]
    private void LoadChildrens()
    {
        if (Childrens.Count > 0)
        {
            Childrens.Clear();
        }

        var childrens = _dataRepository.GetAllChildren();

        if (childrens.Count > 0)
        {
            Childrens.AddRange(childrens);
        }
    }

    [RelayCommand]
    private async Task AddChildren()
    {
        await AppShell.Current.GoToAsync(nameof(CreateChildrenView));
    }

    [RelayCommand]
    private async Task DisplayActionSheet(GetChildrenDto getChildrenDto)
    {
        if (getChildrenDto is null)
        {
            return;
        }

        var response = await Shell.Current.DisplayActionSheet("Select option", "Cancel", null, "Edit", "Delete", "View details");

        if (response == "Edit")
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Children", new UpdateChildrenQueryParameter { Id = getChildrenDto.Id, UpdateChildrenDto = new UpdateChildrenDto { Name = getChildrenDto.Name, Address = getChildrenDto.Address, Age = getChildrenDto.Age, ChildrenBehaviourType = (ChildrenBehaviourType)Enum.Parse(typeof(ChildrenBehaviourType),getChildrenDto.ChildrenBehaviour)  }} },
            };
            await Shell.Current.GoToAsync(nameof(UpdateChildrenView), navigationParameter);
        }
        if (response == "Delete")
        {
            var deleteResponse = await Shell.Current.DisplayActionSheet("Are you sure?", "No", null, "Yes");

            if (deleteResponse == "Yes")
            {
                var result = await _dataRepository.DeleteChildren(getChildrenDto.Id);

                var toastResponse = result ? "Children Deleted!" : "An error occured";

                await ToastFactory.CreateToast(toastResponse);

                LoadChildrens();
            }
        }

        if (response == "View details")
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Children", getChildrenDto },
            };
            await Shell.Current.GoToAsync(nameof(ChildrenDetailsView), navigationParameter);
        }
    }
}