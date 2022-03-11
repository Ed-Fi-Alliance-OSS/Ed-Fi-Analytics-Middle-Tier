﻿-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
DROP VIEW IF EXISTS analytics.EPP_CandidateSurveyDim ;

CREATE VIEW analytics.EPP_CandidateSurveyDim AS
	SELECT CONCAT(s.SurveyIdentifier
			,'-',q.QuestionCode
			,'-',sr.SurveyResponseIdentifier
			,'-',sa.PersonId) as CandidateSurveyKey
		,tc.CandidateIdentifier AS CandidateKey
		,s.SurveyTitle
		,q.SurveySectionTitle
		,to_char(sr.ResponseDate, 'yyyymmdd') as ResponseDateKey
		,q.QuestionCode
		,q.QuestionText
		,COALESCE(mq.NumericResponse,0) as NumericResponse
		,COALESCE(mq.TextResponse,'') as TextResponse
	FROM tpdm.SurveyResponsePersonTargetAssociation sa
	JOIN tpdm.Candidate tc 
		ON sa.PersonId = tc.PersonId
	JOIN edfi.Survey s 
		ON sa.SurveyIdentifier = s.SurveyIdentifier
	JOIN edfi.SurveyResponse sr 
		ON sa.SurveyResponseIdentifier = sr.SurveyResponseIdentifier
	JOIN edfi.SurveyQuestion q 
		ON sa.SurveyIdentifier = q.SurveyIdentifier
	JOIN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse mq 
		ON sa.SurveyResponseIdentifier = mq.SurveyResponseIdentifier
			AND q.QuestionCode = mq.QuestionCode;