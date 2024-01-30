using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using Rzucidlo.ChristmasApp.UI.QueryObjects;
using Rzucidlo.ChristmasApp.UI.Tools;
using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

[QueryProperty(nameof(UpdatePresentQueryParameter), "Present")]
public partial class UpdatePresentViewModel : ObservableObject
{
    private readonly IDataRepository _dataRepository;

    public UpdatePresentViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
        _updatePresentQueryParameter = new();
    }

    [ObservableProperty]
    private UpdatePresentQueryParameter _updatePresentQueryParameter;

    [RelayCommand]
    public async Task UpdatePresent()
    {
        if (UpdatePresentQueryParameter is not null)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(UpdatePresentQueryParameter.UpdatePresentDto, null, null);

            var isValid = Validator.TryValidateObject(UpdatePresentQueryParameter.UpdatePresentDto, validationContext, validationResults, true);

            if (!isValid)
            {
                await ToastFactory.CreateToast(validationResults.First().ErrorMessage!);
            }
            else
            {
                var result = await _dataRepository.UpdatePresent(UpdatePresentQueryParameter.UpdatePresentDto, UpdatePresentQueryParameter.GetChildrenDto.Id, UpdatePresentQueryParameter.PresentId);

                if (result)
                {
                    await ToastFactory.CreateToast("Updated");

                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "Children", UpdatePresentQueryParameter.GetChildrenDto },
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