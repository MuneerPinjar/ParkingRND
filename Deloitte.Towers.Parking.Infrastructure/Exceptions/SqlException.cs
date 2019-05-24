using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public enum SqlExceptionCode
    {
        // all sql related exceptions should start from 50001
        Unknown = 50001,
        EntityNotFound = 50002,
        EntityDetailsNotFound = 50003,
        EntityAlreadyExists = 50004,
        DependedEntityExists = 50005,
        InvalidParameterValue = 50006,
        SurveyQuestionModification = 50007,
        PermissionDenied = 50008,
        DependentEntitiesNotExist = 50009,
        CannotChangeIsBackupCamera = 50010,
        CannotChangeHasBackupCamera = 50011,
        BuildingAlreadyExists = 50012,
        LevelAlreadyExists = 50013
    }
}
