using omran.sama.tests;
using Omran.Sama.Models;
using Omran.Sama.Services;
using Omran.Sama.Tests.GenericExample;
using System.Collections.Generic;

namespace Omran.Sama.Tests
{
    class Program
    {
        static string[] Revers(string[] names)
        {

          //  names =["hasan", "ali", "hossine"];

            string[] reversNames = new string[names.Length];
            int j = 0;
            for (int i = names.Length - 1; i >= 0; i--)
            {
               // int j = names.Length - i - 1;
                reversNames[j] = names[i];
                j++;
            }

            return reversNames;
            System.Console.WriteLine(reversNames);

        }
        static void Main(string[] args)
        {
            var names = new string[]{ "hasan", "ali", "hossine"};
            var res=Program.Revers(names);




            #region StudentServiceTests
            StudentServiceTests studentServiceTest = new StudentServiceTests();


            studentServiceTest.TestLoad();
            studentServiceTest.TestUpdate();
            studentServiceTest.TestRemove();
            studentServiceTest.TestAdd();
            studentServiceTest.TestRemoveMany();
            studentServiceTest.TestName();
            #endregion
            #region InstructorServiceTests
            InstructorServiceTests instructorServiceTests = new InstructorServiceTests();
             instructorServiceTests.TestLoad();
             instructorServiceTests.TestAdd();
             instructorServiceTests.TestUpdate();
            instructorServiceTests.TestGetInstructorsNameByName();
             instructorServiceTests.TestRemove();
            instructorServiceTests.TestLoadById();
            #endregion
            #region CourseServiceTests

            CourseServiceTests courseServiceTests = new CourseServiceTests();
            courseServiceTests.TestLoad();
            courseServiceTests.TestAdd();
            courseServiceTests.TestLoadById();
            courseServiceTests.TestRemove();
            courseServiceTests.TestUpdate();
            courseServiceTests.TestRemoveMany();
            courseServiceTests.TestSetCost();
         

            #endregion
            #region EnrollmentServiceTests
            EnrollmentServiceTests enrollmentServiceTests = new EnrollmentServiceTests();
            // enrollmentServiceTests.TestAdd();
            //enrollmentServiceTests.TestLoad();
            //enrollmentServiceTests.TestLoadById();
            //enrollmentServiceTests.TestRemove();
            //enrollmentServiceTests.Testupdate();
            //enrollmentServiceTests.TestDic();
            enrollmentServiceTests.TestEnoll();
            //enrollmentServiceTests.TestEnoll1();
            //enrollmentServiceTests.TestGetNumberOfEnrollmetsPerStudent();
            #endregion
            #region RollServiceTestse
            RollServiceTests rollServiceTests = new RollServiceTests();
            rollServiceTests.TestAdd();
            #endregion
            #region UserServiceTests
            #endregion

            #region  AccountServiceTests
            AccountServiceTests accountServiceTests = new AccountServiceTests();
            accountServiceTests.TestUpdate();
            accountServiceTests.TestCreatAccount();
            accountServiceTests.TestGetStudentByAccount();
            #endregion

            #region PaymentServiceTests
            PaymentServiceTests paymentServiceTests = new PaymentServiceTests();
           



            #endregion
            #region BankServiceTests
            BankServiceTests bankServiceTests = new BankServiceTests();

            bankServiceTests.TestLoad();
            bankServiceTests.TestAdd();
            bankServiceTests.TestRemove();
            bankServiceTests.TestByLoadId();
            bankServiceTests.TestUpdate();

            #endregion
            #region
            Serializer serializer = new Serializer();
            Student student = new Student { FirstName = "sam" };
            Instructor instructor = new Instructor { FirstName="ham"};
           var result =serializer.Serialize(student);
            var result1 = serializer.Serialize(instructor);
            student = serializer.DeSerialize<Student>(result);
            instructor = serializer.DeSerialize<Instructor>(result1);
            #endregion
            #region ScheduleTests

            ScheduleServiceTests _service = new ScheduleServiceTests();
            _service.Testload();
            _service.TestAdd();
            _service.TestRemove();
            _service.TestUpdate();
            #endregion

        

        }



        
    }
}
