using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;
    private readonly string _socialSecurityNumber;
    private string _teacherId = string.Empty;

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

    public EditTeacherViewModel(
        ITeacherService teacherService,
        string socialSecurityNumber)
    {
        _teacherService = teacherService;
        _socialSecurityNumber = socialSecurityNumber;
        PageTitle = "Edit teacher";

        LoadTeacher();
    }

    private async void LoadTeacher()
    {
        TeacherRestDb teacher =
            await _teacherService.Find(_socialSecurityNumber);

        _teacherId = teacher._id;
        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        PhoneNumber = teacher.PhoneNumber;
        SocialSecurityNumber = teacher.SocialSecurityNumber;
        Street = teacher.Address.Street;
        PostalCode = teacher.Address.PostalCode;
        City = teacher.Address.City;
        KnowledgeArea = teacher.KnowledgeArea;
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

        await _teacherService.Update(teacher, _teacherId);
    }
}