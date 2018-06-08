﻿using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.ValidationService.Interface;
using ESFA.DC.ILR.ValidationService.Rules.Abstract;
using ESFA.DC.ILR.ValidationService.Rules.Constants;

namespace ESFA.DC.ILR.ValidationService.Rules.LearningDelivery.LearnDelFAMDateFrom
{
    public class LearnDelFAMDateFrom_03Rule : AbstractRule, IRule<ILearner>
    {
        private readonly IEnumerable<string> _learnDelFamTypes = new HashSet<string>()
        {
            LearningDeliveryFAMTypeConstants.LSF,
            LearningDeliveryFAMTypeConstants.ACT,
            LearningDeliveryFAMTypeConstants.ALB
        };

        public LearnDelFAMDateFrom_03Rule(IValidationErrorHandler validationErrorHandler)
            : base(validationErrorHandler, RuleNameConstants.LearnDelFAMDateFrom_03)
        {
        }

        public void Validate(ILearner objectToValidate)
        {
            foreach (var learningDelivery in objectToValidate.LearningDeliveries)
            {
                if (learningDelivery.LearningDeliveryFAMs != null)
                {
                    foreach (var learningDeliveryFam in learningDelivery.LearningDeliveryFAMs)
                    {
                        if (ConditionMet(learningDeliveryFam.LearnDelFAMDateFromNullable, learningDeliveryFam.LearnDelFAMType))
                        {
                            HandleValidationError(objectToValidate.LearnRefNumber, learningDelivery.AimSeqNumber, BuildErrorMessageParameters(learningDeliveryFam.LearnDelFAMType, learningDeliveryFam.LearnDelFAMDateFromNullable));
                        }
                    }
                }
            }
        }

        public bool ConditionMet(DateTime? learnDelFamDateFrom, string learnDelFamType)
        {
            return learnDelFamDateFrom.HasValue && !_learnDelFamTypes.Contains(learnDelFamType);
        }

        public IEnumerable<IErrorMessageParameter> BuildErrorMessageParameters(string learnDelFamType, DateTime? learnDelFamDateFrom)
        {
            return new[]
            {
                BuildErrorMessageParameter(PropertyNameConstants.LearnDelFAMType, learnDelFamType),
                BuildErrorMessageParameter(PropertyNameConstants.LearnDelFAMDateFrom, learnDelFamDateFrom)
            };
        }
    }
}
