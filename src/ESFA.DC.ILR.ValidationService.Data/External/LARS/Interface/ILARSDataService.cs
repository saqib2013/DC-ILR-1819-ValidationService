﻿namespace ESFA.DC.ILR.ValidationService.Data.External.LARS.Interface
{
    public interface ILARSDataService
    {
        bool FrameworkCodeExistsForFrameworkAims(string learnAimRef, int? progType, int? fworkCode, int? pwayCode);

        bool FrameworkCodeExistsForCommonComponent(string learnAimRef, int? progType, int? fworkCode, int? pwayCode);

        bool LearnAimRefExists(string learnAimRef);
    }
}
