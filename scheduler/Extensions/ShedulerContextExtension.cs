using scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Extensions
{
    public static class ShedulerContextExtension
    {
        public static async void CreateDB(this ShedulerContext context)
        {
            List<Kafedra> _kafedras = new List<Kafedra>() {
                new Kafedra {FullName="ITST",ShortName="ITST" },
                new Kafedra { FullName = "Econom", ShortName = "Econom" },
                new Kafedra { FullName = "Yurfak", ShortName = "Yurfak" }
            };
            
            foreach (Kafedra k in _kafedras)
            {
                context.Kafedras.Add(k);
            }
            await context.SaveChangesAsync();


            Specialty Specialty1 = new Specialty { FullName = "IST", ShortName = "IST", KafedraId = _kafedras[0].Id };
            Specialty Specialty2 = new Specialty { FullName = "ITT", ShortName = "ITT", KafedraId = _kafedras[0].Id };

            User mykhailo = new User { Name = "Mykhailo", SecondName = "Ilchuk", Password = "23", KafedraId = _kafedras[0].Id };

            context.Specialties.Add(Specialty1);
            context.Specialties.Add(Specialty2);
            context.Users.Add(mykhailo);

            await context.SaveChangesAsync();

            Group g1 = new Group { Name = "K", Code = "K12-1", StudentsCount = 25, SpecialtyId = Specialty1.Id };
            Group g2 = new Group { Name = "K", Code = "K12-2", StudentsCount = 25, SpecialtyId = Specialty1.Id };
            Group g3 = new Group { Name = "K", Code = "K12-3", StudentsCount = 25, SpecialtyId = Specialty1.Id };

            context.Groups.Add(g1);
            context.Groups.Add(g2);
            context.Groups.Add(g3);

            Lektor lektor1 = new Lektor { Name = "K", Primitka = "Primitka 1", KafedraId = _kafedras[0].Id  };
            Lektor lektor2 = new Lektor { Name = "K", Primitka = "Primitka 2", KafedraId = _kafedras[0].Id };
            Lektor lektor3 = new Lektor { Name = "K", Primitka = "Primitka 3", KafedraId = _kafedras[0].Id };

            context.Lektors.Add(lektor1);
            context.Lektors.Add(lektor2);
            context.Lektors.Add(lektor3);
            await context.SaveChangesAsync();


            Vacation Vacation1 = new Vacation { Day = 1, GroupId = g1.Id, LektorId = lektor1.Id };
            Vacation Vacation2 = new Vacation { Day = 1, GroupId = g1.Id, LektorId = lektor2.Id };
            Vacation Vacation3 = new Vacation { Day = 2, GroupId = g2.Id, LektorId = lektor3.Id };
            Vacation Vacation4 = new Vacation { Day = 2, GroupId = g2.Id, LektorId = lektor3.Id };
            Vacation Vacation5 = new Vacation { Day = 3, GroupId = g3.Id, LektorId = lektor2.Id };
            Vacation Vacation6 = new Vacation { Day = 3, GroupId = g3.Id, LektorId = lektor2.Id };

            context.Vacations.Add(Vacation1);
            context.Vacations.Add(Vacation2);
            context.Vacations.Add(Vacation3);
            context.Vacations.Add(Vacation4);
            context.Vacations.Add(Vacation5);
            context.Vacations.Add(Vacation6);

            Window Window1 = new Window { Value = 1, LektorId = lektor1.Id };
            Window Window2 = new Window { Value = 2, LektorId = lektor2.Id };
            Window Window3 = new Window { Value = 3, LektorId = lektor3.Id };
            Window Window4 = new Window { Value = 4, LektorId = lektor2.Id };
            Window Window5 = new Window { Value = 5, LektorId = lektor3.Id };

            context.Windows.Add(Window1);
            context.Windows.Add(Window2);
            context.Windows.Add(Window3);
            context.Windows.Add(Window4);
            context.Windows.Add(Window5);

            MetodDni MetodDni1 = new MetodDni { Day = 4, LektorId = lektor1.Id };
            MetodDni MetodDni2 = new MetodDni { Day = 4, LektorId = lektor2.Id };
            MetodDni MetodDni3 = new MetodDni { Day = 5, LektorId = lektor3.Id };
            MetodDni MetodDni4 = new MetodDni { Day = 5, LektorId = lektor3.Id };
            MetodDni MetodDni5 = new MetodDni { Day = 5, LektorId = lektor2.Id };
            MetodDni MetodDni6 = new MetodDni { Day = 5, LektorId = lektor2.Id };

            context.MetodDni.Add(MetodDni1);
            context.MetodDni.Add(MetodDni2);
            context.MetodDni.Add(MetodDni3);
            context.MetodDni.Add(MetodDni4);
            context.MetodDni.Add(MetodDni5);
            context.MetodDni.Add(MetodDni6);


            SubjectType SubjectType1 = new SubjectType {FullName="Лекція",ShortName="л." };
            SubjectType SubjectType2 = new SubjectType { FullName = "Семінар", ShortName = "сем." };

            context.SubjectTypes.Add(SubjectType1);
            context.SubjectTypes.Add(SubjectType2);
            await context.SaveChangesAsync();


            Subject Subject1 = new Subject { FullName = "Розподілені бази даних", ShortName = "БД", Period = 5, GroupId = g1.Id, SubjectTypeId = SubjectType1.Id };
            Subject Subject2 = new Subject { FullName = "Розподілені бази даних", ShortName = "БД", Period = 10, GroupId = g1.Id, SubjectTypeId = SubjectType2.Id };
            Subject Subject3 = new Subject { FullName = "Інтелектуальний аналіз дани", ShortName = "ІАд", Period = 10, GroupId = g1.Id, SubjectTypeId = SubjectType2.Id };
            Subject Subject4 = new Subject { FullName = "Інтелектуальний аналіз дани", ShortName = "ІАд", Period = 10, GroupId = g1.Id, SubjectTypeId = SubjectType2.Id };
            Subject Subject5 = new Subject { FullName = "Вища математика", ShortName = "БД", Period = 10, GroupId = g1.Id, SubjectTypeId = SubjectType2.Id };
            Subject Subject6 = new Subject { FullName = "Об'єктно орієнтоване програмування", ShortName = "ООП", Period = 10, GroupId = g1.Id, SubjectTypeId = SubjectType1.Id };


            context.Subjects.Add(Subject1);
            context.Subjects.Add(Subject2);
            context.Subjects.Add(Subject3);
            context.Subjects.Add(Subject4);
            context.Subjects.Add(Subject5);
            context.Subjects.Add(Subject6);


            Сorps Сorps1 = new Сorps { Name="Головний"};
            Сorps Сorps2 = new Сorps { Name = "Рогальова" };
            Сorps Сorps3 = new Сorps { Name = "Аржанова" };

            context.Сorpses.Add(Сorps1);
            context.Сorpses.Add(Сorps2);
            context.Сorpses.Add(Сorps3);
            await context.SaveChangesAsync();

            Audience Audience1 = new Audience { Name = "209", CountOfPlaces = "100", KafedraId = _kafedras[0].Id, СorpsId = Сorps1.Id };
            Audience Audience2 = new Audience { Name = "108", CountOfPlaces = "120", KafedraId = _kafedras[0].Id, СorpsId = Сorps1.Id };
            Audience Audience3 = new Audience { Name = "223", CountOfPlaces = "60", KafedraId = _kafedras[1].Id, СorpsId = Сorps2.Id };
            Audience Audience4 = new Audience { Name = "209a", CountOfPlaces = "105", KafedraId = _kafedras[2].Id, СorpsId = Сorps3.Id };
            Audience Audience5 = new Audience { Name = "209b", CountOfPlaces = "100", KafedraId = _kafedras[1].Id, СorpsId = Сorps2.Id };

            context.Audiences.Add(Audience1);
            context.Audiences.Add(Audience2);
            context.Audiences.Add(Audience3);
            context.Audiences.Add(Audience4);
            context.Audiences.Add(Audience5);

            await context.SaveChangesAsync();

        }

    }
}
