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
        collection.AddTransient<TeachersViewModel>();
        collection.AddTransient<AddStudentViewModel>();
        collection.AddTransient<AddCourseViewModel>();
        collection.AddTransient<AddTeacherViewModel>();

        collection.AddTransient<IStorage<Student>, JsonStorageServices<Student>>();
        collection.AddTransient<IStorage<Course>, JsonStorageServices<Course>>();
        collection.AddTransient<IStudentService, StudentServices>();
        collection.AddTransient<ICourseService, CourseServices>();
        collection.AddTransient<ITeacherService, TeacherServices>();

        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => page => page switch
        {
            PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewsEnum.Courses => c.GetRequiredService<CoursesViewModel>(),
            PageViewsEnum.Students => c.GetRequiredService<StudentsViewModel>(),
            PageViewsEnum.Teachers => c.GetRequiredService<TeachersViewModel>(),
            PageViewsEnum.AddStudent => c.GetRequiredService<AddStudentViewModel>(),
            PageViewsEnum.AddCourse => c.GetRequiredService<AddCourseViewModel>(),
            PageViewsEnum.AddTeacher => c.GetRequiredService<AddTeacherViewModel>(),

            _ => throw new InvalidOperationException()
        });

        collection.AddSingleton<Func<PageViewsEnum, string, ViewModelBase>>(
            c => (page, id) => page switch
            {
                PageViewsEnum.EditCourse =>
                    new EditCourseViewModel(new CourseServices(), id),

                PageViewsEnum.EditTeacher =>
                    new EditTeacherViewModel(new TeacherServices(), id),

                _ => throw new InvalidOperationException()
            });
    }
}