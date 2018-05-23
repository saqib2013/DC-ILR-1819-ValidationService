﻿using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.ValidationService.Interface
{
    public interface IValidationContext
    {
        IMessage Input { get; set; }
        IInternalDataCache InternalDataCache { get; set; }
    }

    public interface IPreValidationContext
    {
        string Input { get;  }
        string Output { get; }

        string InvalidLearnRefNumbersKey { get; }

        string ValidLearnRefNumbersKey { get; }
        string JobId { get; set; }


    }
}
