using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class AddTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string SocialSecurityNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Street { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PostalCode { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string City { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string KnowledgeArea { get; set; } = string.Empty;

    public AddTeacherViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        PageTitle = "Add teacher";
    }

    [RelayCommand]
    private async Task Save()
    {
        Teacher teacher = new()
        {
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            SocialSecurityNumber = SocialSecurityNumber,
            Address = new Address
            {
                Street = Street,
                PostalCode = PostalCode,
                City = City
            },
            KnowledgeArea = KnowledgeArea
        };

        await _teacherService.Add(teacher);
        ClearData();
    }

    private void ClearData()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        SocialSecurityNumber = string.Empty;
        Street = string.Empty;
        PostalCode = string.Empty;
        City = string.Empty;
        KnowledgeArea = string.Empty;
    }
}