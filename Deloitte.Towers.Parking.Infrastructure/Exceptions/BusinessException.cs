using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deloitte.Towers.Parking.Domain.Entities;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public abstract class BusinessException : Exception
    {
        protected BusinessException()
        {
        }

        public static readonly Dictionary<BusinessExceptionCode, string> BusinessExceptionMessages = new Dictionary<BusinessExceptionCode, string>
        {
            { BusinessExceptionCode.Unknown, "Unknown exception" },
            { BusinessExceptionCode.Unauthorized, "Unauthorized access" },
            { BusinessExceptionCode.OAuthVerification, "OAuth verification failed" },
            { BusinessExceptionCode.ParameterIsRequired, "Parameter is required" },
            { BusinessExceptionCode.RestServiceError, "Bad result of REST service call" },
            { BusinessExceptionCode.RestServiceDeserializationError, "REST service deserialization error" },
            { BusinessExceptionCode.PeopleService, "People service error" },
            { BusinessExceptionCode.InvalidHttpRequestContentType, "Invalid ContentType of http request data" },
            { BusinessExceptionCode.InvalidDataBaseVersion, "Invalid version of database" },
            { BusinessExceptionCode.InvalidFileSize, "Invalid size of file" },
            { BusinessExceptionCode.InvalidFileExtension, "Invalid extension of file" },
            { BusinessExceptionCode.InvalidFileContent, "File contains an invalid content" },
            { BusinessExceptionCode.SqlUnknown, "Unknown sql exception" },
            { BusinessExceptionCode.EntityNotFound, "Entity not found" },
            { BusinessExceptionCode.EntityDetailsNotFound, "Entity details not found" },
            { BusinessExceptionCode.EntityAlreadyExists, "Entity already exists" },
            { BusinessExceptionCode.DependedEntityExists, "Depended entity exists" },
            { BusinessExceptionCode.InvalidParameterValue, "Invalid parameter value" },
            { BusinessExceptionCode.SurveyQuestionModification, "Survey Has Employee Answers. Can't update questions and/or answers" },
            { BusinessExceptionCode.PermissionDenied, "Permission denied" },
            { BusinessExceptionCode.DependentEntitiesNotExist, "Sorry, you cannot make category Published. There should be at least 1 published Topic with 1 published FAQ" },
            { BusinessExceptionCode.PeopleServiceUserNotFound, "People service user not found" },
            { BusinessExceptionCode.OpenExcelError, "Incorrect file. Please use the template for import." },
            { BusinessExceptionCode.PushNotificationError, "PNS exception"},
            { BusinessExceptionCode.TrafficSerciceError, "Google Distance Matrix API exception"},
            { BusinessExceptionCode.CannotChangeIsBackupCamera, "This camera is used as a backup camera. In order to edit this camera please unlink it as a backup camera" },
            { BusinessExceptionCode.CannotChangeHasBackupCamera, "Sorry, you cannot change the backup camera" },
            { BusinessExceptionCode.BuildingAlreadyExists, "Sorry, you cannot create the Building. It already exists" },
            { BusinessExceptionCode.LevelAlreadyExists, "Sorry, you cannot create the Level. It already exists" }
        };

        private readonly string errorMessage;

        private string fullMessage;

        protected BusinessException(BusinessExceptionCode exceptionCode)
        {
            ExceptionCode = exceptionCode;
            BusinessExceptionMessages.TryGetValue(exceptionCode, out errorMessage);
        }

        protected BusinessException(BusinessExceptionCode exceptionCode, string message)
        {
            ExceptionCode = exceptionCode;
            BusinessExceptionMessages.TryGetValue(exceptionCode, out errorMessage);

            if (!string.IsNullOrWhiteSpace(message))
            {
                fullMessage = message;
            }
        }

        public BusinessExceptionCode ExceptionCode { get; }


        public override string Message => errorMessage;

        public string FullMessage
        {
            get { return string.IsNullOrWhiteSpace(fullMessage) ? errorMessage : fullMessage; }
            set { fullMessage = value; }
        }

        public object ExceptionData { get; set; }

        public virtual ResponseError GetError()
        {
            return new ResponseError
            {
                Code = (int)ExceptionCode,
                Message = Message,
                FullMessage = FullMessage,
                Detail = ExceptionData
            };
        }
    }
}
