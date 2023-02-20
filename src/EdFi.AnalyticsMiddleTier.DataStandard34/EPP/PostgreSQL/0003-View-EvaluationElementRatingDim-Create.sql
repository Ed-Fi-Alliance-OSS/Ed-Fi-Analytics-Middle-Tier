-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS analytics.epp_EvaluationElementRatingDim;

CREATE VIEW analytics.epp_EvaluationElementRatingDim AS
---Evaluation Rating: perfomance evaluation >> Objective >> Element
SELECT 
	DISTINCT Candidate.CandidateIdentifier AS CandidateKey
		,EvaluationElementRatingResult.EvaluationDate
		,to_char(EvaluationElementRatingResult.EvaluationDate, 'yyyymmdd') AS EvaluationDateKey
		,EvaluationElementRatingResult.PerformanceEvaluationTitle
		,EvaluationObjective.EvaluationObjectiveTitle
		,EvaluationElementRatingResult.EvaluationElementTitle
		,EvaluationElementRatingResult.RatingResultTitle
		,EvaluationElementRatingResult.EvaluationTitle
        ,CAST(EvaluationElementRatingResult.TermDescriptorId AS VARCHAR) AS TermDescriptorId
		,CAST(EvaluationElementRatingResult.TermDescriptorId AS VARCHAR) AS TermDescriptorKey
        ,CAST(EvaluationElementRatingResult.SchoolYear AS VARCHAR) AS SchoolYear
		,EvaluationElementRatingResult.Rating,
		(	SELECT 
				MAX(MaxLastModifiedDate)
			FROM (VALUES (Candidate.LastModifiedDate)
						,(EvaluationObjective.LastModifiedDate)
				 ) AS VALUE (MaxLastModifiedDate)
		) AS LastModifiedDate
FROM
	tpdm.EvaluationElementRatingResult
	JOIN tpdm.Candidate
		ON EvaluationElementRatingResult.PersonId = Candidate.PersonId
	JOIN tpdm.EvaluationObjective
		ON EvaluationElementRatingResult.EvaluationObjectiveTitle = EvaluationObjective.EvaluationObjectiveTitle;