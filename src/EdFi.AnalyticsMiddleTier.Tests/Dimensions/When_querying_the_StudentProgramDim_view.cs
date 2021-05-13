using System.Diagnostics.CodeAnalysis;
using EdFi.AnalyticsMiddleTier.Tests.Classes;
using NUnit.Framework;
using Shouldly;

namespace EdFi.AnalyticsMiddleTier.Tests.Dimensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class When_querying_the_StudentProgramDim_view : When_querying_a_view
    {

        protected const string TestCasesFolder = "TestCases.StudentProgramDim";

        protected (bool success, string errorMessage) Result;

        [OneTimeSetUp]
        public void PrepareDatabase()
        {
            DataStandard.PrepareDatabase();
        }

        [OneTimeSetUp]
        public void Act()
        {
            Result = DataStandard.LoadTestCaseData<StudentSchoolDim>($"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0000_StudentProgramDim_Data_Load.xml");
            Result.success.ShouldBeTrue($"Error while loading data: '{Result.errorMessage}'");

            Result = DataStandard.Install(10);
            Result.success.ShouldBeTrue($"Error while installing Base: '{Result.errorMessage}'");
        }

        [Test]
        public void Then_view_should_match_column_dictionary()
        {
            (bool success, string errorMessage) testResult =
                DataStandard.RunTestCase<TableColumns>(
                    $"{TestCasesFolder}.{DataStandard.DataStandardFolderName}.0001_StudentProgramDim_should_match_column_dictionary.xml");
            testResult.success.ShouldBe(true, testResult.errorMessage);
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_100021874
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "100021874";
            public Given_student_100021874(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BeginDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EducationOrganizationId()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EducationOrganizationId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentUSI()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentUSI.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_100039988
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "100039988";
            public Given_student_100039988(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BeginDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_EducationOrganizationId()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_EducationOrganizationId.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_ProgramName()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_ProgramName.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentSchoolKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_StudentUSI()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentUSI.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_100039889
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "100039889";
            public Given_student_100039889(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_100023237
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "100023237";
            public Given_student_100023237(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_three_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_three_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
