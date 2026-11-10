using System;
using Microsoft.Extensions.DependencyInjection;
using WestCoast_Education;
using Westcoast_Education_Avalonia.Enums;
using Westcoast_Education_Avalonia.Factories;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;
using Westcoast_Education_Avalonia.Services;
using Westcoast_Education_Avalonia.ViewModels;

namespace Westcoast_Education_Avalonia.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<IPageViewFactory, PageViewFactory>();

        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CoursesViewModel>();
        collection.AddTransient<StudentsViewModel>();
        collection.AddTransient<AddStudentViewModel>();
        collection.AddTransient<AddCourseViewModel>();

        collection.AddTransient<IStorage<Student>, JsonStorageServices<Student>>();
        collection.AddTransient<IStorage<Course>, JsonStorageServices<Course>>();
        collection.AddTransient<IStudentService, StudentServices>();
        collection.AddTransient<ICourseService, CourseServices>();

        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => page => page switch
        {
            PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewsEnum.Courses => c.GetRequiredService<CoursesViewModel>(),
            PageViewsEnum.Students => c.GetRequiredService<StudentsViewModel>(),
            PageViewsEnum.AddStudent => c.GetRequiredService<AddStudentViewModel>(),
            PageViewsEnum.AddCourse => c.GetRequiredService<AddCourseViewModel>(),
            _ => throw new InvalidOperationException()
        });
        
        collection.AddSingleton<Func<PageViewsEnum, string, ViewModelBase>>(c =>(page, courseNumber) => page switch
        {
            PageViewsEnum.EditCourse => new EditCourseViewModel(new CourseServices(), courseNumber),
            _ => throw new InvalidOperationException()
        });
    }
}

internal class EditCourseViewModel : ViewModelBase
{
    private CourseServices courseServices;
    private string courseNumber;

    public EditCourseViewModel(CourseServices courseServices, string courseNumber)
    {
        this.courseServices = courseServices;
        this.courseNumber = courseNumber;
    }
}