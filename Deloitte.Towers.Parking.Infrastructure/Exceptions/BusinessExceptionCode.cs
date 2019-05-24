using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public enum BusinessExceptionCode
    {
        // application exceptions should start from 1
        Unknown = 1,
        Unauthorized = 2,
        OAuthVerification = 3,
        ParameterIsRequired = 4,
        RestServiceError = 5,
        RestServiceDeserializationError = 6,
        PeopleService = 7,
        InvalidHttpRequestContentType = 8,
        InvalidDataBaseVersion = 9,
        InvalidFileSize = 10,
        InvalidFileExtension = 11,
        InvalidFileContent = 12,
        InvalidFileName = 13,
        PeopleServiceUserNotFound = 14,
        OpenExcelError = 15,
        PushNotificationError = 16,
        TrafficSerciceError = 17,

        // all sql related exceptions should start from 50001
        SqlUnknown = 50001,
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
        LevelAlreadyExists = 50013,

        ValidationException = 50025,
        FileUploadException = 50026
    }
}
