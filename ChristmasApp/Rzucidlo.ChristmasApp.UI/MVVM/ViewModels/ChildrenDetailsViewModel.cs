using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using Rzucidlo.ChristmasApp.UI.QueryObjects;
using Rzucidlo.ChristmasApp.UI.Tools;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

[QueryProperty(nameof(GetChildrenDto), "Children")]
public partial class ChildrenDetailsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
{
    [ObservableProperty]
    private GetChildrenDto _getChildrenDto;

    private readonly IDataRepository _dataRepository;

    public ObservableRangeCollection<GetPresentDto> Presents { get; set; } = [];

    public ChildrenDetailsViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
        _getChildrenDto = new();

        LoadPresents();
    }

    [RelayCommand]
    private async Task AddPresent()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Children", GetChildrenDto },
        };
        await Shell.Current.GoToAsync(nameof(CreatePresentView), navigationParameter);
    }

    [RelayCommand]
    private async Task GoHome()
    {
        await Shell.Current.GoToAsync(nameof(ListChildrenView));
    }

    [RelayCommand]
    private async Task DisplayActionSheet(GetPresentDto getPresentDto)
    {
        if (getPresentDto is null)
        {
            return;
        }

        var response = await Shell.Current.DisplayActionSheet("Select option", "Cancel", null, "Edit", "Delete");

        if (response == "Edit")
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Present", new UpdatePresentQueryParameter { PresentId = getPresentDto.Id, GetChildrenDto = GetChildrenDto, UpdatePresentDto = new UpdatePresentDto{ Name = getPresentDto.Name} } }
            };

            await Shell.Current.GoToAsync(nameof(UpdatePresentView), navigationParameter);
        }
        if (response == "Delete")
        {
            var deleteResponse = await Shell.Current.DisplayActionSheet("Are you sure?", "No", null, "Yes");

            if (deleteResponse == "Yes")
            {
                var result = await _dataRepository.DeletePresent(getPresentDto.Id, GetChildrenDto.Id);

                var toastResponse = result ? "Present Deleted!" : "An error occured";

                await ToastFactory.CreateToast(toastResponse);

                LoadPresents();
            }
        }
    }

    [RelayCommand]
    private void LoadPresents()
    {
        if (Presents.Count > 0)
        {
            Presents.Clear();
        }

        var children = _dataRepository.GetChildren(GetChildrenDto.Id);

        if (children is not null)
        {
            if (children.Presents.Any())
            {
                Presents.AddRange(children.Presents);
            }
        }
    }
}