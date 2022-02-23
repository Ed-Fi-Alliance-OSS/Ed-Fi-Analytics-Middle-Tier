
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = 'analytics' AND TABLE_NAME = 'engage_AssignmentSubmissionFact')
BEGIN
	DROP VIEW analytics.engage_AssignmentSubmissionFact
END
GO

CREATE VIEW analytics.engage_AssignmentSubmissionFact
AS
	SELECT
		AssignmentSubmission.AssignmentSubmissionIdentifier as AssignmentSubmissionKey,
		FORMATMESSAGE(
			'%s-%s',
			Student.StudentUniqueId,
			CAST(Assignment.SchoolId as VARCHAR)
		) as StudentSchoolKey,
		Assignment.SchoolId as SchoolKey,
		Student.StudentUniqueId as StudentKey,
		FORMATMESSAGE(
			'%s-%s-%s-%s-%s',
			CAST(Assignment.SchoolId AS NVARCHAR)
			,Assignment.LocalCourseCode
			,CAST(Assignment.SchoolYear AS NVARCHAR)
			,Assignment.SectionIdentifier
			,Assignment.SessionName
			) AS SectionKey,
		Assignment.AssignmentIdentifier as AssignmentKey,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.IsPastDue'
		        OR DescriptorConstant.ConstantName = 'SubmissionStatus.Upcoming' THEN ''
			ELSE CONVERT(VARCHAR, AssignmentSubmission.SubmissionDateTime, 112)
			END as SubmissionDateKey,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.IsPastDue' THEN 0
			ELSE AssignmentSubmission.EarnedPoints
			END as EarnedPoints,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.IsPastDue' THEN 0
			ELSE CAST(
					(CAST(AssignmentSubmission.EarnedPoints as decimal) / CAST(Assignment.MaxPoints as decimal))
					* 100 
					as DECIMAL(9,2))
			END as NumericGrade,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.IsPastDue' THEN ''
			ELSE AssignmentSubmission.Grade
			END as LetterGrade,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.IsPastDue' THEN 1 ELSE 0 END as IsPastDue,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.SubmittedLate' THEN 1 ELSE 0 END as SubmittedLate,
		CASE WHEN DescriptorConstant.ConstantName = 'SubmissionStatus.SubmittedOnTime' THEN 1 ELSE 0 END as SubmittedOnTime,
		CASE WHEN DueDateTime > GETDATE() THEN 1 ELSE 0 END as UpcomingAssignment,
		AssignmentSubmission.LastModifiedDate
	FROM
		lmsx.AssignmentSubmission

	INNER JOIN
		analytics_config.DescriptorMap
	ON
		AssignmentSubmission.SubmissionStatusDescriptorId = DescriptorMap.DescriptorId
	INNER JOIN
		analytics_config.DescriptorConstant
	ON
		DescriptorMap.DescriptorConstantId = DescriptorConstant.DescriptorConstantId

	INNER JOIN
		edfi.Student
	ON
		AssignmentSubmission.StudentUSI = Student.StudentUSI

	INNER JOIN
		lmsx.Assignment
	ON
		AssignmentSubmission.AssignmentIdentifier = Assignment.AssignmentIdentifier
	AND
		AssignmentSubmission.[Namespace] = Assignment.[Namespace];
