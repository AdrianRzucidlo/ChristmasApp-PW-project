using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rzucidlo.ChristmasApp.Core.DTO.Children;
using Rzucidlo.ChristmasApp.Core.Enums;
using Rzucidlo.ChristmasApp.Core.Interfaces;
using Rzucidlo.ChristmasApp.UI.MVVM.Views;
using Rzucidlo.ChristmasApp.UI.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Rzucidlo.ChristmasApp.UI.MVVM.ViewModels;

public partial class CreateChildrenViewModel : ObservableObject
{
    private readonly IDataRepository _dataRepository;

    public CreateChildrenViewModel(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
        _createChildrenDto = new CreateChildrenDto();
    }

    [ObservableProperty]
    private ObservableCollection<string> _childrenBehaviourType = new([.. Enum.GetNames(typeof(ChildrenBehaviourType))]);

    [ObservableProperty]
    private string _selectedBehaviour = "Rude";

    [ObservableProperty]
    private CreateChildrenDto _createChildrenDto;

    [RelayCommand]
    private async Task SaveChildren()
    {
        if (CreateChildrenDto is not null && SelectedBehaviour is not null)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(CreateChildrenDto, null, null);

            var isValid = Validator.TryValidateObject(CreateChildrenDto, validationContext, validationResults, true);

            if (!isValid)
            {
                await ToastFactory.CreateToast(validationResults.First().ErrorMessage!);
            }
            else
            {
                var childrenToCreate = new CreateChildrenDto { Name = CreateChildrenDto.Name, Age = CreateChildrenDto.Age, Address = CreateChildrenDto.Address, ChildrenBehaviourType = (ChildrenBehaviourType)Enum.Parse(typeof(ChildrenBehaviourType), SelectedBehaviour) };
                var result = await _dataRepository.CreateChildren(childrenToCreate);

                await ToastFactory.CreateToast("Data Saved");

                await AppShell.Current.GoToAsync(nameof(ListChildrenView));
            }
        }
    }
}