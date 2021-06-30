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
        public class Given_student_190009_867530020_Special_Education
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190009_867530020_Special_Education";
            public Given_student_190009_867530020_Special_Education(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_BeginDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDateKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
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
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190257_867530023_Section_504_Placement
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190257_867530023_Section_504_Placement";
            public Given_student_190257_867530023_Section_504_Placement(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_one_record()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_one_record.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }

            [Test]
            public void Then_should_have_BeginDateKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_BeginDateKey.xml");
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
            public void Then_should_have_StudentKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_StudentSchoolProgramKey()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_StudentSchoolProgramKey.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
            [Test]
            public void Then_should_have_LastModifiedDate()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<StudentProgramDim>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_have_LastModifiedDate.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190020_867530023_Bilingual
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190020_867530023_Bilingual";
            public Given_student_190020_867530023_Bilingual(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190009_867530020_Special_Education_1684_778530
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190009_867530020_Special_Education_1684_778530";
            public Given_student_190009_867530020_Special_Education_1684_778530(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190257_867530023_Section_504_Placement_1637_867530
            : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190257_867530023_Section_504_Placement_1637_867530";
            public Given_student_190257_867530023_Section_504_Placement_1637_867530(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190257_867530023_Bilingual_1682_867530
           : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190257_867530023_Bilingual_1682_867530";
            public Given_student_190257_867530023_Bilingual_1682_867530(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_not_return_any_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_not_return_any_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class Given_student_190009_867530020
           : When_querying_the_StudentProgramDim_view
        {
            private const string _caseIdentifier = "190009_867530020";
            public Given_student_190009_867530020(TestHarness dataStandard) => SetDataStandard(dataStandard);

            [Test]
            public void Then_should_return_two_records()
            {
                (bool success, string errorMessage) testResult =
                    DataStandard.RunTestCase<CountResult>(
                        $"{TestCasesFolder}.{_caseIdentifier}_should_return_two_records.xml");
                testResult.success.ShouldBe(true, testResult.errorMessage);
            }
        }
    }
}
