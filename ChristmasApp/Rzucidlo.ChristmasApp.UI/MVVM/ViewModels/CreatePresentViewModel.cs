using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.DTO.Present;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using Rzucidlo.ChristmasApp.UI.Tools;
using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

[QueryProperty(nameof(GetChildrenDto), "Children")]
public partial class CreatePresentViewModel : ObservableObject
{
    private readonly IDataRepository _dataRepository;

    public CreatePresentViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
        _createPresentDto = new();
        _getChildrenDto = new();
    }

    [ObservableProperty]
    private GetChildrenDto _getChildrenDto;

    [ObservableProperty]
    private CreatePresentDto _createPresentDto;

    [RelayCommand]
    private async Task SavePresent()
    {
        if (GetChildrenDto is not null && CreatePresentDto is not null)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(CreatePresentDto, null, null);

            var isValid = Validator.TryValidateObject(CreatePresentDto, validationContext, validationResults, true);

            if (!isValid)
            {
                await ToastFactory.CreateToast(validationResults.First().ErrorMessage!);
            }
            else
            {
                var result = await _dataRepository.CreatePresent(CreatePresentDto, GetChildrenDto.Id);

                if (result)
                {
                    await ToastFactory.CreateToast("Data saved");

                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "Children", GetChildrenDto },
                    };
                    await Shell.Current.GoToAsync(nameof(ChildrenDetailsView), navigationParameter);
                }
                else
                {
                    await ToastFactory.CreateToast("An error occured");
                }
            }
        }
    }
}