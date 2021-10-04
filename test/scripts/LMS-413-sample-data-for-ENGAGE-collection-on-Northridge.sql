begin tran

--Over 36 weeks

declare @numbers table (Number int, BeginDate datetime);

with Numbers as (
    select 0 as Number
    union all
    select Number + 1
    from Numbers
    where Number < 35
)
insert into @numbers
select Number, dateadd(WEEK, Number, cast('2021-08-23' as datetime))
from Numbers

-- 1 assignment per class per week (don't have to match an actual calendar date)

insert into lmsx.Assignment (
	AssignmentIdentifier,
	[Namespace],
	LMSSourceSystemDescriptorId,
	Title, 
	AssignmentCategoryDescriptorId,
	AssignmentDescription,
	StartDateTime,
	EndDateTime,
	DueDateTime,
	MaxPoints,
	SectionIdentifier,
	LocalCourseCode,
	SessionName,
	SchoolYear,
	SchoolId
)
select
	formatmessage('%s-%s-%s-%s-%s-%s', cast(Section.SchoolYear as varchar), cast(Section.SchoolId as varchar), Section.SessionName, Section.LocalCourseCode, Section.SectionIdentifier, cast(n.Number as varchar)) as AssignmentIdentifier,
	'uri://instructure.com/canvas' as [Namespace],
	ssd.DescriptorId as LMSSourceSystemDescriptorId,
	concat(Section.LocalCourseCode, ' ', n.BeginDate) as Title,
	acd.DescriptorId as AssignmentCategoryDescriptorId,
	n.Number as AssignmentDescription,
	n.BeginDate as StartDateTime,
	dateadd(day, 7, n.BeginDate) as EndDateTime,
	dateadd(day, 5, n.BeginDate) as DueDateTime,
	100 as MaxPoints,
	Section.SectionIdentifier,
	Section.LocalCourseCode,
	Section.SessionName,
	Section.SchoolYear,
	Section.SchoolId
from
	@numbers as n
cross join
	edfi.Section
cross join
	(select DescriptorId from edfi.Descriptor where CodeValue = 'Canvas' and [Namespace] = 'uri://ed-fi.org/edfilms/LMSSourceSystem') as ssd
cross join
	(select DescriptorId from edfi.Descriptor where CodeValue = 'Assignment' and [Namespace] = 'uri://ed-fi.org/edfilms/AssignmentCategoryDescriptor/Canvas') as acd

--1 assignment submission per week

insert into lmsx.AssignmentSubmission (
	AssignmentSubmissionIdentifier,
	[Namespace],
	StudentUsi,
	AssignmentIdentifier,
	SubmissionStatusDescriptorId,
	SubmissionDateTime,
	EarnedPoints,
	Grade
)
select
	formatmessage('%s-%s', Assignment.AssignmentIdentifier, cast(StudentSectionAssociation.StudentUsi as varchar)) as AssignmentSubmissionIdentifier,
	Assignment.[Namespace],
	StudentSectionAssociation.StudentUsi,
	Assignment.AssignmentIdentifier,
	case 
		when StudentSectionAssociation.StudentUsi % 5 = 0 then late.DescriptorId
		when StudentSectionAssociation.StudentUsi % 4 = 0 then missing.DescriptorId
		when StudentSectionAssociation.StudentUsi % 3 = 0 then upcoming.DescriptorId
		else ontime.DescriptorId
	end as SubmissionStatusDescriptorId,
	case 
		when StudentSectionAssociation.StudentUsi % 5 = 0 then dateadd(d, 1, Assignment.DueDateTime)
		when StudentSectionAssociation.StudentUsi % 4 = 0 then null
		when StudentSectionAssociation.StudentUsi % 3 = 0 then null
		else dateadd(d, -1, Assignment.DueDateTime)
	end as SubmissionDateTime,
	case 
		when StudentSectionAssociation.StudentUsi % 5 = 0 then 100 - rand(StudentSectionAssociation.StudentUsi)*49
		when StudentSectionAssociation.StudentUsi % 4 = 0 then null
		when StudentSectionAssociation.StudentUsi % 3 = 0 then null
		else 100 - rand(StudentSectionAssociation.StudentUsi)*20 + StudentSectionAssociation.StudentUsi % 11
	end as EarnedPoints,
	null as Grade -- will fill in with another statement
from
	lmsx.Assignment
cross join
	(select DescriptorId from edfi.Descriptor where [Namespace] = 'uri://ed-fi.org/edfilms/SubmissionStatusDescriptor/Canvas' and CodeValue = 'Upcoming') as upcoming
cross join
	(select DescriptorId from edfi.Descriptor where [Namespace] = 'uri://ed-fi.org/edfilms/SubmissionStatusDescriptor/Canvas' and CodeValue = 'on-time') as ontime
cross join
	(select DescriptorId from edfi.Descriptor where [Namespace] = 'uri://ed-fi.org/edfilms/SubmissionStatusDescriptor/Canvas' and CodeValue = 'late') as late
cross join
	(select DescriptorId from edfi.Descriptor where [Namespace] = 'uri://ed-fi.org/edfilms/SubmissionStatusDescriptor/Canvas' and CodeValue = 'missing') as missing
inner join
	edfi.StudentSectionAssociation
on
	Assignment.SectionIdentifier = StudentSectionAssociation.SectionIdentifier
and
	Assignment.LocalCourseCode  = StudentSectionAssociation.LocalCourseCode
and
	Assignment.SessionName = StudentSectionAssociation.SessionName
and
	Assignment.SchoolId = StudentSectionAssociation.SchoolId
and
	Assignment.SchoolYear = StudentSectionAssociation.SchoolYear


update lmsx.AssignmentSubmission set 
	Grade = case 
		when EarnedPoints is null then null
		when EarnedPoints > 90 then 'A'
		when EarnedPoints > 80 then 'B'
		when EarnedPoints > 70 then 'C'
		when EarnedPoints > 64 then 'D'
		else 'F' end
	
--select * from lmsx.AssignmentSubmission
--rollback
--commit



-- Next step: insert random digital equity data
begin tran


-- Engage Online Learners assumes that demographics are stored 
-- on the LEA relationship with the student, not the school.
-- But Northridge has the opposite - so copy the data into
-- a new LEA record for each student.
insert into edfi.StudentEducationOrganizationAssociation (
	StudentUSI,
	EducationOrganizationId,
	HispanicLatinoEthnicity,
	LimitedEnglishProficiencyDescriptorId,
	SexDescriptorId,
	Discriminator
)
select
	StudentUSI,
	School.LocalEducationAgencyId,
	HispanicLatinoEthnicity,
	LimitedEnglishProficiencyDescriptorId,
	SexDescriptorId,
	Discriminator
from
	edfi.StudentEducationOrganizationAssociation
inner join
	edfi.School
on
	StudentEducationOrganizationAssociation.EducationOrganizationId = School.SchoolId
-- There are two students who are enrolled at multiple schools
-- in the same district. To avoid needing a DISTINCT above, just
-- exclude one record for each.
where
	not (StudentUSI = 7576 and School.SchoolId = 255901002)
	and not (StudentUSI = 8406 and School.SchoolId = 255901001)


-- Although the starter kit doesn't use race data, let's make it 
-- available at the LEA level to help with testing other starter kits
-- that may need it
insert into edfi.StudentEducationOrganizationAssociationRace (
	EducationOrganizationId,
	StudentUSI,
	RaceDescriptorId
)
select
	School.LocalEducationAgencyId,
	StudentUSI,
	RaceDescriptorId
from
	edfi.StudentEducationOrganizationAssociationRace
inner join
	edfi.School
on
	StudentEducationOrganizationAssociationRace.EducationOrganizationId = School.SchoolId
where
	not (StudentUSI = 7576 and School.SchoolId = 255901002)
	and not (StudentUSI = 8406 and School.SchoolId = 255901001)
;



-- Now create some digital equity student indicators at the LEA
-- These data will not be well distributed in any coherent manner.
with students as (
	select
		EducationOrganizationId,
		StudentUSI
	from
		edfi.StudentEducationOrganizationAssociation
	where exists (
		select
			1
		from
			edfi.LocalEducationAgency
		where
			LocalEducationAgencyId = StudentEducationOrganizationAssociation.EducationOrganizationId
	)
)
insert into edfi.StudentEducationOrganizationAssociationStudentIndicator (
	EducationOrganizationId,
	IndicatorName,
	StudentUSI,
	IndicatorGroup,
	Indicator
)
select
	EducationOrganizationId,
	'InternetAccessInResidence',
	StudentUSI,
	'Digital Equity',
	case
		when StudentUSI % 5 = 0 then 'No - Other'
		when StudentUSI % 4 = 0 then 'No - Not Affordable'
		when StudentUSI % 3 = 0 then 'No - Not Available'
		else 'yes'
	end
from
	students
union all
select
	EducationOrganizationId,
	'InternetAccessTypeInResidence',
	StudentUSI,
	'Digital Equity',
	case
		when StudentUSI % 8 = 0 then 'None'
		when StudentUSI % 7 = 0 then 'Other'
		when StudentUSI % 6 = 0 then 'Dial-up'
		when StudentUSI % 5 = 0 then 'Satellite'
		when StudentUSI % 4 = 0 then 'SchoolProvidedHotSpot'
		when StudentUSI % 3 = 0 then 'CellularNetwork'
		else 'ResidentialBroadband'
	end
from
	students
union all
select
	EducationOrganizationId,
	'InternetPerformance',
	StudentUSI,
	'Digital Equity',
	case
		when StudentUSI % 4 = 0 then 'No'
		when StudentUSI % 3 = 0 then 'Yes - But not consistent'
		else 'Yes - No issues'
	end
from
	students
union all
select
	EducationOrganizationId,
	'DigitalDevice',
	StudentUSI,
	'Digital Equity',
	case
		when StudentUSI % 7 = 0 then 'Tablet'
		when StudentUSI % 6 = 0 then 'Chromebook'
		when StudentUSI % 5 = 0 then 'SmartPhone'
		when StudentUSI % 4 = 0 then 'None'
		when StudentUSI % 3 = 0 then 'Other'
		else 'Desktop/Laptop'
	end
from
	students
union all
select
	EducationOrganizationId,
	'DeviceAccess',
	StudentUSI,
	'Digital Equity',
	case
		when StudentUSI % 6 = 0 then 'School Provided - Dedicated'
		when StudentUSI % 5 = 0 then 'Personal - Shared'
		when StudentUSI % 4 = 0 then 'None'
		when StudentUSI % 3 = 0 then 'School Provided - Shared'
		else 'Personal - Dedicated'
	end
from
	students


--rollback
commit


-- Update various dates so that they fit inside of actual grading periods.
begin tran;
update lmsx.Assignment set DueDateTime = dateadd(year, -4, DueDateTime)
update lmsx.Assignment set DueDateTime = '2017-09-08' where DueDateTime between '2017-10-01 00:00:00.0000000' and '2019-01-08 00:00:00.0000000'
update lmsx.Assignment set DueDateTime = '2018-01-03' where DueDateTime < '2018-01-02' and SessionName = '2017 - 2018 Spring Semester'

--rollback
commit