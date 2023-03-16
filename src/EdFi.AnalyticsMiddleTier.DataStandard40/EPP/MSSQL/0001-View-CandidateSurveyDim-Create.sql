-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('analytics.epp_CandidateSurveyDim') IS NOT NULL 
	DROP VIEW analytics.epp_CandidateSurveyDim

GO

CREATE VIEW analytics.epp_CandidateSurveyDim AS
    SELECT CONCAT(Survey.SurveyIdentifier
			,'-',SurveyQuestion.QuestionCode
			,'-',SurveyResponse.SurveyResponseIdentifier
			,'-',SurveyResponsePersonTargetAssociation.PersonId) as CandidateSurveyKey
		,Candidate.CandidateIdentifier AS CandidateKey
		,Survey.SurveyTitle
		,SurveyQuestion.SurveySectionTitle
		,CONVERT(varchar, SurveyResponse.ResponseDate, 112) as ResponseDateKey
		,SurveyQuestion.QuestionCode
		,SurveyQuestion.QuestionText
		,CAST(COALESCE(SurveyQuestionResponseSurveyQuestionMatrixElementResponse.NumericResponse,0) as VARCHAR) as NumericResponse
		,COALESCE(SurveyQuestionResponseSurveyQuestionMatrixElementResponse.TextResponse,'') as TextResponse
		,(
            SELECT
                MAX(MaxLastModifiedDate)
            FROM
                (VALUES(Candidate.LastModifiedDate)
                    , (SurveyResponsePersonTargetAssociation.LastModifiedDate)
                    , (Survey.LastModifiedDate)
                    , (SurveyResponse.LastModifiedDate)
                  , (SurveyQuestion.LastModifiedDate)
                ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
	FROM tpdm.SurveyResponsePersonTargetAssociation
	JOIN tpdm.Candidate 
		ON SurveyResponsePersonTargetAssociation.PersonId = Candidate.PersonId
	JOIN edfi.Survey
		ON SurveyResponsePersonTargetAssociation.SurveyIdentifier = Survey.SurveyIdentifier
	JOIN edfi.SurveyResponse
		ON SurveyResponsePersonTargetAssociation.SurveyResponseIdentifier = SurveyResponse.SurveyResponseIdentifier
	JOIN edfi.SurveyQuestion
		ON SurveyResponsePersonTargetAssociation.SurveyIdentifier = SurveyQuestion.SurveyIdentifier
	JOIN edfi.SurveyQuestionResponseSurveyQuestionMatrixElementResponse
		ON SurveyResponsePersonTargetAssociation.SurveyResponseIdentifier = SurveyQuestionResponseSurveyQuestionMatrixElementResponse.SurveyResponseIdentifier
			AND SurveyQuestion.QuestionCode = SurveyQuestionResponseSurveyQuestionMatrixElementResponse.QuestionCode;

