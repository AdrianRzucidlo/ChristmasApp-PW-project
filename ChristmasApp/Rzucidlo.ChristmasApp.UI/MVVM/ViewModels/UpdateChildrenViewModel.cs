using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.Enums;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using Rzucidlo.ChristmasApp.UI.QueryObjects;
using Rzucidlo.ChristmasApp.UI.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

[QueryProperty(nameof(UpdateChildrenQueryParameter), "Children")]
public partial class UpdateChildrenViewModel : ObservableObject
{
    private readonly IDataRepository _dataRepository;

    public UpdateChildrenViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
        _updateChildrenQueryParameter = new();
        _selectedBehaviour = UpdateChildrenQueryParameter.UpdateChildrenDto.ChildrenBehaviourType.ToString();
    }

    [ObservableProperty]
    private UpdateChildrenQueryParameter _updateChildrenQueryParameter;

    [ObservableProperty]
    private ObservableCollection<string> _childrenBehaviourType = new([.. Enum.GetNames(typeof(ChildrenBehaviourType))]);

    [ObservableProperty]
    private string _selectedBehaviour = "Rude";

    [RelayCommand]
    public async Task UpdateChildren()
    {
        if (UpdateChildrenQueryParameter is not null && SelectedBehaviour is not null)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(UpdateChildrenQueryParameter.UpdateChildrenDto, null, null);

            var isValid = Validator.TryValidateObject(UpdateChildrenQueryParameter.UpdateChildrenDto, validationContext, validationResults, true);

            if (!isValid)
            {
                await ToastFactory.CreateToast(validationResults.First().ErrorMessage!);
            }
            else
            {
                var childrenToUpdate = new UpdateChildrenDto { Name = UpdateChildrenQueryParameter.UpdateChildrenDto.Name, Age = UpdateChildrenQueryParameter.UpdateChildrenDto.Age, Address = UpdateChildrenQueryParameter.UpdateChildrenDto.Address, ChildrenBehaviourType = (ChildrenBehaviourType)Enum.Parse(typeof(ChildrenBehaviourType), SelectedBehaviour) };
                var result = await _dataRepository.UpdateChildren(childrenToUpdate, UpdateChildrenQueryParameter.Id);

                await ToastFactory.CreateToast("Updated");

                await AppShell.Current.GoToAsync(nameof(ListChildrenView));
            }
        }
    }
}